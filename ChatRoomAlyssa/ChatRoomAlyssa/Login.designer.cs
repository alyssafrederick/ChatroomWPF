namespace ChatRoomAlyssa
{
    partial class Login
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
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.loginHeading = new System.Windows.Forms.Label();
            this.signInButton = new System.Windows.Forms.Button();
            this.signUpButton = new System.Windows.Forms.Button();
            this.password = new ChatRoomAlyssa.CustomTextBox();
            this.username = new ChatRoomAlyssa.CustomTextBox();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.usernameLabel.Font = new System.Drawing.Font("Andy", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.ForeColor = System.Drawing.Color.DimGray;
            this.usernameLabel.Location = new System.Drawing.Point(309, 206);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(126, 30);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "username :";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.BackColor = System.Drawing.Color.Transparent;
            this.passwordLabel.Font = new System.Drawing.Font("Andy", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.ForeColor = System.Drawing.Color.DimGray;
            this.passwordLabel.Location = new System.Drawing.Point(313, 247);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(122, 30);
            this.passwordLabel.TabIndex = 1;
            this.passwordLabel.Text = "password :";
            // 
            // loginHeading
            // 
            this.loginHeading.AutoSize = true;
            this.loginHeading.BackColor = System.Drawing.Color.Transparent;
            this.loginHeading.Font = new System.Drawing.Font("Andy", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginHeading.ForeColor = System.Drawing.Color.DimGray;
            this.loginHeading.Location = new System.Drawing.Point(459, 158);
            this.loginHeading.Name = "loginHeading";
            this.loginHeading.Size = new System.Drawing.Size(81, 39);
            this.loginHeading.TabIndex = 2;
            this.loginHeading.Text = "login";
            // 
            // signInButton
            // 
            this.signInButton.BackColor = System.Drawing.Color.Transparent;
            this.signInButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.signInButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(159)))), ((int)(((byte)(255)))));
            this.signInButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(226)))), ((int)(((byte)(236)))));
            this.signInButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signInButton.Font = new System.Drawing.Font("Andy", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signInButton.ForeColor = System.Drawing.Color.DimGray;
            this.signInButton.Location = new System.Drawing.Point(441, 298);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(120, 41);
            this.signInButton.TabIndex = 0;
            this.signInButton.TabStop = false;
            this.signInButton.Text = "sign in";
            this.signInButton.UseVisualStyleBackColor = false;
            this.signInButton.Click += new System.EventHandler(this.signInButton_Click);
            // 
            // signUpButton
            // 
            this.signUpButton.BackColor = System.Drawing.Color.Transparent;
            this.signUpButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.signUpButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(159)))), ((int)(((byte)(255)))));
            this.signUpButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(226)))), ((int)(((byte)(236)))));
            this.signUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signUpButton.Font = new System.Drawing.Font("Andy", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signUpButton.ForeColor = System.Drawing.Color.DimGray;
            this.signUpButton.Location = new System.Drawing.Point(441, 345);
            this.signUpButton.Name = "signUpButton";
            this.signUpButton.Size = new System.Drawing.Size(120, 41);
            this.signUpButton.TabIndex = 0;
            this.signUpButton.TabStop = false;
            this.signUpButton.Text = "sign up";
            this.signUpButton.UseVisualStyleBackColor = false;
            this.signUpButton.Click += new System.EventHandler(this.signUpButton_Click);
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.Transparent;
            this.password.BlinkTime = 500;
            this.password.BorderColor = System.Drawing.Color.DimGray;
            this.password.BorderWidth = 1;
            this.password.ForeColor = System.Drawing.Color.DimGray;
            this.password.IsPassword = true;
            this.password.Location = new System.Drawing.Point(441, 247);
            this.password.Margin = new System.Windows.Forms.Padding(7);
            this.password.MultiLine = true;
            this.password.Name = "password";
            this.password.PasswordCharacter = 'x';
            this.password.Size = new System.Drawing.Size(216, 30);
            this.password.TabIndex = 4;
            // 
            // username
            // 
            this.username.BackColor = System.Drawing.Color.Transparent;
            this.username.BlinkTime = 500;
            this.username.BorderColor = System.Drawing.Color.DimGray;
            this.username.BorderWidth = 1;
            this.username.ForeColor = System.Drawing.Color.DimGray;
            this.username.IsPassword = false;
            this.username.Location = new System.Drawing.Point(441, 208);
            this.username.Margin = new System.Windows.Forms.Padding(7);
            this.username.MultiLine = true;
            this.username.Name = "username";
            this.username.PasswordCharacter = '\0';
            this.username.Size = new System.Drawing.Size(216, 30);
            this.username.TabIndex = 0;
            // 
            // Login
            // 
            this.AcceptButton = this.signInButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::ChatRoomAlyssa.Properties.Resources.splatteredPage;
            this.ClientSize = new System.Drawing.Size(998, 568);
            this.Controls.Add(this.signUpButton);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.signInButton);
            this.Controls.Add(this.loginHeading);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Login";
            this.Text = "log in";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label loginHeading;
        private System.Windows.Forms.Button signInButton;
        private CustomTextBox username;
        private CustomTextBox password;
        private System.Windows.Forms.Button signUpButton;
    }
}

