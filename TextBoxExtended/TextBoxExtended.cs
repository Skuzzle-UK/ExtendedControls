using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ExtendedControls
{
    public partial class TextBoxExtended : UserControl
    {
        private int top = 0;
        private int bottom = 0;
        private int left = 0;
        private int right = 0;
        private Color topcolor = SystemColors.Control;
        private Color bottomcolor = SystemColors.Control;
        private Color leftcolor = SystemColors.Control;
        private Color rightcolor = SystemColors.Control;

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

        public int TextBoxHeight
        {
            get { return textBox1.Height; }
        }

        public TextBoxExtended()
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
    }
}
