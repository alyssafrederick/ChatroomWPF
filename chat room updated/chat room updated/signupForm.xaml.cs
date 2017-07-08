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
    public partial class signinForm : Window
    {
        SqlConnection connection = new SqlConnection("server=GMRDLT1; database=alyssaChatProgram; user=sa; password=GreatMinds110;");

        public signinForm()
        {
            InitializeComponent();
            //StartPosition = FormStartPosition.CenterScreen;
        }

        private void signInButtonClicked(object sender, RoutedEventArgs e)
        {
            Close();
        }

        DateTime birthday;
        private string checkAccount()
        {
            string answer = "";
            birthday = new DateTime();

            connection.Open();
            SqlCommand userCommand = new SqlCommand();
            userCommand.Connection = connection;
            userCommand.CommandType = CommandType.StoredProcedure;
            userCommand.CommandText = "usp_checkUsername";
            userCommand.Parameters.AddWithValue("@username", usernameBox.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(userCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            connection.Close();

            if (dataTable.Rows.Count > 0)
            {
                answer += "username already exists!\n";
            }
            if (passwordBox.Password != confirmPasswordBox.Password)
            {
                answer += "passwords do not match!\n";
            }
            if (passwordBox.Password.Trim().Length <= 2)
            {
                answer += "password must be greater than than characters!\n";
            }
            if (!emailBox.Text.Contains("@") || !emailBox.Text.Substring(emailBox.Text.LastIndexOf('@'), emailBox.Text.Length - emailBox.Text.LastIndexOf('@')).Contains("."))
            {
                answer += "email is invalid!\n";
            }
            if (!DateTime.TryParse(birthMonthBox.Text + "-" + birthDateBox.Text + "-" + birthYearBox.Text, out birthday))
            {
                answer += "birthday format is wrong!\n";
            }
            return answer;
        }

        private void confirmButtonClicked(object sender, RoutedEventArgs e)
        {
            string errors = checkAccount();
            if (errors == "")
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "usp_addUser";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", nameBox.Text);
                command.Parameters.AddWithValue("@username", usernameBox.Text);
                command.Parameters.AddWithValue("@password", passwordBox.Password);
                command.Parameters.AddWithValue("@email", emailBox.Text);
                command.Parameters.AddWithValue("@birthday", birthday.ToShortDateString());
                command.ExecuteNonQuery();
                connection.Close();

                errorMessagesBox messageBox = new errorMessagesBox("account created");
                messageBox.ShowDialog();
                Close();
            }
            else
            {
                errorMessagesBox messageBox = new errorMessagesBox(errors);
                messageBox.ShowDialog();
            }
        }


    }
}

