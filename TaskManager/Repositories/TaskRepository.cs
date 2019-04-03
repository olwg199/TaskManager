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

        public TaskDBRepository()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString);
            _cmd = _connection.CreateCommand();
        }

        public void Add(Task task)
        {
            _connection.Open();

            _cmd.CommandText = $@"INSERT INTO 
                                    Tasks(Id, Name, Date, ActivityStatus, Category, Description) 
                                VALUES 
                                    ('{task.Id.ToString()}', 
                                    '{task.Name}', 
                                    '{task.Date.ToString("yyyy-MM-dd")}', 
                                    '{task.IsActive}', 
                                    '{(int)task.Category}', 
                                    '{task.Description}')";

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
                                        Id = '{task.Id}'";

            _cmd.ExecuteNonQuery();

            _connection.Close();
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

        public void Delete(Task task)
        {
            _cmd.CommandText = $@"DELETE FROM 
                                    Tasks
                                WHERE
                                    Tasks.Id = '{task.Id}'";

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
                                    Tasks.Id = '{id}'";

            return ParseTasks().Find(t => t.Id == id);
        }

        public void AddOrUpdate(Task task)
        {
            _cmd.CommandText = $@"SELECT 
                                    * 
                                FROM 
                                    Tasks t 
                                WHERE 
                                    t.id = '{task.Id}'";

            _connection.Open();

            bool exist;

            using (SqlDataReader reader = _cmd.ExecuteReader())
            {
                exist = reader.Read();
            }

            _connection.Close();

            if (exist)//If the recrod exists
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
                    Task task = new Task(reader.GetGuid(DBTableIndex.Id));

                    task.Name = reader.GetString(DBTableIndex.Name);
                    task.Date = reader.GetDateTime(DBTableIndex.Date);
                    task.IsActive = reader.GetBoolean(DBTableIndex.IsActive);
                    task.Category = (ECategory)reader.GetInt32(DBTableIndex.Category);
                    task.Description = reader.IsDBNull(DBTableIndex.Description) ? "" : reader.GetString(DBTableIndex.Description);

                    taskList.Add(task);
                }
            }

            _connection.Close();

            return taskList;
        }
    }

    static class DBTableIndex
    {
        public const int Id = 0;
        public const int Name = 1;
        public const int Date = 2;
        public const int IsActive = 3;
        public const int Category = 4;
        public const int Description = 5;
    }
}
