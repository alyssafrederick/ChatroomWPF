using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChatRoomAlyssa
{
    public partial class InputForm : Form
    {
        public string SubmittedText
        {
            get
            {
                if (accepted)
                {
                    return textbox.Text;
                }
                return "";
            }
        }
        private bool accepted = false;

        public InputForm(string title, string message, string buttonText)
        {
            StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
            this.Text = title;
            messageLabel.Text = message;
            sendButton.Text = buttonText;
            sendButton.Width = sendButton.PreferredSize.Width;
            sendButton.Location = new Point((Width - sendButton.Width) / 2, sendButton.Location.Y);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            accepted = true;
            this.Close();
        }
    }
}
