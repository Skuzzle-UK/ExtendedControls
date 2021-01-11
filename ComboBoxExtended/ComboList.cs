using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtendedControls
{
    public partial class ComboList : Form
    {
        private ListViewItem[] listItems;

        public ListView.SelectedListViewItemCollection SelectedItem
        {
            get { return listView1.SelectedItems; }
        }

        public int ListWidth
        {
            get { return this.Width; }
            set { this.Width = value; }
        }

        public ListViewItem[] ListItems
        {
            get { return listItems; }
            set { listItems = value; }
        }

        public ComboList()
        {
            InitializeComponent();
            listView1.Items[0].Selected = true;
            listView1.Select();
            //listView1.Items.AddRange(listItems);
        }
    }
}
