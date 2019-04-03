using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

namespace TaskManager.Repositories
{
    public class TaskDBRepository : IRepository
    {
        private readonly SqlConnection _connection;            
        private SqlCommand _cmd;

        public void Add(Task task)
        {
            _connection.Open();

            _cmd.CommandText = String.Format(@"INSERT INTO 
                                                        Tasks(Id, Name, Date, ActivityStatus, Category, Description) 
                                                    VALUES 
                                                        ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                                                    task.Id.ToString(),
                                                    task.Name,
                                                    task.Date.ToString("yyyy-MM-dd"),
                                                    task.IsActive,
                                                    (int)task.Category,
                                                    task.Description);

            _cmd.ExecuteNonQuery();

            _connection.Close();
        }

        public void Update(Task task)
        {
            _connection.Open();

            _cmd.CommandText = $@"UPDATE
                                        Tasks
                                    SET
                                        Name = '{task.Name}',
                                        Date = '{task.Date.ToString("yyyy-MM-dd")}',
                                        ActivityStatus = '{task.IsActive}',
                                        Category = '{(int)task.Category}',
                                        Description = '{task.Description}'
                                    WHERE
                                        Id = '{task.Id.ToString()}'";

            _cmd.ExecuteNonQuery();

            _connection.Close();
        }

        public TaskDBRepository() {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString);
            _cmd = _connection.CreateCommand();
        }

        public List<Task> Get()
        {
            var taskList = new List<Task>();

            _cmd.CommandText = @"SELECT
                                    *
                                FROM
                                    Tasks";

            return ParseTasks();
        }

        public void Save(List<Task> tasks)
        {
            foreach (Task task in tasks)
            {
                Edit(task);
            }
        }

        public void Delete(Task task)
        {
            _cmd.CommandText = $@"DELETE FROM 
                                    Tasks
                                WHERE
                                    Tasks.Id = '{task.Id.ToString()}'";

            _connection.Open();

            _cmd.ExecuteNonQuery();
            
            _connection.Close();
        }

        public List<Task> GetByDate(DateTime date)
        {
            _cmd.CommandText = $@"SELECT
                                    *
                                FROM
                                    Tasks
                                WHERE
                                    Tasks.Date = '{date.ToString("yyyy-MM-dd")}'";

            return ParseTasks();
        }

        public Task GetById(Guid id)
        {
            _cmd.CommandText = $@"SELECT
                                    *
                                FROM
                                    Tasks
                                WHERE
                                    Tasks.Id = '{id.ToString()}'";

            return ParseTasks().Find(t => t.Id == id);
        }

        public void Edit(Task task)
        {
            _cmd.CommandText = string.Format(@"SELECT 
                                                    * 
                                                FROM 
                                                    Tasks t 
                                                WHERE 
                                                    t.id = '{0}'",
                                                    task.Id.ToString());

            _connection.Open();

            bool flagExistence;

            using (SqlDataReader reader = _cmd.ExecuteReader())
            {
                flagExistence = reader.Read();
            }

            _connection.Close();

            if (flagExistence)//If the recrod exists
            {
                Update(task);
            }
            else//If the record does not exist
            {
                Add(task);
            }

            _connection.Close();
        }

        private List<Task> ParseTasks()
        {
            var taskList = new List<Task>();

            _connection.Open();

            using (SqlDataReader reader = _cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Task task = new Task(reader.GetGuid((int)DBTableIndex.Id));

                    task.Name = reader.GetString((int)DBTableIndex.Name);
                    task.Date = reader.GetDateTime((int)DBTableIndex.Date);
                    task.IsActive = reader.GetBoolean((int)DBTableIndex.Activ);
                    task.Category = (ECategory)reader.GetInt32((int)DBTableIndex.Category);
                    task.Description = reader.IsDBNull((int)DBTableIndex.Description) ? "" : reader.GetString((int)DBTableIndex.Description);

                    taskList.Add(task);
                }
            }

            _connection.Close();

            return taskList;
        }
    }

    enum DBTableIndex
    {
        Id,
        Name,
        Date,
        Activ,
        Category,
        Description
    }
}
