using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TaskManager
{
    public class TaskManager
    {
        private SqlConnection _connection;
        private List<Task> _tasks;

        public TaskManager(SqlConnection connection)
        {
            _tasks = new List<Task>();
            _connection = connection;
        }

        public List<Task> Tasks
        {
            get { return _tasks; }
        }

        public void addTask(Task task)
        {
            if (task.IsActive)
            {
                _tasks.Insert(0, task);
            }
            else
            {
                _tasks.Insert(_tasks.Count, task);
            }
        }

        public void editTask(Task task)
        {
            Task currentTask = _tasks.Find(t => t.Id == task.Id);
            int currentTaskIndex = _tasks.IndexOf(currentTask);

            _tasks[currentTaskIndex] = task;
        }

        public List<Task> GetTasks(DateTime date)
        {
            _tasks = new List<Task>();
            SqlCommand cmd = _connection.CreateCommand();

            cmd.CommandText = @"SELECT
                                    *
                                FROM
                                    Tasks t
                                LEFT JOIN Category cat
                                ON cat.Id = t.category
                                WHERE
                                    t.date = '" + String.Format("{0}-{1}-{2}", date.Year, date.Month, date.Day) + @"'";

            _connection.Open();

            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Task task = new Task();

                    task.Id = reader.GetInt32(0);
                    task.Name = reader.GetString(1);
                    task.Date = reader.GetDateTime(2);
                    task.IsActive = reader.GetBoolean(3);
                    task.Category = reader.IsDBNull(4) ? "" : reader.GetInt32(4).ToString();
                    task.Description = reader.GetString(5);

                    addTask(task);
                }
            }

            _connection.Close();

            return _tasks;
        }

        public void SaveTasks()
        {
            SqlCommand cmd = _connection.CreateCommand();
            bool flagExistence; 

            foreach(Task task in _tasks)
            {
                cmd.CommandText = string.Format("SELECT * FROM Tasks t WHERE t.id = {0}", task.Id);

                _connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    flagExistence = reader.Read();
                }

                if (flagExistence)//If the recrod exists
                {
                    cmd.CommandText = String.Format("UPDATE Tasks " +
                        "SET name = '{0}', date = '{1}', activ = '{2}', category = '{3}', description = '{4}' WHERE id = {5}",
                        task.Name,
                        String.Format("{0}-{1}-{2}", task.Date.Year, task.Date.Month, task.Date.Day),
                        task.IsActive,
                        1,
                        task.Description,
                        task.Id);

                    cmd.ExecuteNonQuery();
                }
                else//If the record does not exist
                {
                    cmd.CommandText = String.Format("INSERT INTO Tasks(name, date, activ, category, description) " +
                        "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                        task.Name,
                        String.Format("{0}-{1}-{2}", task.Date.Year, task.Date.Month, task.Date.Day),
                        task.IsActive,
                        1,
                        task.Description);

                    cmd.ExecuteNonQuery();
                }

                _connection.Close();
            }
            
        }
    }
}
