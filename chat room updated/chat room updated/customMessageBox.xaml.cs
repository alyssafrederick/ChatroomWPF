using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChatRoomAlyssaUpdated
{
    public partial class customMessageBox : Window
    {
        public string typedMessage;
        public customMessageBox(string message)
        {
            InitializeComponent();
            messageLabel.Content = message;

            messageLabel.Height = Height;
            int magicNumber = 30;
            int numberOfNewLines = 0;

            if (((string)messageLabel.Content).Length > magicNumber)
            {
                for (int i = magicNumber - 1; i > 0; i--)
                {
                    if (message[i] == ' ')
                    {
                        numberOfNewLines++;
                        message.Remove(i, 1);
                        message = message.Insert(i, "\n");
                        break;
                    }
                }

                messageLabel.Content = message;
            }

            Height = Height + numberOfNewLines * magicNumber;
        }

        private void okayButton_Click(object sender, RoutedEventArgs e)
        {
            typedMessage = textbox.Text;
            Close();
        }
    }
}
