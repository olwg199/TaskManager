using System;
using System.IO;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        public string SelectedNickname
        {
            get
            {
                return textBoxNickname.Text;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxNickname.Text.Length == 0)
            {
                MessageBox.Show("Вы не ввели свой никнейм.", "Внимание");
                return;
            }

            if (Directory.Exists(string.Format("data/{0}", textBoxNickname.Text)))
            {
                MessageBox.Show("Такой пользователь уже существует.\nЕсли это Вы, то выберите опцию 'Войти' в окне авторизации.", "Неверное действие");
            }            
            else
            {
                Directory.CreateDirectory(string.Format("data/{0}", textBoxNickname.Text));
                this.Hide();
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxNickname.Text.Length == 0)
            {
                MessageBox.Show("Вы не ввели свой никнейм.", "Внимание");
                return;
            }

            if (Directory.Exists(string.Format("data/{0}", textBoxNickname.Text)))
            {
                this.Hide();
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует.\nВыберите опцию 'Добавить' в окне авторизации.", "Неверное действие");
            }
        }

        private void AuthorizationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing) return;

            Environment.Exit(0);
        }
    }
}
