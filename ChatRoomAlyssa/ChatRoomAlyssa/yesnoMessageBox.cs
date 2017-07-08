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
    public partial class yesnoMessageBox : Form
    {
        public bool yes = false;
        public yesnoMessageBox(string message)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            messageLabel.Text = message;
            Height = yesButton.Height + messageLabel.Height + 30;
            yesButton.Location = new Point(yesButton.Location.X, Height - yesButton.Height - 10);
            noButton.Location = new Point(noButton.Location.X, Height - noButton.Height - 10);
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            yes = true;
            Close();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
