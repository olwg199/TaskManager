using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TaskManager.entity;

namespace TaskManager
{
    public partial class MainForm : Form
    {
        private TaskManager _taskManager;        

        private TaskDetailsForm _taskDetailsForm;

        public MainForm()
        {
            InitializeComponent();

            //object[] category = typeof(ECategory).GetField(ECategory.Others.ToString()).GetCustomAttributes(typeof(Category), false);

            //MessageBox.Show(category[category.Length - 1].ToString());
            
            _taskManager = new TaskManager();
        }

        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            _taskDetailsForm = new TaskDetailsForm(_taskManager.AddTask,
                new Task(monthCalendarChouseDate.SelectionRange.Start));
            _taskDetailsForm.ShowDialog();

            _taskManager.SaveTasks();
            UpdateTaskListView(_taskManager.GetByDate(monthCalendarChouseDate.SelectionStart));
        }

        private void monthCalendarChouseDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            _taskManager.SaveTasks();
            UpdateTaskListView(_taskManager.GetByDate(monthCalendarChouseDate.SelectionStart));            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateTaskListView(_taskManager.GetByDate(monthCalendarChouseDate.SelectionStart));
        }

        private void dataGridViewTasks_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var taskViewForm = new TaskDetailsForm(_taskManager.EditTask,
                _taskManager.Get()[e.RowIndex]);
            taskViewForm.ShowDialog();

            _taskManager.SaveTasks();
            UpdateTaskListView(_taskManager.GetByDate(monthCalendarChouseDate.SelectionStart));
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            _taskManager.SaveTasks();
        }

        private void UpdateTaskListView(List<Task> tasks)
        {
            _dataGridViewTasks.Rows.Clear();

            foreach (Task ts in tasks)
            {
                _dataGridViewTasks.Rows.Add(ts.Name,
                    ts.Date.ToShortDateString(),
                    ts.Category,
                    ts.Description,
                    ts.IsActive);
            }
        }
    }
}
