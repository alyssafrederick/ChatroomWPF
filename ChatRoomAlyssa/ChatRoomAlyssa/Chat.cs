using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ChatRoomAlyssa
{
    public partial class chatRoom : Form
    {
        SqlConnection connection = new SqlConnection("server=GMRDLT1; database=alyssaChatProgram; user=sa; password=GreatMinds110;");

        DateTime lastRecieved;

        int accountID;
        int messageID;
        int groupID;
        List<Button> currentFriends = new List<Button>();

        public chatRoom(int id)
        {
            lastRecieved = DateTime.Now;
            accountID = id;
            messageID = id;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            LoadFriends();
            LoadChats();
        }

        //loading things
        /*done*/public void LoadChats()/////////////make the chat names actual buttons so when they clikck it you can get the details of the chat///////////////////
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

            int y = 0;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                Button chatbutton = new Button();
                chatbutton.Location = new Point(-1, y);
                string chatname = table.Rows[i]["name"].ToString();

                chatbutton.Tag = Convert.ToInt32(table.Rows[i]["groupID"]);

                chatbutton.Text = "";

                groupID = Convert.ToInt32(table.Rows[i]["groupID"]);

                //putting the chatname into the button
                if (chatname.Length < 15)
                {
                    chatbutton.Text = chatname;
                }
                else
                {
                    for (int ii = 0; ii < 11; ii++)
                    {
                        chatbutton.Text += chatname[ii];
                    }
                    chatbutton.Text += "...";
                }

                //if (chatbutton.Click)
                //{
                //    load
                //}

                //making the button pretty
                chatbutton.Size = new System.Drawing.Size(205, 35);
                chatbutton.FlatStyle = sendButton.FlatStyle;
                chatbutton.FlatAppearance.MouseDownBackColor = sendButton.FlatAppearance.MouseDownBackColor;
                chatbutton.FlatAppearance.BorderColor = sendButton.FlatAppearance.BorderColor;
                chatbutton.BackColor = sendButton.BackColor;      
                chatbutton.Font = sendButton.Font;
                chatbutton.ForeColor = sendButton.ForeColor;
                yourchats.Controls.Add(chatbutton);

                //making the next button the right distance apart
                y += 34;
            }
            connection.Close();
        }

        /*done*/ public void LoadFriends()
        {
            connection.Open();

            foreach (Button b in currentFriends)
            {
                friendsPanel.Controls.Remove(b);
            }

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "usp_getFriends";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@accountID", accountID);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            int y = friendsHeading.Location.Y + friendsHeading.Height;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                //setting the friends buttons
                Button friendButton = new Button();
                friendButton.Location = new Point(-1, y);
                string username = table.Rows[i]["username"].ToString();
                friendButton.Text = "";

                //putting the friends username into the button
                if (username.Length < 15)
                {
                    friendButton.Text = username;
                }
                else
                {
                    for (int ii = 0; ii < 11; ii++)
                    {
                        friendButton.Text += username[ii];
                    }
                    friendButton.Text += "...";
                }

                //making the button pretty
                friendButton.Size = new System.Drawing.Size(150, 35);
                friendButton.FlatStyle = sendButton.FlatStyle;
                friendButton.FlatAppearance.MouseDownBackColor = sendButton.FlatAppearance.MouseDownBackColor;
                friendButton.FlatAppearance.BorderColor = sendButton.FlatAppearance.BorderColor;
                friendButton.BackColor = sendButton.BackColor;
                friendButton.Font = sendButton.Font;
                friendButton.ForeColor = sendButton.ForeColor;

                //if the friend is logged in have the backcolor be different
                if (table.Rows[i]["isOnline"].ToString() == "True")
                {
                    friendButton.BackColor = sendButton.FlatAppearance.MouseOverBackColor;
                }

                friendButton.Font = sendButton.Font;
                friendButton.ForeColor = sendButton.ForeColor;

                //making the next button the right distance apart
                y += 34;

                friendButton.Click += new EventHandler(friendButton_Click);
                currentFriends.Add(friendButton);
                friendsPanel.Controls.Add(friendButton);

            }
            connection.Close();
        }

        //closing the chat room
        /*done*/ private void chatRoom_FormClosing(object sender, FormClosingEventArgs e)
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

        //friend related things
        /*done*/private void friendsPopOutTimer_Tick(object sender, EventArgs e)
        {
            if (Cursor.Position.X - DesktopLocation.X > Width - 10 || Cursor.Position.X - DesktopLocation.X > friendsPanel.Location.X)
            {
                if (friendsPanel.Location.X > Width - friendsPanel.Width)
                {
                    friendsPanel.Location = new Point(friendsPanel.Location.X - 10, friendsPanel.Location.Y);
                    if (friendsPanel.Location.X < Width - friendsPanel.Width)
                    {
                        friendsPanel.Location = new Point(Width - friendsPanel.Width, friendsPanel.Location.Y);
                    }
                }
            }
            else if (friendsPanel.Location.X < Width)
            {
                friendsPanel.Location = new Point(friendsPanel.Location.X + 10, friendsPanel.Location.Y);
            }
        }

        /*done*/private void friendButton_Click(object sender, EventArgs e)
        {
            yesnoMessageBox messageBox = new yesnoMessageBox("would you like to create a chat with this person?");
            messageBox.ShowDialog();

            if (messageBox.yes == true)
            {
                InputForm newform = new InputForm("what would you like to name this group", "group name", "okay");
                newform.ShowDialog();
                string groupname = newform.SubmittedText;

                InputForm form = new InputForm("what would you like the password to be", "password", "all good");
                form.ShowDialog();
                string password = form.SubmittedText;

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

                int newGroupID = int.Parse(table.Rows[0]["groupID"].ToString());
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "usp_addGroupAccess";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@accountID", accountID);
                command.Parameters.AddWithValue("@groupID", newGroupID);
                command.ExecuteNonQuery();

                string username = ((Button)sender).Text;
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "usp_getIDbyUsername";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@username", username);
                command.ExecuteNonQuery();

                connection.Close();

                LoadChats();
            }
        }

        /*done*/private void addFriendButton_Click(object sender, EventArgs e)
        {
            InputForm form = new InputForm("add friends", "add friend", "add");
            form.ShowDialog();
            string friendUsername = form.SubmittedText;

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
                    command2.CommandText = "usp_addFriend";
                    command2.CommandType = CommandType.StoredProcedure;
                    command2.Parameters.AddWithValue("@accountID", accountID);
                    command2.Parameters.AddWithValue("@friendID", table.Rows[0]["accountID"].ToString());
                    command2.ExecuteNonQuery();
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    CustomMessageBox error = new CustomMessageBox("there was an error adding this friend");
                    error.Show();
                }
                LoadFriends();
            }
            else
            {
                CustomMessageBox command2 = new CustomMessageBox("username doesn't exist");
                command2.ShowDialog();
            }
        }

        /*done*/private void deleteFriendButton_Click(object sender, EventArgs e)
        {
            InputForm form = new InputForm("delete friends", "delete friend", "delete");
            form.ShowDialog();
            string friendUsername = form.SubmittedText;

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
                    CustomMessageBox error = new CustomMessageBox("there was an error deleting this friend");
                    error.Show();
                }
                LoadFriends();
            }
            else
            {
                CustomMessageBox error = new CustomMessageBox("you are not friends with this user");
                error.Show();
            }
        }

        //message and send related things
        /*done*/ private void messageTimer_Tick(object sender, EventArgs e)
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
                    messages.Text += table.Rows[i]["message"].ToString() + "\n";
                    
                    lastRecieved = lastrecieved;
                }
            }

            connection.Close();
        }

        /*done*/ private void sendButton_Click(object sender, EventArgs e)
        {
            //clearing the message box and sending it when the send button is clicked
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "usp_sendMessage";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@message", messageBox.Text);
            command.Parameters.AddWithValue("@accountID", accountID);

            command.Parameters.AddWithValue("@groupID", groupID);
            command.ExecuteNonQuery();
            connection.Close();
            messageBox.Text = "";
        }

        /*done*/ private void messageBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "usp_sendMessage";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@message", messageBox.Text);
                command.Parameters.AddWithValue("@accountID", accountID);
                command.Parameters.AddWithValue("@groupID", groupID);
                command.ExecuteNonQuery();
                connection.Close();
                messageBox.Text = "";
            }
        }
    }
}
