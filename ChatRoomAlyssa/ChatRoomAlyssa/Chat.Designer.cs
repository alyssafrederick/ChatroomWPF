namespace ChatRoomAlyssa
{
    partial class chatRoom
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
            this.components = new System.ComponentModel.Container();
            this.messageTimer = new System.Windows.Forms.Timer(this.components);
            this.yourChatsHeading = new System.Windows.Forms.Label();
            this.chatHeading = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.friendsPanel = new System.Windows.Forms.Panel();
            this.deleteFriendButton = new System.Windows.Forms.Button();
            this.addFriendButton = new System.Windows.Forms.Button();
            this.friendsHeading = new System.Windows.Forms.Label();
            this.friendsPopOutTimer = new System.Windows.Forms.Timer(this.components);
            this.yourchats = new System.Windows.Forms.Panel();
            this.messages = new ChatRoomAlyssa.CustomTextBox();
            this.messageBox = new ChatRoomAlyssa.CustomTextBox();
            this.friendsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // messageTimer
            // 
            this.messageTimer.Enabled = true;
            this.messageTimer.Interval = 16;
            this.messageTimer.Tick += new System.EventHandler(this.messageTimer_Tick);
            // 
            // yourChatsHeading
            // 
            this.yourChatsHeading.AutoSize = true;
            this.yourChatsHeading.BackColor = System.Drawing.Color.Transparent;
            this.yourChatsHeading.Font = new System.Drawing.Font("Andy", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yourChatsHeading.ForeColor = System.Drawing.Color.DimGray;
            this.yourChatsHeading.Location = new System.Drawing.Point(46, 21);
            this.yourChatsHeading.Name = "yourChatsHeading";
            this.yourChatsHeading.Size = new System.Drawing.Size(154, 39);
            this.yourChatsHeading.TabIndex = 4;
            this.yourChatsHeading.Text = "your chats";
            // 
            // chatHeading
            // 
            this.chatHeading.AutoSize = true;
            this.chatHeading.BackColor = System.Drawing.Color.Transparent;
            this.chatHeading.Font = new System.Drawing.Font("Andy", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatHeading.ForeColor = System.Drawing.Color.DimGray;
            this.chatHeading.Location = new System.Drawing.Point(572, 21);
            this.chatHeading.Name = "chatHeading";
            this.chatHeading.Size = new System.Drawing.Size(71, 39);
            this.chatHeading.TabIndex = 32;
            this.chatHeading.Text = "chat";
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
            this.sendButton.Location = new System.Drawing.Point(913, 520);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(73, 36);
            this.sendButton.TabIndex = 33;
            this.sendButton.TabStop = false;
            this.sendButton.Text = "send";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // friendsPanel
            // 
            this.friendsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(159)))), ((int)(((byte)(255)))));
            this.friendsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.friendsPanel.Controls.Add(this.deleteFriendButton);
            this.friendsPanel.Controls.Add(this.addFriendButton);
            this.friendsPanel.Controls.Add(this.friendsHeading);
            this.friendsPanel.Location = new System.Drawing.Point(1006, 0);
            this.friendsPanel.Name = "friendsPanel";
            this.friendsPanel.Size = new System.Drawing.Size(151, 568);
            this.friendsPanel.TabIndex = 36;
            // 
            // deleteFriendButton
            // 
            this.deleteFriendButton.BackColor = System.Drawing.Color.Transparent;
            this.deleteFriendButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.deleteFriendButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(159)))), ((int)(((byte)(255)))));
            this.deleteFriendButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(226)))), ((int)(((byte)(236)))));
            this.deleteFriendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteFriendButton.Font = new System.Drawing.Font("Andy", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteFriendButton.ForeColor = System.Drawing.Color.DimGray;
            this.deleteFriendButton.Location = new System.Drawing.Point(74, 531);
            this.deleteFriendButton.Name = "deleteFriendButton";
            this.deleteFriendButton.Size = new System.Drawing.Size(76, 36);
            this.deleteFriendButton.TabIndex = 38;
            this.deleteFriendButton.TabStop = false;
            this.deleteFriendButton.Text = "delete";
            this.deleteFriendButton.UseVisualStyleBackColor = false;
            this.deleteFriendButton.Click += new System.EventHandler(this.deleteFriendButton_Click);
            // 
            // addFriendButton
            // 
            this.addFriendButton.BackColor = System.Drawing.Color.Transparent;
            this.addFriendButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.addFriendButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(159)))), ((int)(((byte)(255)))));
            this.addFriendButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(226)))), ((int)(((byte)(236)))));
            this.addFriendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addFriendButton.Font = new System.Drawing.Font("Andy", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addFriendButton.ForeColor = System.Drawing.Color.DimGray;
            this.addFriendButton.Location = new System.Drawing.Point(-1, 531);
            this.addFriendButton.Name = "addFriendButton";
            this.addFriendButton.Size = new System.Drawing.Size(76, 36);
            this.addFriendButton.TabIndex = 37;
            this.addFriendButton.TabStop = false;
            this.addFriendButton.Text = "add";
            this.addFriendButton.UseVisualStyleBackColor = false;
            this.addFriendButton.Click += new System.EventHandler(this.addFriendButton_Click);
            // 
            // friendsHeading
            // 
            this.friendsHeading.BackColor = System.Drawing.Color.Transparent;
            this.friendsHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.friendsHeading.Font = new System.Drawing.Font("Andy", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.friendsHeading.ForeColor = System.Drawing.Color.DimGray;
            this.friendsHeading.Location = new System.Drawing.Point(0, 0);
            this.friendsHeading.Name = "friendsHeading";
            this.friendsHeading.Size = new System.Drawing.Size(149, 38);
            this.friendsHeading.TabIndex = 36;
            this.friendsHeading.Text = "friends";
            this.friendsHeading.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // friendsPopOutTimer
            // 
            this.friendsPopOutTimer.Enabled = true;
            this.friendsPopOutTimer.Interval = 16;
            this.friendsPopOutTimer.Tick += new System.EventHandler(this.friendsPopOutTimer_Tick);
            // 
            // yourchats
            // 
            this.yourchats.BackColor = System.Drawing.Color.Transparent;
            this.yourchats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.yourchats.Location = new System.Drawing.Point(12, 68);
            this.yourchats.Name = "yourchats";
            this.yourchats.Size = new System.Drawing.Size(205, 488);
            this.yourchats.TabIndex = 37;
            // 
            // messages
            // 
            this.messages.BackColor = System.Drawing.Color.Transparent;
            this.messages.BlinkTime = 500;
            this.messages.BorderColor = System.Drawing.Color.DimGray;
            this.messages.BorderWidth = 1;
            this.messages.ForeColor = System.Drawing.Color.DimGray;
            this.messages.IsPassword = false;
            this.messages.Location = new System.Drawing.Point(229, 68);
            this.messages.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.messages.MultiLine = true;
            this.messages.Name = "messages";
            this.messages.PasswordCharacter = '\0';
            this.messages.Size = new System.Drawing.Size(757, 440);
            this.messages.TabIndex = 35;
            // 
            // messageBox
            // 
            this.messageBox.BackColor = System.Drawing.Color.Transparent;
            this.messageBox.BlinkTime = 500;
            this.messageBox.BorderColor = System.Drawing.Color.DimGray;
            this.messageBox.BorderWidth = 1;
            this.messageBox.ForeColor = System.Drawing.Color.DimGray;
            this.messageBox.IsPassword = false;
            this.messageBox.Location = new System.Drawing.Point(229, 520);
            this.messageBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.messageBox.MultiLine = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.PasswordCharacter = '\0';
            this.messageBox.Size = new System.Drawing.Size(678, 36);
            this.messageBox.TabIndex = 34;
            this.messageBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.messageBox_KeyDown_1);
            // 
            // chatRoom
            // 
            this.AcceptButton = this.sendButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ChatRoomAlyssa.Properties.Resources.splatterChat;
            this.ClientSize = new System.Drawing.Size(1000, 568);
            this.Controls.Add(this.yourchats);
            this.Controls.Add(this.friendsPanel);
            this.Controls.Add(this.messages);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.chatHeading);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.yourChatsHeading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "chatRoom";
            this.Text = "chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.chatRoom_FormClosing);
            this.friendsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer messageTimer;
        private System.Windows.Forms.Label yourChatsHeading;
        private CustomTextBox messages;
        private CustomTextBox messageBox;
        private System.Windows.Forms.Label chatHeading;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Panel friendsPanel;
        private System.Windows.Forms.Label friendsHeading;
        private System.Windows.Forms.Timer friendsPopOutTimer;
        private System.Windows.Forms.Button deleteFriendButton;
        private System.Windows.Forms.Button addFriendButton;
        private System.Windows.Forms.Panel yourchats;
    }
}