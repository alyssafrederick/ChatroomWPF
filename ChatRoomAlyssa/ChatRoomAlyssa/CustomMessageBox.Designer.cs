namespace ChatRoomAlyssa
{
    partial class CustomMessageBox
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
            this.okayButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.messageLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // okayButton
            // 
            this.okayButton.BackColor = System.Drawing.Color.Transparent;
            this.okayButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.okayButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(159)))), ((int)(((byte)(255)))));
            this.okayButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(226)))), ((int)(((byte)(236)))));
            this.okayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okayButton.Font = new System.Drawing.Font("Andy", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okayButton.ForeColor = System.Drawing.Color.DimGray;
            this.okayButton.Location = new System.Drawing.Point(128, 47);
            this.okayButton.Name = "okayButton";
            this.okayButton.Size = new System.Drawing.Size(120, 41);
            this.okayButton.TabIndex = 23;
            this.okayButton.TabStop = false;
            this.okayButton.Text = "okay";
            this.okayButton.UseVisualStyleBackColor = false;
            this.okayButton.Click += new System.EventHandler(this.okayButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.okayButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 202);
            this.panel1.TabIndex = 25;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.BackColor = System.Drawing.Color.Transparent;
            this.messageLabel.Font = new System.Drawing.Font("Andy", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.ForeColor = System.Drawing.Color.DimGray;
            this.messageLabel.Location = new System.Drawing.Point(10, 10);
            this.messageLabel.MaximumSize = new System.Drawing.Size(355, 0);
            this.messageLabel.MinimumSize = new System.Drawing.Size(355, 0);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(355, 30);
            this.messageLabel.TabIndex = 24;
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CustomMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ChatRoomAlyssa.Properties.Resources.splatterChat;
            this.ClientSize = new System.Drawing.Size(375, 202);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CustomMessageBox";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okayButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label messageLabel;
    }
}