using System;
using System.IO;
using System.Reflection;
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
            set
            {
                statuses = value;
                ShowSelected();
            }
        }

        private int selectedIndex;
        [Category("Settings")]
        [Description("Set or return the status via index value")]
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

        [Browsable (false)]
        [Description("Returns the status description as a string")]
        public string Selected
        {
            get { return statuses[selectedIndex].Description; }
            /*set { @TODO complete a way of setting via Selected accessor }*/
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
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream imageStream;

            imageStream = myAssembly.GetManifestResourceStream("ExtendedControls.images.StatusBox.pending.png");
            Image pending_icon = Image.FromStream(imageStream);
            Status pending = new Status
            {
                Description = "Pending",
                Icon = pending_icon
            };
            statuses.Add(pending);

            imageStream = myAssembly.GetManifestResourceStream("ExtendedControls.images.StatusBox.in_progress.png");
            Image in_progress_icon = Image.FromStream(imageStream);
            Status in_progress = new Status
            {
                Description = "In progress",
                Icon = in_progress_icon
            };
            statuses.Add(in_progress);

            imageStream = myAssembly.GetManifestResourceStream("ExtendedControls.images.StatusBox.paused.png");
            Image paused_icon = Image.FromStream(imageStream);
            Status paused = new Status
            {
                Description = "Paused",
                Icon = paused_icon
            };
            statuses.Add(paused);

            imageStream = myAssembly.GetManifestResourceStream("ExtendedControls.images.StatusBox.complete.png");
            Image complete_icon = Image.FromStream(imageStream);
            Status complete = new Status
            {
                Description = "Complete",
                Icon = complete_icon
            };
            statuses.Add(complete);

            imageStream = myAssembly.GetManifestResourceStream("ExtendedControls.images.StatusBox.cancel.png");
            Image cancelled_icon = Image.FromStream(imageStream);
            Status cancelled = new Status
            {
                Description = "Cancelled",
                Icon = cancelled_icon
            };
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
                tooltip.SetToolTip(this.iconBox, Statuses[selectedIndex].Description);
            }
        }

        private readonly ToolTip tooltip = new ToolTip();
        private void iconBox_MouseHover(object sender, EventArgs e)
        {
            tooltip.SetToolTip(this.iconBox, Statuses[selectedIndex].Description);
        }
    }
}
