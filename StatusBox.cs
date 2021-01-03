using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using RunEnvironment;

namespace ExtendedControls
{
    public partial class StatusBox : UserControl
    {        
        [Serializable]
        public class Status
        {
            private string description;
            private Image icon;

            public Status()
            {
                this.description = "";
                this.icon = null;
            }

            public string Description
            {
                get { return description; }
                set { description = value; }
            }

            public Image Icon
            {
                get { return icon; }
                set { icon = value; }
            }
        }

        private bool interactive = true;
        [Category("Settings")]
        [Description("Can the control value be changed at runtime?")]
        public bool Interactive
        {
            get { return interactive; }
            set { interactive = value; }
        }

        private List<Status> statuses = new List<Status>();
        [Category("Settings")]
        [Description("Edit the available statuses")]
        public List<Status> Statuses
        {
            get { return statuses; }
            //@TODO work out issue where control wont "Reload()" after set - gives problem in editor why it wont show correctly unless SelectedIndex set
            set
            {
                statuses = value;
                ShowSelected();
            }
        }

        private int selectedIndex;
        [Category("Settings")]
        [Description("Set the initial status via index value")]
        public int Value
        {
            get { return selectedIndex; }
            set
            {
                if (value < statuses.Count)
                {
                    selectedIndex = value;
                    ShowSelected();
                }
                else
                {
                    if (RunMode.IsInDesignMode(this))
                    {
                        MessageBox.Show("No item exists at index " + Value + "\n" + "Indices range from 0 to " + (statuses.Count - 1), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        throw new InvalidOperationException("No item exists at index " + Value + ". " + "Indices range from 0 to " + (statuses.Count - 1));
                    }
                }
            }
        }

        public StatusBox()
        {
            SetDefaultStatuses();
            InitializeComponent();
            Value = 0;
            ShowSelected();
        }

        private void SetDefaultStatuses()
        {
            Status pending = new Status();
            pending.Description = "Pending";
            pending.Icon = Image.FromFile("images\\StatusBox\\pending.png");
            statuses.Add(pending);
            Status in_progress = new Status();
            in_progress.Description = "In progress";
            in_progress.Icon = Image.FromFile("images\\StatusBox\\in_progress.png");
            statuses.Add(in_progress);
            Status paused = new Status();
            paused.Description = "Paused";
            paused.Icon = Image.FromFile("images\\StatusBox\\paused.png");
            statuses.Add(paused);
            Status complete = new Status();
            complete.Description = "Complete";
            complete.Icon = Image.FromFile("images\\StatusBox\\complete.png");
            statuses.Add(complete);
            Status cancelled = new Status();
            cancelled.Description = "Cancelled";
            cancelled.Icon = Image.FromFile("images\\StatusBox\\cancel.png");
            statuses.Add(cancelled);
        }

        private void ShowSelected()
        {
            if (statuses.Count > 0 && Value < statuses.Count)
            {
                iconBox.Image = statuses[Value].Icon;
            }
            else if (statuses.Count > 0)
            {
                if (RunMode.IsInDesignMode(this))
                {
                    MessageBox.Show("No item exists at index " + Value + "\n" + "Indices range from 0 to " + (statuses.Count - 1), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    throw new InvalidOperationException("No item exists at index " + Value + ". " + "Indices range from 0 to " + (statuses.Count - 1));
                }
                Value = 0;
            }
        }

        private void iconBox_Click(object sender, EventArgs e)
        {
            if (interactive)
            {
                if (Value < statuses.Count - 1)
                {
                    Value++;
                }
                else
                {
                    Value = 0;
                }
                ShowSelected();
            }
        }
    }
}
