using System;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class ViewTaskForm : Form
    {
        private readonly Task _currentTask;
        private readonly Action<Task> _updateTaskListDelegate;

        public ViewTaskForm(Action<Task> updateTaskListDelegate, Task task)
        {
            InitializeComponent();

            this._updateTaskListDelegate = updateTaskListDelegate;
            _currentTask = task;

            textBoxName.Text = task.Name;
            dateTimePickerTimeOfTask.Value = task.Date;
            textBoxCategory.Text = task.Category;
            textBoxDescription.Text = task.Description;
            checkBoxActivityStatus.Checked = task.IsActive;
        }

        private void buttonSaveTask_Click(object sender, EventArgs e)
        {
            _currentTask.Date = dateTimePickerTimeOfTask.Value;
            _currentTask.IsActive = checkBoxActivityStatus.Checked;
            _currentTask.Name = textBoxName.Text;
            _currentTask.Category = textBoxCategory.Text;
            _currentTask.Description = textBoxDescription.Text;

            _updateTaskListDelegate(_currentTask);

            this.Hide();
        }
    }
}
