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
    public partial class yesnoMessageBox : Window
    {
        public bool yes = false;
        public yesnoMessageBox(string message)
        {
            InitializeComponent();
            messageLabel.Content = message;

            messageLabel.Height = Height;
            int magicNumber = 30;

            if (((string)messageLabel.Content).Length > magicNumber)
            {
                for (int i = magicNumber - 1; i > 0; i--)
                {
                    if (message[i] == ' ')
                    {
                        message.Remove(i, 1);
                        message = message.Insert(i, "\n");
                        break;
                    }
                }

                messageLabel.Content = message;
            }
        }

        private void yesButtonClicked(object sender, RoutedEventArgs e)
        {
            yes = true;
            Close();
        }

        private void noButtonClicked(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
