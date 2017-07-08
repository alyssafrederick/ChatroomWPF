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
    public partial class SignUp : Form
    {
        SqlConnection connection = new SqlConnection("server=GMRDLT1; database=alyssaChatProgram; user=sa; password=GreatMinds110;");

        public SignUp()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void signInButton_Click(object sender, EventArgs e)
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
            userCommand.Parameters.AddWithValue("@username", username.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(userCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            connection.Close();

            if (dataTable.Rows.Count > 0)
            {
                answer += "username already exists!\n";
            }
            if (password.Text != confirmedPassword.Text)
            {
                answer += "passwords do not match!\n";
            }
            if (password.Text.Trim().Length <= 2)
            {
                answer += "password must be greater than 2 characters!\n";
            }
            if (!email.Text.Contains("@") || !email.Text.Substring(email.Text.LastIndexOf('@'), email.Text.Length - email.Text.LastIndexOf('@')).Contains("."))
            {
                answer += "email is invalid format!\n";
            }
            if (!DateTime.TryParse(birthMonth.Text + "-" + birthDate.Text + "-" + birthYear.Text, out birthday))
            {
                answer += "birthday format wrong!\n";
            }
            return answer;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            string errors = checkAccount();
            if (errors == "")
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "usp_addUser";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", name.Text);
                command.Parameters.AddWithValue("@username", username.Text);
                command.Parameters.AddWithValue("@password", password.Text);
                command.Parameters.AddWithValue("@email", email.Text);
                command.Parameters.AddWithValue("@birthday", birthday.ToShortDateString());
                command.ExecuteNonQuery();
                connection.Close();
                //@name		varchar(50),
                //@username	varchar(50),
                //@password	varchar(50),
                //@email		varchar(MAX),
                //@birthday	smalldatetime

                CustomMessageBox messageBox = new CustomMessageBox("account created");
                messageBox.ShowDialog();
                Close();
            }
            else
            {
                CustomMessageBox messageBox = new CustomMessageBox(errors);
                messageBox.ShowDialog();
            }
        }
    }
}
