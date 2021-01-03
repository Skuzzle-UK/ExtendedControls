using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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

        private List<Status> statuses = new List<Status>();

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

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set 
            {
                selectedIndex = value;
                ShowSelected();
            }
        }

        public StatusBox()
        {
            InitializeComponent();

        }

        private void ShowSelected()
        {
            if (statuses.Count > 0)
            {
                iconBox.Image = statuses[selectedIndex].Icon;
            }
        }

        private void iconBox_Click(object sender, EventArgs e)
        {

        }
    }
}
