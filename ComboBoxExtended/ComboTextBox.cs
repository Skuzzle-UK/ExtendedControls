using System.Windows.Forms;
using System;

namespace ExtendedControls
{
    //Special TextBox which allows for DropDownRequested event to be triggered on down arrow key
    class ComboTextBox : TextBox
    {
        public event EventHandler DropDownRequested;

        //Called when down arrow key is pressed to trigger event
        private void CheckAndCallHandlers()
        {
            EventHandler handler = DropDownRequested;
            handler(this, EventArgs.Empty);
        }

        //Detection of down arrow key
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Down:
                    CheckAndCallHandlers();
                    return false;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
