using System;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TaskManager
{
    public partial class AuthorizationForm : Form
    {
        private SqlConnection _connection;

        public AuthorizationForm(SqlConnection connection)
        {
            InitializeComponent();

            _connection = connection;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text.Length == 0 || textBoxPassword.Text.Length == 0)
            {
                MessageBox.Show("Вы не ввели свой никнейм или пароль.", "Внимание");
                return;
            }

            if(checkUser(textBoxUsername.Text, textBoxPassword.Text))
            {
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль.", "Внимание");
            }
        }

        private void AuthorizationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing) return;

            Environment.Exit(0);
        }

        private bool checkUser(string username, string password)
        {
            bool result = false;
            SqlCommand cmd = _connection.CreateCommand();

            cmd.CommandText = @"SELECT
                                    *
                                FROM
                                    Users users
                                WHERE
                                    Username = '" + username + @"'
                                    AND
                                    Password = '" + password + "'";

            _connection.Open();

            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.GetString(1) == username && reader.GetString(2) == password)
                    {
                        result = true;
                    }
                }
            }

            _connection.Close();

            return result;
        }
    }
}
