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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace ChatRoomAlyssaUpdated
{
    public partial class MainWindow : Window
    {
        //sever=''; database=''; user=''; password=''
        SqlConnection connection = new SqlConnection("server=GMRDLT1; database=alyssaChatProgram; user=sa; password=GreatMinds110;");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "usp_Login";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", usernameBox.Text.ToLower());
            command.Parameters.AddWithValue("@password", passwordBox.Password);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                int id = int.Parse(table.Rows[0]["accountID"].ToString());

                #region pull all friends
                SqlCommand getFriendsCommand = new SqlCommand();
                getFriendsCommand.Connection = connection;
                getFriendsCommand.CommandText = "usp_getFriends";
                getFriendsCommand.CommandType = CommandType.StoredProcedure;
                getFriendsCommand.Parameters.AddWithValue("@accountID", id);

                SqlDataAdapter getFriendsAdapter = new SqlDataAdapter(getFriendsCommand);
                DataTable friendsTable = new DataTable();
                adapter.Fill(table);

                foreach (DataRow friendRow in friendsTable.Rows)
                {
                    int friendID = Convert.ToInt32(friendRow["accountID"]);
                    string friendName = friendRow["name"].ToString();
                    bool isOnline = Convert.ToBoolean(friendRow["isOnline"]);

                    User user = new User(friendID, friendName, isOnline);

                    if (!Global.Users.ContainsKey(friendID))
                    {
                        Global.Users.Add(friendID, user);
                    }
                }

                #endregion

                #region pull all groups for the current users.
                SqlCommand getGroupCommand = new SqlCommand();
                getGroupCommand.Connection = connection;
                getGroupCommand.CommandText = "usp_getAllChatGroups";
                getGroupCommand.CommandType = CommandType.StoredProcedure;
                getGroupCommand.Parameters.AddWithValue("@accountID", id);

                adapter = new SqlDataAdapter(getGroupCommand);

                SqlDataAdapter getGroupAdapter = new SqlDataAdapter(getGroupCommand);
                DataTable groupTable = new DataTable();
                adapter.Fill(groupTable);

                foreach (DataRow groupRow in groupTable.Rows)
                {
                    int groupID = Convert.ToInt32(groupRow["groupID"]);
                    string groupName = groupRow["name"].ToString();

                    Group group = new Group(groupID, groupName);
                    if (!Global.Groups.ContainsKey(groupID))
                    {
                        Global.Groups.Add(groupID, group);
                    }
                }
                #endregion

                foreach (Group group in Global.Groups.Values)
                {
                    SqlCommand getUsersInGroupCommand = new SqlCommand();
                    getUsersInGroupCommand.Connection = connection;
                    getUsersInGroupCommand.CommandText = "usp_getGroupUsers";
                    getUsersInGroupCommand.CommandType = CommandType.StoredProcedure;
                    getUsersInGroupCommand.Parameters.AddWithValue("GroupID", group.GroupID);

                    SqlDataAdapter getsUsersInGroupAdapter = new SqlDataAdapter(getUsersInGroupCommand);
                    DataTable getsUsersInGroupTable = new DataTable();
                    getsUsersInGroupAdapter.Fill(getsUsersInGroupTable);

                    foreach (DataRow row in getsUsersInGroupTable.Rows)
                    {
                        int userID = Convert.ToInt32(row["accountID"]);

                        User user;
                        if (Global.Users.ContainsKey(userID))
                        {
                            user = Global.Users[userID];
                        }
                        else
                        {
                            command = new SqlCommand();
                            command.Connection = connection;
                            command.CommandText = "usp_getUsernameByID";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@accountID", userID);
                            SqlDataAdapter getUsernameByIDadapter = new SqlDataAdapter(command);
                            getUsernameByIDadapter.Fill(table);

                            string name = table.Rows[0]["username"].ToString();
                            user = new User(userID, name, false);
                            //add user to Global.Users
                        }

                        if (!group.ChatAccess.ContainsKey(userID))
                        {
                            //add user to chat access.
                        }
                    }

                }




                chatroom chat = new chatroom(id);
                Hide();
                chat.ShowDialog();
                Close();
            }
            else
            {
                errorMessagesBox messageBox = new errorMessagesBox("there was an error logging in");
                messageBox.ShowDialog();
            }
            connection.Close();
        }

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            signinForm signup = new signinForm();
            signup.Show();
        }
    }
}
