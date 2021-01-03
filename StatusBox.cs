using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace ExtendedControls
{
    public partial class StatusBox : UserControl
    {
        
        [Serializable]
        public class Status
        {
            string description;
            Image icon;

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

        private List<Status> statuses = new List<Status>();

        public List<Status> Statuses
        {
            get { return statuses; }
            set
            {
                statuses = value;
                Reload();
            }
        }

        private int selectedIndex;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set 
            {
                selectedIndex = value;
                Reload();
            }
        }

        public StatusBox()
        {
            InitializeComponent();

        }

        public void Reload()
        {
            if (statuses.Count > 0)
            {
                iconBox.Image = statuses[selectedIndex].Icon;
                label1.Text = statuses[selectedIndex].Description;
            }
        }
    }
}
