using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Connections
{
    public class Connections : IConnections
    {
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ToDo;Integrated Security=True";
        private readonly SqlConnection _sqlConnection;

        public Connections()
        {
            _sqlConnection = new SqlConnection(_connectionString);
        }

        /// <summary>
        /// Get Stored Procedure and execute.
        /// </summary>
        /// <param name="StoredProcedure"></param>
        /// <returns>Procedure accion.</returns>
        public SqlCommand MyCommand(string StoredProcedure)
        {
            SqlCommand myCommand = new SqlCommand(StoredProcedure);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Connection = _sqlConnection;
            return myCommand;
        }

        /// <summary>
        /// Add new task to database.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="taskName"></param>
        /// <param name="taskDescription"></param>
        /// <param name="priority"></param>
        public void NewTask(string taskName, string taskDescription, string priority)
        {
            DateTime createdNow = DateTime.Now;
            SqlCommand command = MyCommand("spAddTask");
            command.Parameters.AddWithValue("TaskName", taskName);
            command.Parameters.AddWithValue("TaskDescription", taskDescription);
            command.Parameters.AddWithValue("CreatedTime", createdNow);
            command.Parameters.AddWithValue("Priority", priority);
            _sqlConnection.Open();
            command.ExecuteReader();
            _sqlConnection.Close();
        }

        /// <summary>
        /// Show all task from table.
        /// </summary>
        /// <returns>list of task</returns>
        public List<Tasks> ShowAllTask()
        {
            SqlCommand command = MyCommand("spShowTaskTable");
            try
            {
                _sqlConnection.Open();
                SqlDataReader myReader = command.ExecuteReader();
                if (myReader.HasRows)
                {
                    List<Tasks> allTask = new List<Tasks>();
                    while (myReader.Read())
                    {
                        allTask.Add(new Tasks
                        {
                            Task_Id = myReader.GetInt32("Task_Id"),
                            Task_Name = myReader.GetString("TaskName"),
                            Task_Created = myReader.GetDateTime("CreatedTime"),
                            Task_Description = myReader.GetString("TaskDescription"),
                            Priority = myReader.GetString("Priority"),
                            Task_Status = myReader.GetBoolean("IsCompleted")
                        });
                    }
                    return allTask;
                }
            }
            finally
            {
                _sqlConnection.Close();
            }
            return null;
        }

        /// <summary>
        /// Show Task Object by input.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task Object</returns>
        public Tasks ShowTaskById(int id)
        {
            SqlCommand command = MyCommand("spGetTaskById");
            command.Parameters.AddWithValue("id", id);
            try
            {
                _sqlConnection.Open();
                SqlDataReader myReader = command.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        Tasks oneTask = new Tasks
                        {
                            Task_Id = myReader.GetInt32("Task_Id"),
                            Task_Name = myReader.GetString("TaskName"),
                            Task_Created = myReader.GetDateTime("CreatedTime"),
                            Task_Description = myReader.GetString("TaskDescription"),
                            Priority = myReader.GetString("Priority"),
                            Task_Status = myReader.GetBoolean("IsCompleted")
                        };
                        return oneTask;
                    }
                }
            }
            finally
            {
                _sqlConnection.Close();
            }
            return null;
        }

        /// <summary>
        /// Delete task by id.
        /// </summary>
        /// <param name="Id"></param>
        public void DeleteTaskById(int Id)
        {
            SqlCommand command = MyCommand("spDeleteTaskById");
            command.Parameters.AddWithValue("Task_Id", Id);
            try
            {
                _sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        /// <summary>
        /// Update one task by input Id and param.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="taskName"></param>
        /// <param name="taskDescription"></param>
        /// <param name="priority"></param>
        /// <param name="isCompleted"></param>
        public void UpdateTask(int id, string taskName, string taskDescription, string priority, bool isCompleted)
        {
            SqlCommand command = MyCommand("spUpdateTask");
            command.Parameters.AddWithValue("Task_Id", id);
            command.Parameters.AddWithValue("TaskName", taskName);
            command.Parameters.AddWithValue("TaskDescription", taskDescription);
            command.Parameters.AddWithValue("Priority", priority);
            command.Parameters.AddWithValue("IsCompleted", isCompleted);
            try
            {
                _sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public void TaskIsCompleted(int taskId)
        {
            SqlCommand command = MyCommand("spTaskIsCompleted");
            command.Parameters.AddWithValue("Task_Id", taskId);
            _sqlConnection.Open();
            command.ExecuteNonQuery();
            _sqlConnection.Close();

        }
    }
}
