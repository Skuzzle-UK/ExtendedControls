using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ExtendedControls
{
    public partial class ComboBoxExtended : UserControl
    {
        //Padding variables
        private int top = 0;
        private int bottom = 0;
        private int left = 0;
        private int right = 0;
        private Color topcolor = SystemColors.Control;
        private Color bottomcolor = SystemColors.Control;
        private Color leftcolor = SystemColors.Control;
        private Color rightcolor = SystemColors.Control;
        
        //Padding accessors
        [Category("Extended Padding")]
        [Description("Padding at the top of the TextBox")]
        [DisplayName("Padding Top")]
        public int PadTop
        {
            get { return top; }
            set { top = value; UpdateBox(); }
        }
        [Category("Extended Padding")]
        [Description("Padding at the bottom of the TextBox")]
        [DisplayName("Padding Bottom")]
        public int PadBottom
        {
            get { return bottom; }
            set { bottom = value; UpdateBox(); }
        }
        [Category("Extended Padding")]
        [Description("Padding at the left of the TextBox")]
        [DisplayName("Padding Left")]
        public int PadLeft
        {
            get { return left; }
            set { left = value; UpdateBox(); }
        }
        [Category("Extended Padding")]
        [Description("Padding at the right of the TextBox")]
        [DisplayName("Padding Right")]
        public int PadRight
        {
            get { return right; }
            set { right = value; UpdateBox(); }
        }
        [Category("Extended Padding")]
        [Description("Color of the padding around the TextBox")]
        [DisplayName("Top color")]
        public Color PadTopColor
        {
            get { return topcolor; }
            set { topcolor = value; UpdateBox(); }
        }
        [Category("Extended Padding")]
        [Description("Color of the padding around the TextBox")]
        [DisplayName("Bottom color")]
        public Color PadBottomColor
        {
            get { return bottomcolor; }
            set { bottomcolor = value; UpdateBox(); }
        }
        [Category("Extended Padding")]
        [Description("Color of the padding around the TextBox")]
        [DisplayName("Left color")]
        public Color PadLeftColor
        {
            get { return leftcolor; }
            set { leftcolor = value; UpdateBox(); }
        }
        [Category("Extended Padding")]
        [Description("Color of the padding around the TextBox")]
        [DisplayName("Right color")]
        public Color PadRightColor
        {
            get { return rightcolor; }
            set { rightcolor = value; UpdateBox(); }
        }

        //Appearance based accessors
        [Category("Appearance")]
        [Description("Displayed text")]
        [DisplayName("Text")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        public override string Text
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; UpdateBox(); }
        }

        [Category("Appearance")]
        [Description("Maximum length")]
        [DisplayName("Max Length")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        public int MaxLength
        {
            get { return textBox1.MaxLength; }
            set { textBox1.MaxLength = value; UpdateBox(); }
        }

        [Category("Appearance")]
        [Description("Alignment of text")]
        [DisplayName("Text Align")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        public HorizontalAlignment TextAlign
        {
            get { return textBox1.TextAlign; }
            set { textBox1.TextAlign = value; UpdateBox(); }
        }

        [Category("Appearance")]
        [Description("Drop down button Icon")]
        [DisplayName("Button Icon")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        public Image ButtonIcon
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; UpdateBox(); }
        }

        [Category("Appearance")]
        [Description("Drop down button background color")]
        [DisplayName("Button BackColor")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        public Color ButtonBackColor
        {
            get { return pictureBox1.BackColor; }
            set { pictureBox1.BackColor = value; UpdateBox(); }
        }

        //ComboBox Variables
        private List<string> items;
        private int selectedIndex;

        //ComboBox accessors
        [Category("Data")]
        [Description("List of items that populate the drop down list of the ComboBoxExtended")]
        [DisplayName("Items")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        public List<string> Items
        {
            get { return items; }
            set { items = value; UpdateBox(); }
        }

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; UpdateBox(); }
        }

        [Browsable(false)]
        public int TextBoxHeight
        {
            get { return textBox1.Height; }
        }

        public ComboBoxExtended()
        {
            InitializeComponent();
            UpdateBox();
        }

        public void UpdateBox()
        {
            panelTop.Height = PadTop;
            panelBottom.Height = PadBottom;
            panelLeft.Width = PadLeft;
            panelRight.Width = PadRight;
            panelTop.BackColor = PadTopColor;
            panelBottom.BackColor = PadBottomColor;
            panelLeft.BackColor = PadLeftColor;
            panelRight.BackColor = PadRightColor;
            textBox1.BackColor = this.BackColor;
            textBox1.ForeColor = this.ForeColor;
            pictureBox1.Height = textBox1.Height;
            pictureBox1.Width = textBox1.Height;
            this.Height = textBox1.Height + panelTop.Height + panelBottom.Height;
        }

        private void TextBoxExtended_BackColorChanged(object sender, System.EventArgs e)
        {
            UpdateBox();
        }

        private void TextBoxExtended_ForeColorChanged(object sender, System.EventArgs e)
        {
            UpdateBox();
        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {
            //@TODO work out here how to display list of items
            //@TODO enable icons next to list items
        }

        private void pictureBox1_MouseEnter(object sender, System.EventArgs e)
        {
            //@TODO Allow change button icon or color
        }

        private void pictureBox1_MouseLeave(object sender, System.EventArgs e)
        {
            //@TODO Change button icon or colour back
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //@TODO change button icon or colour on mouse down
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //Changes button icon or colour back to hover colour
            pictureBox1_MouseEnter(this.pictureBox1, e);
        }
    }
}
