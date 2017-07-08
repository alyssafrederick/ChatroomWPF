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
using System.Data.SqlClient;
using System.Data;

namespace ChatRoomAlyssaUpdated
{
    public partial class chatroom : Window
    {
        SqlConnection connection = new SqlConnection("server=GMRDLT1; database=alyssaChatProgram; user=sa; password=GreatMinds110;");

        DateTime lastRecieved;
        bool friendsListVisible = false;
        string chatname;
        double mousex = 0;
        double mousey = 0;

        int accountID;
        int messageID;
        int groupID;
        List<Button> currentFriends = new List<Button>();
        System.Windows.Threading.DispatcherTimer friendsPanelTimer = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer friendsPanelCloseTimer = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer chatRefreshTimer = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer messageTimer = new System.Windows.Threading.DispatcherTimer();

        //starting timers and just starting program in general
        public chatroom(int id)
        {
            lastRecieved = DateTime.Now;
            accountID = id;
            messageID = id;
            InitializeComponent();
            //StartPosition = FormStartPosition.CenterScreen;
            LoadFriends();
            LoadChats();

            friendsPanelTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            friendsPanelTimer.Interval = new TimeSpan(0, 0, 0, 0, 25);

            friendsPanelCloseTimer.Interval = new TimeSpan(0, 0, 0, 0, 25);

            chatRefreshTimer.Interval = TimeSpan.FromSeconds(2);
            chatRefreshTimer.Tick += new EventHandler(chatRefreshTimer_Tick);
            chatRefreshTimer.Start();

            messageTimer.Interval = TimeSpan.FromSeconds(1);
            messageTimer.Tick += new EventHandler(messageTimer_Tick);
            messageTimer.Start();
        }

        bool firstRun = true;

        //loading stuff
        public void LoadChats()
        {
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "usp_getAllChatGroups";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@accountID", accountID);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            connection.Close();
            int y = 0;
            int tmpGroupID;
            string tmpChatName;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Button chatbutton = new Button();
                chatbutton.Visibility = System.Windows.Visibility.Visible;
                chatbutton.Margin = new Thickness(3, y, 0, 0);

                tmpChatName = table.Rows[i]["name"].ToString();

                if (firstRun)
                {
                    chatname = tmpChatName;
                    firstRun = false;
                }
                chatbutton.Tag = Convert.ToInt32(table.Rows[i]["groupID"]);

                chatbutton.Content = "";

                tmpGroupID = Convert.ToInt32(table.Rows[i]["groupID"]);

                if (tmpChatName.Length < 15)
                {
                    chatbutton.Content = tmpChatName;
                }
                else
                {
                    for (int ii = 0; ii < 11; ii++)
                    {
                        chatbutton.Content = String.Format("{0}{1}", chatbutton.Content, tmpChatName[ii]);
                    }
                    chatbutton.Content += "...";
                }

                chatbutton.Height = 35;
                chatbutton.Width = 190;
                chatbutton.BorderBrush = sendButton.BorderBrush;
                chatbutton.Background = sendButton.Background;
                chatbutton.FontFamily = sendButton.FontFamily;
                chatbutton.FontSize = sendButton.FontSize;
                chatbutton.Foreground = sendButton.Foreground;
                yourChats.Children.Add(chatbutton);
                chatbutton.Click += new RoutedEventHandler(chatbutton_Click);
                y += 34;
            }
        }

