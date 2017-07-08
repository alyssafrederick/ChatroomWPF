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
    public partial class Login : Form
    {
        //sever=''; database=''; user=''; password=''
        SqlConnection connection = new SqlConnection("server=GMRDLT1; database=alyssaChatProgram; user=sa; password=GreatMinds110;");
        public Login()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            SignUp SignUp = new SignUp();
            Hide();
            SignUp.ShowDialog();
            Show();
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "usp_Login";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", username.Text.ToLower());
            command.Parameters.AddWithValue("@password", password.Text);
            
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                int id = int.Parse(table.Rows[0]["accountID"].ToString());
                chatRoom chat = new chatRoom(id);
                Hide();
                chat.ShowDialog();
                Close();
            }
            else
            {
                CustomMessageBox error = new CustomMessageBox("there was an error logging in");
                error.ShowDialog();
            }
            connection.Close();
        }
    }
}
