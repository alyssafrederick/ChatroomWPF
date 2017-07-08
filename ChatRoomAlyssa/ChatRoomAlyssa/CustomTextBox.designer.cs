namespace ChatRoomAlyssa
{
    partial class CustomTextBox
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
            this.components = new System.ComponentModel.Container();
            this.hiddenTextBox = new System.Windows.Forms.RichTextBox();
            this.cursorBlink = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // hiddenTextBox
            // 
            this.hiddenTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.hiddenTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.hiddenTextBox.Location = new System.Drawing.Point(-151, 6);
            this.hiddenTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.hiddenTextBox.Name = "hiddenTextBox";
            this.hiddenTextBox.Size = new System.Drawing.Size(136, 50);
            this.hiddenTextBox.TabIndex = 0;
            this.hiddenTextBox.Text = "";
            // 
            // cursorBlink
            // 
            this.cursorBlink.Enabled = true;
            this.cursorBlink.Tick += new System.EventHandler(this.cursorBlink_Tick);
            // 
            // CustomTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.hiddenTextBox);
            this.Font = new System.Drawing.Font("Andy", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "CustomTextBox";
            this.Size = new System.Drawing.Size(319, 60);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox hiddenTextBox;
        private System.Windows.Forms.Timer cursorBlink;

    }
}
