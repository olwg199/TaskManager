using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TaskManager.Repositories;

namespace TaskManager
{
    public partial class MainForm : Form
    {
        private IRepository _repository;
        private Task _currentTask;

        private TaskDetailsForm _taskDetailsForm;


        public MainForm()
        {
            InitializeComponent();

            _repository = new TaskDBRepository();
        }

        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            _taskDetailsForm = new TaskDetailsForm(new Task(monthCalendarChouseDate.SelectionRange.Start),
                _repository.Add);
            _taskDetailsForm.ShowDialog();
            
            UpdateTaskListView(_repository.GetByDate(monthCalendarChouseDate.SelectionStart));
        }

        private void monthCalendarChouseDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            UpdateTaskListView(_repository.GetByDate(monthCalendarChouseDate.SelectionStart));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateTaskListView(_repository.GetByDate(monthCalendarChouseDate.SelectionStart));
        }

        private void dataGridViewTasks_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var taskViewForm = new TaskDetailsForm(_repository.GetById(_currentTask.Id),
                _repository.Update);
            taskViewForm.ShowDialog();
            
            UpdateTaskView(_repository.GetById(_currentTask.Id), e);
        }

        private void buttonDeleteTask_Click(object sender, EventArgs e)
        {
            if (_currentTask != null)
            {
                _repository.Delete(_currentTask);
            }
            else
            {
                MessageBox.Show("Выберите задачу, которую хотите удалить", "Внимание");
            }


            UpdateTaskListView(_repository.GetByDate(monthCalendarChouseDate.SelectionStart));
        }

        private void dataGridViewTasks_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                _currentTask = _repository.GetById(Guid.Parse(_dataGridViewTasks.Rows[e.RowIndex].Cells[0].Value.ToString()));
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_repository.Save();
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

        private void UpdateTaskView(Task task, DataGridViewCellMouseEventArgs e)
        {
            _dataGridViewTasks.Rows[e.RowIndex].SetValues(task.Id,
                task.Name,
                task.Date.ToShortDateString(),
                EnumHelper<ECategory>.GetDisplayValue(task.Category),
                task.Description,
                task.IsActive);
        }
    }
}
