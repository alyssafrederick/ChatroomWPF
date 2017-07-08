namespace ChatRoomAlyssa
{
    partial class InputForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textbox = new ChatRoomAlyssa.CustomTextBox();
            this.messageLabel = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // textbox
            // 
            this.textbox.BackColor = System.Drawing.Color.Transparent;
            this.textbox.BlinkTime = 500;
            this.textbox.BorderColor = System.Drawing.Color.DimGray;
            this.textbox.BorderWidth = 1;
            this.textbox.ForeColor = System.Drawing.Color.DimGray;
            this.textbox.IsPassword = false;
            this.textbox.Location = new System.Drawing.Point(47, 96);
            this.textbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textbox.MultiLine = true;
            this.textbox.Name = "textbox";
            this.textbox.PasswordCharacter = 'x';
            this.textbox.Size = new System.Drawing.Size(304, 34);
            this.textbox.TabIndex = 0;
            this.textbox.Tag = "";
            // 
            // messageLabel
            // 
            this.messageLabel.BackColor = System.Drawing.Color.Transparent;
            this.messageLabel.Font = new System.Drawing.Font("Andy", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.ForeColor = System.Drawing.Color.DimGray;
            this.messageLabel.Location = new System.Drawing.Point(47, 24);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(304, 60);
            this.messageLabel.TabIndex = 1;
            this.messageLabel.Text = "message";
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.Color.Transparent;
            this.sendButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.sendButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(159)))), ((int)(((byte)(255)))));
            this.sendButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(226)))), ((int)(((byte)(236)))));
            this.sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendButton.Font = new System.Drawing.Font("Andy", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendButton.ForeColor = System.Drawing.Color.DimGray;
            this.sendButton.Location = new System.Drawing.Point(161, 160);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(73, 36);
            this.sendButton.TabIndex = 34;
            this.sendButton.TabStop = false;
            this.sendButton.Text = "buttontext";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.cancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(159)))), ((int)(((byte)(255)))));
            this.cancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(226)))), ((int)(((byte)(236)))));
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Andy", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.Color.DimGray;
            this.cancelButton.Location = new System.Drawing.Point(-24, 160);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(15, 13);
            this.cancelButton.TabIndex = 35;
            this.cancelButton.TabStop = false;
            this.cancelButton.Text = "buttontext";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 238);
            this.panel1.TabIndex = 36;
            // 
            // InputForm
            // 
            this.AcceptButton = this.sendButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ChatRoomAlyssa.Properties.Resources.splatteredInputForm;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(395, 238);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.textbox);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InputForm";
            this.Text = "Dialog";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomTextBox textbox;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel panel1;
    }
}