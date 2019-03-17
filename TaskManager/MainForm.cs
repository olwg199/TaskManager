using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TaskManager
{
    public partial class MainForm : Form
    {
        private TaskManager tm;

        private SqlConnection _connection;
        private string _connectionString = @"Data Source=DESKTOP-IHR3MN2\SQLEXPRESS;Initial Catalog=TaskManager;Integrated Security=True";

        private ViewTaskForm _addTaskForm;

        public MainForm()
        {
            InitializeComponent();

            _connection = new SqlConnection(_connectionString);
            tm = new TaskManager(_connection);
        }

        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            _addTaskForm = new ViewTaskForm(tm.addTask,
                new Task(monthCalendarChouseDate.SelectionRange.Start));
            _addTaskForm.ShowDialog();

            tm.SaveTasks();
            UpdateTaskListView(tm.GetTasks(monthCalendarChouseDate.SelectionRange.Start));
        }

        private void monthCalendarChouseDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            tm.SaveTasks();
            UpdateTaskListView(tm.GetTasks(monthCalendarChouseDate.SelectionRange.Start));            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Hide();

            AuthorizationForm authorizationForm = new AuthorizationForm(_connection);
            authorizationForm.ShowDialog(this);
            
            authorizationForm.Close();
            UpdateTaskListView(tm.GetTasks(monthCalendarChouseDate.SelectionRange.Start));
        }

        private void dataGridViewTasks_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ViewTaskForm viewTaskForm = new ViewTaskForm(tm.editTask,
                tm.Tasks[e.RowIndex]);
            viewTaskForm.ShowDialog();

            tm.SaveTasks();
            UpdateTaskListView(tm.GetTasks(monthCalendarChouseDate.SelectionRange.Start));
        }

        private void UpdateTaskListView(List<Task> tasks)
        {
            dataGridViewTasks.Rows.Clear();

            foreach(Task ts in tasks)
            {
                dataGridViewTasks.Rows.Add(ts.Name,
                    ts.Date.ToShortDateString(),
                    ts.Category,
                    ts.Description,
                    ts.IsActive);
            }            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            tm.SaveTasks();
        }
    }
}
