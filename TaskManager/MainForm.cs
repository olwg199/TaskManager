using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            AddTaskForm addTaskForm = new AddTaskForm();
            addTaskForm.Show();
        }

        private void monthCalendarChouseDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            MessageBox.Show(monthCalendarChouseDate.SelectionRange.Start.ToShortDateString());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Hide();
            AuthorizationForm authorizationForm = new AuthorizationForm();
            authorizationForm.ShowDialog(this);
            this.Text = authorizationForm.SelectedNickname;
            authorizationForm.Close();
        }

        private void updateTable(List<Task> tasks)
        {
            foreach(Task task in tasks)
            {
                
            }
        }
    }
}
