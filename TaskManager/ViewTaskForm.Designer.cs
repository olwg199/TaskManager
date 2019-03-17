namespace TaskManager
{
    partial class ViewTaskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.Label();
            this.Category = new System.Windows.Forms.Label();
            this.Desciption = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.dateTimePickerTimeOfTask = new System.Windows.Forms.DateTimePicker();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.checkBoxActivityStatus = new System.Windows.Forms.CheckBox();
            this.buttonSaveTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(20, 13);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(76, 17);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Название:";
            // 
            // Date
            // 
            this.Date.AutoSize = true;
            this.Date.Location = new System.Drawing.Point(50, 41);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(46, 17);
            this.Date.TabIndex = 1;
            this.Date.Text = "Дата:";
            // 
            // Category
            // 
            this.Category.AutoSize = true;
            this.Category.Location = new System.Drawing.Point(15, 69);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(81, 17);
            this.Category.TabIndex = 2;
            this.Category.Text = "Категория:";
            // 
            // Desciption
            // 
            this.Desciption.AutoSize = true;
            this.Desciption.Location = new System.Drawing.Point(18, 99);
            this.Desciption.Name = "Desciption";
            this.Desciption.Size = new System.Drawing.Size(78, 17);
            this.Desciption.TabIndex = 4;
            this.Desciption.Text = "Описание:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(102, 13);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(214, 22);
            this.textBoxName.TabIndex = 5;
            // 
            // dateTimePickerTimeOfTask
            // 
            this.dateTimePickerTimeOfTask.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTimeOfTask.Location = new System.Drawing.Point(102, 41);
            this.dateTimePickerTimeOfTask.Name = "dateTimePickerTimeOfTask";
            this.dateTimePickerTimeOfTask.Size = new System.Drawing.Size(214, 22);
            this.dateTimePickerTimeOfTask.TabIndex = 6;
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.Location = new System.Drawing.Point(102, 69);
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.Size = new System.Drawing.Size(214, 22);
            this.textBoxCategory.TabIndex = 7;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(102, 96);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(214, 246);
            this.textBoxDescription.TabIndex = 8;
            // 
            // checkBoxActivityStatus
            // 
            this.checkBoxActivityStatus.AutoSize = true;
            this.checkBoxActivityStatus.Location = new System.Drawing.Point(10, 352);
            this.checkBoxActivityStatus.Name = "checkBoxActivityStatus";
            this.checkBoxActivityStatus.Size = new System.Drawing.Size(136, 21);
            this.checkBoxActivityStatus.TabIndex = 9;
            this.checkBoxActivityStatus.Text = "Задача активна";
            this.checkBoxActivityStatus.UseVisualStyleBackColor = true;
            // 
            // buttonSaveTask
            // 
            this.buttonSaveTask.Location = new System.Drawing.Point(146, 348);
            this.buttonSaveTask.Name = "buttonSaveTask";
            this.buttonSaveTask.Size = new System.Drawing.Size(171, 28);
            this.buttonSaveTask.TabIndex = 10;
            this.buttonSaveTask.Text = "Сохранить";
            this.buttonSaveTask.UseVisualStyleBackColor = true;
            this.buttonSaveTask.Click += new System.EventHandler(this.buttonSaveTask_Click);
            // 
            // ViewTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 383);
            this.Controls.Add(this.buttonSaveTask);
            this.Controls.Add(this.checkBoxActivityStatus);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxCategory);
            this.Controls.Add(this.dateTimePickerTimeOfTask);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.Desciption);
            this.Controls.Add(this.Category);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.labelName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ViewTaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Задача";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.Label Category;
        private System.Windows.Forms.Label Desciption;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.DateTimePicker dateTimePickerTimeOfTask;
        private System.Windows.Forms.TextBox textBoxCategory;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.CheckBox checkBoxActivityStatus;
        private System.Windows.Forms.Button buttonSaveTask;
    }
}