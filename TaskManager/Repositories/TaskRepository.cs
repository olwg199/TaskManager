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

        public TaskDBRepository() {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString);
            _cmd = _connection.CreateCommand();
        }

        public List<Task> Get()
        {
            var taskList = new List<Task>();
            _cmd = _connection.CreateCommand();

            _cmd.CommandText = @"SELECT
                                    *
                                FROM
                                    Tasks";

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

        public void Save(List<Task> tasks)
        {
            _cmd = _connection.CreateCommand();
            bool flagExistence;

            foreach (Task task in tasks)
            {
                _cmd.CommandText = string.Format(@"SELECT 
                                                    * 
                                                FROM 
                                                    Tasks t 
                                                WHERE 
                                                    t.id = '{0}'", 
                                                    task.Id.ToString());

                _connection.Open();

                using (SqlDataReader reader = _cmd.ExecuteReader())
                {
                    flagExistence = reader.Read();
                }

                if (flagExistence)//If the recrod exists
                {
                    _cmd.CommandText = String.Format(@"UPDATE 
                                                        Tasks 
                                                    SET 
                                                        Name = '{0}', 
                                                        Date = '{1}', 
                                                        ActivityStatus = '{2}', 
                                                        Category = '{3}', 
                                                        Description = '{4}' 
                                                    WHERE 
                                                        id = '{5}'",
                                                        task.Name,
                                                        task.Date.ToString("yyyy-MM-dd"),
                                                        task.IsActive,
                                                        (int)task.Category,
                                                        task.Description,
                                                        task.Id.ToString());

                    _cmd.ExecuteNonQuery();
                }
                else//If the record does not exist
                {
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
                }

                _connection.Close();
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