        public void LoadFriends()
        {
            connection.Open();

            foreach (Button b in currentFriends)
            {
                friendsPanel.Children.Remove(b);
            }

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "usp_getFriends";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@accountID", accountID);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();

            float y = (float)(friendsLabel.Margin.Top + friendsLabel.Height);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                //setting the friends buttons
                Button friendButton = new Button();
                friendButton.Margin = new Thickness(3, y, 0, 0);
                string username = table.Rows[i]["username"].ToString();
                friendButton.Content = "";
                friendButton.BorderBrush = sendButton.BorderBrush;
                friendButton.Background = sendButton.Background;
                friendButton.FontFamily = sendButton.FontFamily;
                friendButton.FontSize = sendButton.FontSize;
                friendButton.Foreground = sendButton.Foreground;
                friendButton.Height = 35;
                friendButton.Width = friendsPanel.Width - 6;

                Size size = Font.MeasureTextSize(username, friendButton.FontFamily, friendButton.FontStyle, friendButton.FontWeight, friendButton.FontStretch, friendButton.FontSize);
                //putting the friends username into the button
                if (size.Width > friendButton.Width)
                {
                    friendButton.Content = "TOO BIG";
                    string user = "";
                    for (int ii = 0; ii < username.Length; ii++)
                    {
                        user += username[ii];
                        size = Font.MeasureTextSize(user, friendButton.FontFamily, friendButton.FontStyle, friendButton.FontWeight, friendButton.FontStretch, friendButton.FontSize);
                        if (size.Width > friendButton.Width)
                        {
                            user = user.Remove(user.Length - 5, 5);
                            break;
                        }
                    }
                    user += "...";
                    friendButton.Content = user;
                }
                else
                {
                    friendButton.Content = username;
                }

                y += 34;

                friendButton.Click += new RoutedEventHandler(friendButton_Click);
                currentFriends.Add(friendButton);
                friendsPanel.Children.Add(friendButton);
            }
        }

        //timers
        private void messageTimer_Tick(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "usp_getMessages";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@lastRecieved", lastRecieved);
            command.Parameters.AddWithValue("@groupID", groupID);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DateTime lastrecieved = DateTime.Parse(table.Rows[i]["whenSent"].ToString());
                if (lastrecieved > lastRecieved)
                {
                    string accountID = table.Rows[i]["accountID"].ToString();
                    command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "usp_getUsernameByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@accountID", accountID);
                    SqlDataAdapter swagAdapter = new SqlDataAdapter(command);
                    DataTable swagTable = new DataTable();
                    swagAdapter.Fill(swagTable);

                    string username = swagTable.Rows[0]["username"].ToString();

                    messages.Text += lastRecieved.ToString() + " ";
                    messages.Text += username + "\n";

                    string userMessage = table.Rows[i]["message"].ToString();
                    const int messageLimitPerLine = 80;
                    int index = 0;

                    while (index + messageLimitPerLine < userMessage.Length)
                    {
                        index += messageLimitPerLine + 1;
                        userMessage = userMessage.Insert(index, "\n");
                    }

                    messages.Text += userMessage + "\n";

                    lastRecieved = lastrecieved;
                }
            }

            connection.Close();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            int offset = 15;
            if (mousex > Width - 30)
            {
                friendsListVisible = true;
                if (friendsPanel.Margin.Left > Width - friendsPanel.Width - offset)
                {
                    friendsPanel.Margin = new Thickness(friendsPanel.Margin.Left - 10, friendsPanel.Margin.Top, 0, 0);
                    if (friendsPanel.Margin.Left < Width - friendsPanel.Width - offset)
                    {
                        friendsPanel.Margin = new Thickness(Width - friendsPanel.Width - offset, friendsPanel.Margin.Top, 0, 0);
                    }
                }
            }
            else if (!friendsListVisible && friendsPanel.Margin.Left < Width)
            {
                friendsPanel.Margin = new Thickness(friendsPanel.Margin.Left + 10, friendsPanel.Margin.Top, 0, 0);
            }
        }

        void chatRefreshTimer_Tick(object sender, EventArgs e)
        {
            LoadChats();
        }

        //mouse leave events
        private void friendsPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            friendsListVisible = false;
        }

        private void chatRoom_MouseLeave(object sender, MouseEventArgs e)
        {
            if (e.GetPosition(chatRoom).X >= chatRoom.Width - SystemParameters.ResizeFrameVerticalBorderWidth * 2 - 100)
            {
                //if no, start the timer
                if (friendsPanelTimer.IsEnabled == false)
                {
                    friendsPanelTimer.Start();
                }

                //NOT HERE, but in TIMER TICK: slide out the panel; when done, stop the timer
            }
        }

        private void chatRoom_MouseMove(object sender, MouseEventArgs e)
        {
            mousex = e.GetPosition(chatRoom).X;
            mousey = e.GetPosition(chatRoom).Y;
        }

        //various click events
        void chatbutton_Click(object sender, RoutedEventArgs e)/////////////make the chat names so when they click it you can get the details of the chat///////////////////
        {
            messages.Text = "";
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "usp_getMessages";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@lastRecieved", lastRecieved);
            command.Parameters.AddWithValue("@groupID", groupID);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            //MessageBox.Show(table.ToString());
            //connection.Close();

            Button clickedButton = sender as Button;
            //connection.Open();
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = String.Format("SELECT * FROM [chat access]  WHERE  groupID = {0}", clickedButton.Tag);
            command.CommandType = CommandType.Text;
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);

            List<string> peopleInGroup = new List<string>();
            foreach(DataRow row in table.Rows)
            {
                int accountID = Convert.ToInt32(row["accountID"]);
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "usp_getUsernameByID";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@accountID", accountID);
                SqlDataAdapter swagAdapter = new SqlDataAdapter(command);
                DataTable userTable = new DataTable();
                swagAdapter.Fill(userTable);

                if (userTable.Rows.Count > 0)
                {
                    peopleInGroup.Add(userTable.Rows[0]["username"].ToString());
                }
            }

            SqlCommand commandtwo = new SqlCommand();
            commandtwo.Connection = connection;
            commandtwo.CommandText = "usp_getChatGroup";
            commandtwo.CommandType = CommandType.StoredProcedure;
            commandtwo.Parameters.AddWithValue("@name", chatname);
            adapter = new SqlDataAdapter(commandtwo);
            DataTable chatgrouptable = new DataTable();
            adapter.Fill(chatgrouptable);
            groupID = (int)clickedButton.Tag;
            connection.Close();

            string message = "DETAILS \n ";

            foreach (string name in peopleInGroup)
            {
                message += String.Format("{0} \n", name);
            }

            errorMessagesBox detailsBox = new errorMessagesBox(message);
            detailsBox.Show(); 
        }

        void friendButton_Click(object sender, RoutedEventArgs e)
        {
            yesnoMessageBox messageBox = new yesnoMessageBox("would you like to create a chat with this person?");
            messageBox.ShowDialog();

            if (messageBox.yes == true)
            {
                customMessageBox newform = new customMessageBox("what would you like to name this group?");
                newform.ShowDialog();
                string groupname = newform.typedMessage;

                customMessageBox form = new customMessageBox("what would you like the password to be?");
                form.ShowDialog();
                string password = form.typedMessage;

                //creating chat
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "usp_createChatGroup";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", groupname);
                command.Parameters.AddWithValue("@password", password);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                //adding self to chat
                int newGroupID = int.Parse(table.Rows[0]["groupID"].ToString());
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "usp_addGroupAccess";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@accountID", accountID);
                command.Parameters.AddWithValue("@groupID", newGroupID);
                command.ExecuteNonQuery();

                //get id of the other person
                DataTable resultTable = new DataTable();
                string username = ((Button)sender).Content.ToString();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "usp_getIDbyUsername";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@username", username);
                SqlDataAdapter adapter2 = new SqlDataAdapter(command);
                adapter2.Fill(resultTable);
                int otherPersonID = Convert.ToInt32(resultTable.Rows[0]["accountID"]);

                //add other person to chat
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "usp_addGroupAccess";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@accountID", otherPersonID);
                command.Parameters.AddWithValue("@groupID", newGroupID);
                command.ExecuteNonQuery();

                connection.Close();

                LoadChats();
            }
        }

        private void addFriend_Click(object sender, RoutedEventArgs e)
        {
            customMessageBox addFriendBox = new customMessageBox("add friend");
            addFriendBox.ShowDialog();
            string friendUsername = addFriendBox.typedMessage;

            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "usp_getIDbyUsername";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", friendUsername);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();

            if (table.Rows.Count > 0)
            {
                connection.Open();
                try
                {
                    SqlCommand command2 = new SqlCommand();
                    command2.Connection = connection;
                    command2.CommandText = "usp_addFriend";
                    command2.CommandType = CommandType.StoredProcedure;
                    command2.Parameters.AddWithValue("@accountID", accountID);
                    command2.Parameters.AddWithValue("@friendID", table.Rows[0]["accountID"].ToString());
                    command2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    errorMessagesBox error = new errorMessagesBox("there was an error adding this friend");
                    error.Show();
                }
                connection.Close();
                LoadFriends();
            }
            else
            {
                customMessageBox command2 = new customMessageBox("username doesn't exist");
                command2.ShowDialog();
            }
        }

        private void deleteFriend_Click(object sender, RoutedEventArgs e)
        {
            customMessageBox deleteFriendBox = new customMessageBox("delete friend");
            deleteFriendBox.ShowDialog();
            string friendUsername = deleteFriendBox.typedMessage;

            yesnoMessageBox areyousure = new yesnoMessageBox("are you sure you want to delete this friend?");
            areyousure.ShowDialog();

            if (areyousure.yes == true)
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "usp_getIDbyUsername";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@username", friendUsername);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                connection.Close();

                if (table.Rows.Count > 0)
                {
                    try
                    {
                        connection.Open();
                        SqlCommand command2 = new SqlCommand();
                        command2.Connection = connection;
                        command2.CommandText = "usp_deleteFriend";
                        command2.CommandType = CommandType.StoredProcedure;
                        command2.Parameters.AddWithValue("@accountID", accountID);
                        command2.Parameters.AddWithValue("@friendID", table.Rows[0]["accountId"]);
                        command2.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (SqlException ex)
                    {
                        errorMessagesBox error = new errorMessagesBox("there was an error deleting this friend");
                        error.Show();
                    }
                    LoadFriends();
                }
                else
                {
                    errorMessagesBox error = new errorMessagesBox("you are not friends with this user");
                    error.Show();
                }
            }
            else
            {
                areyousure.Close();
            }
        }

        private void sendButtonClick(object sender, RoutedEventArgs e)
        {
            //clearing the message box and sending it when the send button is clicked
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "usp_sendMessage";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@message", message.Text);
            command.Parameters.AddWithValue("@accountID", accountID);

            command.Parameters.AddWithValue("@groupID", groupID);
            command.ExecuteNonQuery();
            connection.Close();

            message.Text = "";
        }

        //being able to send messages when you click the enter button
        private void messageKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "usp_sendMessage";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@message", message.Text);
                command.Parameters.AddWithValue("@accountID", accountID);
                command.Parameters.AddWithValue("@groupID", groupID);
                command.ExecuteNonQuery();
                connection.Close();
                message.Text = "";
            }
        }

        //closing form/logging out
        private void chatRoom_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "usp_logout";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@accountID", accountID);
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}
