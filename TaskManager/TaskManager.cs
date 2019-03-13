using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TaskManager
{
    public class TaskManager
    {
        public List<Task> _tasks;

        public TaskManager()
        {
            _tasks = new List<Task>();
        }

        public void addTask(Task task)
        {
            _tasks.Add(task);
        }

        public Task getTaskFromFile(FileInfo task)
        {
            return new Task();
        }

        public Task getTaskFromXML(XmlDocument task)
        {
            return new Task();
        }

        private void saveTaskToFile(Task task)
        {

        }

        private void saveTaskToXml(Task task)
        {

        }
    }
}
