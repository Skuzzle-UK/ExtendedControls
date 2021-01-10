using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ExtendedControls
{
    public partial class PriceBox : UserControl
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
        [Description("Displayed decimal value")]
        [DisplayName("Value")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        public decimal Value
        {
            get { return decimal.Parse(textBox1.Text); }
            set { value = Math.Round(value, 2); textBox1.Text = value.ToString(); textBox1_Validating(textBox1, new System.ComponentModel.CancelEventArgs()); UpdateBox(); }
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

        [Browsable(false)]
        public int TextBoxHeight
        {
            get { return textBox1.Height; }
        }

        public PriceBox()
        {
            InitializeComponent();
            Value = 0;
            label1.Text = System.Globalization.RegionInfo.CurrentRegion.CurrencySymbol;
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Stop at max value based on MaxLength
            if((sender as TextBox).Text.Length > ((sender as TextBox).MaxLength - 4) && ((sender as TextBox).Text.IndexOf('.') == -1) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            //Check for all selected to allow decimal place as first keystroke
            if((sender as TextBox).SelectionLength == (sender as TextBox).Text.Length)
            {
                if(e.KeyChar == '.')
                {
                    textBox1.Text = "0.";
                    textBox1.SelectionStart = textBox1.Text.Length;
                    e.Handled = true;
                }
            }

            //Checks for sensible key press if units value is zero. Either a decimal place follows 0 unit value or backspace to delete
            if ((sender as TextBox).Text == "0")
            {
                if ((e.KeyChar != '.') && (e.KeyChar != (char)Keys.Back))
                {
                    e.Handled = true;
                }
            }

            //Forces a zero infront of decimal place if decimal place is typed with no unit value for values lower the 1
            if ((sender as TextBox).Text.Length == 0 && (e.KeyChar == '.'))
            {
                (sender as TextBox).Text = "0";
                (sender as TextBox).SelectionStart = (sender as TextBox).Text.Length;
            }

            //Check for numeric, decimal place and backspace only keys
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            //Allow max of 2 decimal places to be typed
            TextBox tb = sender as TextBox;
            int cursorPosLeft = tb.SelectionStart;
            int cursorPosRight = tb.SelectionStart + tb.SelectionLength;
            string result = tb.Text.Substring(0, cursorPosLeft) + e.KeyChar + tb.Text.Substring(cursorPosRight);
            string[] parts = result.Split('.');
            if (parts.Length > 1 && (e.KeyChar != (char)Keys.Back))

            {
                if (parts[1].Length > 2 || parts.Length > 2)
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox1_Enter(object sender, System.EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            
            //Adds a zero unit to front of value if decimal place is first character
            if(textBox1.Text.Substring(0, 1) == ".")
            {
                textBox1.Text = "0" + textBox1.Text;
            }

            //Formats blank textbox value to look like monetary zero value
            if (textBox1.Text == null || textBox1.Text == "")
            {
                textBox1.Text = "0.00";
            }

            //Adds decimals to the end of textbox to look like monetary value
            if(!textBox1.Text.Contains("."))
            {
                textBox1.Text += ".00";
            }

            //Adds correct amount of zeros to always make up 2 decimal places
            string[] parts = textBox1.Text.Split('.');
            while (parts[1].Length < 2)
            {
                parts[1] += "0";
            }

            textBox1.Text = parts[0] + "." + parts[1];
        }

        private void textBox1_Click(object sender, System.EventArgs e)
        {
            //Selects all characters if decimal value of textbox is 0
            if(decimal.Parse(textBox1.Text) == 0)
            {
                textBox1.SelectAll();
            }
        }
    }
}
