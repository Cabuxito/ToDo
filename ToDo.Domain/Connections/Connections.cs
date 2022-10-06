using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private readonly string _connectionString;
        private readonly SqlConnection _sqlConnection;

        public Connections(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connectionString");
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

        #region Task Connections
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
            command.Parameters.AddWithValue("TaskCreatedTime", createdNow);
            command.Parameters.AddWithValue("Priority", priority);
            _sqlConnection.Open();
            command.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        /// <summary>
        /// Show all task from table.
        /// </summary>
        /// <returns>list of task</returns>
        public List<Tasks> ShowAllTask()
        { 
            SqlCommand command = MyCommand("spShowAllTask");
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
                            Task_Id = myReader.GetInt32("ToDo_Id"),
                            Task_Name = myReader.GetString("TaskName"),
                            Task_Created = myReader.GetDateTime("TaskCreatedTime"),
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
            SqlCommand command = MyCommand("spShowTaskById");
            command.Parameters.AddWithValue("Task_Id", id);
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
        public void UpdateTask(int id, string taskName, string taskDescription, string priority)
        {
            SqlCommand command = MyCommand("spUpdateTaskById");
            command.Parameters.AddWithValue("Task_Id", id);
            command.Parameters.AddWithValue("TaskName", taskName);
            command.Parameters.AddWithValue("TaskDescription", taskDescription);
            command.Parameters.AddWithValue("Priority", priority);
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
        /// Set task to completed on DB.
        /// </summary>
        /// <param name="taskId"></param>
        public void TaskIsCompleted(int taskId)
        {
            SqlCommand command = MyCommand("spTaskIsCompleted");
            command.Parameters.AddWithValue("Task_Id", taskId);
            _sqlConnection.Open();
            command.ExecuteNonQuery();
            _sqlConnection.Close();

        }

        /// <summary>
        /// Delete all
        /// </summary>
        public void DeleteAll()
        {
            SqlCommand command = MyCommand("spDeleteAll");
            _sqlConnection.Open();
            command.ExecuteNonQuery();
            _sqlConnection.Close();
        }
        /// <summary>
        /// Get all privat users tasks
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>tasks list</returns>
        public List<Tasks> usersTask(int userId)
        {
            SqlCommand command = MyCommand("spShowUsersToDoById");
            command.Parameters.AddWithValue("UsersId", userId);
            try
            {
                _sqlConnection.Open();
                SqlDataReader myReader = command.ExecuteReader();
                if (myReader.HasRows)
                {
                    List<Tasks> myTask = new();
                    while (myReader.Read())
                    {
                        myTask.Add(new Tasks
                        {
                            Task_Id = myReader.GetInt32("ToDo_Id"),
                            Task_Name = myReader.GetString("TaskName"),
                            Task_Created = myReader.GetDateTime("TaskCreatedTime"),
                            Task_Description = myReader.GetString("TaskDescription"),
                            Priority = myReader.GetString("Priority"),
                            Task_Status = myReader.GetBoolean("IsCompleted")
                        });
                        return myTask;
                    }
                }
            }
            finally
            {
                _sqlConnection.Close();
            }
            return null;
        }
        #endregion

        #region Users Connections
        /// <summary>
        /// Add New user by input param.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        public void AddNewUser(string username, string password, string firstName, string lastName, string email) 
        {
            SqlCommand command = MyCommand("spAddUser");
            command.Parameters.AddWithValue("Username", username);
            command.Parameters.AddWithValue("Password", password);
            command.Parameters.AddWithValue("FirstName", firstName);
            command.Parameters.AddWithValue("LastName", lastName);
            command.Parameters.AddWithValue("Email", email);
            _sqlConnection.Open();
            command.ExecuteNonQuery();
            _sqlConnection.Close();
        }
        /// <summary>
        /// Show All Users
        /// </summary>
        /// <returns>List of Users</returns>
        public List<Users> ShowAllUsers()
        {
            SqlCommand command = MyCommand("v_ShowUsers");
            try
            {
                _sqlConnection.Open();
                SqlDataReader myReader = command.ExecuteReader();
                if (myReader.HasRows)
                {
                    List<Users> myUsers = new List<Users>();
                    while (myReader.Read())
                    {
                        myUsers.Add(new Users
                        {
                            User_Id = myReader.GetInt32("User_Id"),
                            UserName = myReader.GetString("Username"),
                            Password = myReader.GetString("Password"),
                            FirstName = myReader.GetString("FirsName"),
                            LastName = myReader.GetString("LastName"),
                            Email = myReader.GetString("Email")
                        });
                    }
                    return myUsers;
                }
            }
            finally
            {
                _sqlConnection.Close();
            }
            return null;

        }
        /// <summary>
        /// Show one User by input Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>User Object</returns>
        public Users ShowUserById(int userId)
        {
            SqlCommand command = MyCommand("spShowUserById");
            command.Parameters.AddWithValue("Task_Id", userId);
            try
            {
                _sqlConnection.Open();
                SqlDataReader myReader = command.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        Users user = new Users
                        {
                            User_Id = myReader.GetInt32("User_Id"),
                            UserName = myReader.GetString("Username"),
                            Password = myReader.GetString("Password"),
                            FirstName = myReader.GetString("FirsName"),
                            LastName = myReader.GetString("LastName"),
                            Email = myReader.GetString("Email")
                        };
                        return user;
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
        /// Delete User By Input Id.
        /// </summary>
        /// <param name="userId"></param>
        public void DeleteUserById(int userId)
        {
            SqlCommand command = MyCommand("spDeleteUserById");
            command.Parameters.AddWithValue("User_Id", userId);
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
        /// Update User By Input ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        public void UpdateUserById(int userId, string username, string password, string firstName, string lastName, string email)
        {
            SqlCommand command = MyCommand("spEditUserById");
            command.Parameters.AddWithValue("User_Id", userId);
            command.Parameters.AddWithValue("Username", username);
            command.Parameters.AddWithValue("Password", password);
            command.Parameters.AddWithValue("FirstName", firstName);
            command.Parameters.AddWithValue("LastName", lastName);
            command.Parameters.AddWithValue("Email", email);
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
        /// Get User ID by Username and password.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Users Object</returns>
        public int GetUserIdByUsername(string username, string password)
        {
            SqlCommand command = MyCommand("spGetUsersIdbyLogin");
            command.Parameters.AddWithValue("Username", username);
            command.Parameters.AddWithValue("Password", password);
            try
            {
                _sqlConnection.Open();
                SqlDataReader myReader = command.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        int userId = myReader.GetInt32(0);
                        return userId;
                    }
                }
            }
            finally 
            {
                _sqlConnection.Close();
            }
            return 0;
        }

        #endregion

        #region LoginCheck
        public bool LoginValidation(string userName, string password)
        {
            bool isLoggedIn = false;
            SqlCommand command = MyCommand("spShowAllUsers");
            try
            {
                _sqlConnection.Open();
                SqlDataReader myReader = command.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        if (myReader.GetString("Username") == userName
                            && password == myReader.GetString("Password"))
                            return isLoggedIn = true;
                    }
                }
            }
            finally 
            {
                _sqlConnection.Close();
                
            }
            return isLoggedIn;
        }
        #endregion
    }
}
