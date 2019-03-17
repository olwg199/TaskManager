using System;

namespace TaskManager
{
    public class Task
    {
        public Task()
        {
            this.Id = -1;
            this.IsActive = true;
        }

        public Task(DateTime date) : this()
        {
            this.Date = date;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public bool IsActive { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }
    }
}
