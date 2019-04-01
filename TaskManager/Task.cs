using System;

namespace TaskManager
{
    public class Task
    {
        public Task()
        {
            Id = Guid.NewGuid();
            IsActive = true;
        }

        public Task(DateTime date) : this()
        {
            this.Date = date;
        }

        public Task(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public bool IsActive { get; set; }

        public ECategory Category { get; set; }

        public string Description { get; set; }
    }
}
