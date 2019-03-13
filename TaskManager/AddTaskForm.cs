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
    public partial class AddTaskForm : Form
    {
        public Task Task { get; set; }

        public AddTaskForm()
        {
            InitializeComponent();
            checkBoxActivityStatus.Checked = true;
        }

        public AddTaskForm(Task task)
        {
            InitializeComponent();
            textBoxName.Text = task.Name;
            dateTimePickerTimeOfTask.Value = task.Date;
            textBoxCategory.Text = task.Category;
            textBoxDescription.Text = task.Description;
        }

        private void buttonAddOrEdit_Click(object sender, EventArgs e)
        {
            Task = new Task(textBoxName.Text,
                dateTimePickerTimeOfTask.Value.Date,
                checkBoxActivityStatus.Checked,
                textBoxCategory.Text,
                textBoxDescription.Text);
        }
    }
}
