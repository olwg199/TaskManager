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
            
            _taskManager = new TaskManager();
        }

        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            _taskDetailsForm = new TaskDetailsForm(new Task(monthCalendarChouseDate.SelectionRange.Start),
                _taskManager.AddTask);
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
            var taskViewForm = new TaskDetailsForm(_taskManager.GetById(_dataGridViewTasks.Rows[e.RowIndex].Cells[0].Value.ToString()),
                _taskManager.EditTask);
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
                _dataGridViewTasks.Rows.Add(ts.Id,
                    ts.Name,
                    ts.Date.ToShortDateString(),
                    EnumHelper<ECategory>.GetDisplayValue(ts.Category),
                    ts.Description,
                    ts.IsActive);
            }
        }
    }
}
