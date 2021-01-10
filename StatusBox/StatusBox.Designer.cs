
namespace ExtendedControls
{
    partial class StatusBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IconBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // IconBox
            // 
            this.IconBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IconBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IconBox.Location = new System.Drawing.Point(0, 0);
            this.IconBox.Margin = new System.Windows.Forms.Padding(0);
            this.IconBox.Name = "IconBox";
            this.IconBox.Size = new System.Drawing.Size(98, 98);
            this.IconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IconBox.TabIndex = 0;
            this.IconBox.TabStop = false;
            this.IconBox.Click += new System.EventHandler(this.IconBox_Click);
            this.IconBox.MouseHover += new System.EventHandler(this.IconBox_MouseHover);
            // 
            // StatusBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.IconBox);
            this.Name = "StatusBox";
            this.Size = new System.Drawing.Size(98, 98);
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox IconBox;
    }
}
