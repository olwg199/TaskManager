﻿using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

namespace TaskManager.Repositories
{
    public class TaskDBRepository : ITaskRepository
    {
        private readonly SqlConnection _connection;

        public TaskDBRepository()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString);
        }

        public void Add(Task task)
        {
            _connection.Open();

            SqlCommand cmd = _connection.CreateCommand();

            cmd.CommandText = $@"INSERT INTO 
                                    Tasks(Id, Name, Date, ActivityStatus, Category, Description) 
                                VALUES 
                                    ('{task.Id}', 
                                    '{task.Name}', 
                                    '{task.Date.ToString("yyyy-MM-dd")}', 
                                    '{task.IsActive}', 
                                    '{(int)task.Category}', 
                                    '{task.Description}')";

            cmd.ExecuteNonQuery();

            _connection.Close();
        }

        public void Update(Task task)
        {
            _connection.Open();

            SqlCommand cmd = _connection.CreateCommand();

            cmd.CommandText = $@"UPDATE
                                        Tasks
                                    SET
                                        Name = '{task.Name}',
                                        Date = '{task.Date.ToString("yyyy-MM-dd")}',
                                        ActivityStatus = '{task.IsActive}',
                                        Category = '{(int)task.Category}',
                                        Description = '{task.Description}'
                                    WHERE
                                        Id = '{task.Id}'";

            cmd.ExecuteNonQuery();

            _connection.Close();
        }

        public List<Task> Get()
        {
            var taskList = new List<Task>();

            SqlCommand cmd = _connection.CreateCommand();

            cmd.CommandText = @"SELECT
                                    *
                                FROM
                                    Tasks";

            return ParseTasks(cmd);
        }

        public void Delete(Task task)
        {
            SqlCommand cmd = _connection.CreateCommand();

            cmd.CommandText = $@"DELETE FROM 
                                    Tasks
                                WHERE
                                    Tasks.Id = '{task.Id}'";

            _connection.Open();

            cmd.ExecuteNonQuery();
            
            _connection.Close();
        }

        public List<Task> GetByDate(DateTime date)
        {

            SqlCommand cmd = _connection.CreateCommand();

            cmd.CommandText = $@"SELECT
                                    *
                                FROM
                                    Tasks
                                WHERE
                                    Tasks.Date = '{date.ToString("yyyy-MM-dd")}'";

            return ParseTasks(cmd);
        }

        public Task GetById(Guid id)
        {
            SqlCommand cmd = _connection.CreateCommand();

            cmd.CommandText = $@"SELECT
                                    *
                                FROM
                                    Tasks
                                WHERE
                                    Tasks.Id = '{id}'";           

            return ParseTasks(cmd)[0];
        }

        public void AddOrUpdate(Task task)
        {
            SqlCommand cmd = _connection.CreateCommand();

            cmd.CommandText = $@"SELECT 
                                    * 
                                FROM 
                                    Tasks t 
                                WHERE 
                                    t.id = '{task.Id}'";

            _connection.Open();

            bool exist;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                exist = reader.Read();
            }

            _connection.Close();

            if (exist)
            {
                Update(task);
            }
            else
            {
                Add(task);
            }

            _connection.Close();
        }

        private List<Task> ParseTasks(SqlCommand command)
        {
            var taskList = new List<Task>();

            _connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
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
