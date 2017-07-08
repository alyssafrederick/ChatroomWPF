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
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox(string message)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            messageLabel.Text = message;
            Height = okayButton.Height + messageLabel.Height + 30;
            okayButton.Location = new Point(okayButton.Location.X, Height - okayButton.Height - 10);
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
