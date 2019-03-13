using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public class Task
    {
        public Task() { }

        public Task(String name, DateTime date, bool activityStatus, string Category, string Description)
        {
            this.Name = name;
            this.Date = date;
            this.ActivityStatus = activityStatus;
            this.Category = Category;
            this.Description = Description;
        }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public bool ActivityStatus { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }
    }
}
