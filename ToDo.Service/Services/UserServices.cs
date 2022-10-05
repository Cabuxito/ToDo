using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Connections;
using ToDo.Domain.Entities;
using ToDo.Service.Models;

namespace ToDo.Service.Services
{
    public class UserServices : IUserService
    {
        private readonly IConnections _connection;

        public UserServices(IConnections connection)
        {
            _connection = connection;
        }


        /// <summary>
        /// Add new user to table Users.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        public void NewUser(string username, string password, string firstName, string lastName, string email)
        {
            _connection.AddNewUser(username, password, firstName, lastName, email);
        }
        /// <summary>
        /// Get all Users from DB.
        /// </summary>
        /// <returns>List with all users</returns>
        public List<UsersModel> ShowAllUsers()
        {
            List<Users> myList = _connection.ShowAllUsers();
            List<UsersModel> newList = new();
            if (myList == null)
            {
                return newList;
            }
            else
            {
                foreach (var item in myList)
                {
                    newList.Add(new UsersModel
                    {
                        User_Id = item.User_Id,
                        UserName = item.UserName,
                        Password = item.Password,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Email = item.Email
                    });
                }
                return newList;
            }
        }
        /// <summary>
        /// Get a Users Object and transfer to UsersModel object.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>UsersModel object</returns>
        public UsersModel ShowUserById(int userId)
        {
            Users users = _connection.ShowUserById(userId);
            UsersModel myModel = new UsersModel
            {
                UserName = users.UserName,
                Password = users.Password,
                FirstName = users.FirstName,
                LastName = users.LastName ,
                Email = users.Email 
            };
            return myModel;
        }
        /// <summary>
        /// Set the user row to IsDeleted in the DB, so is "deleted"!
        /// </summary>
        /// <param name="userId"></param>
        public void DeleteUserById(int userId) => _connection.DeleteUserById(userId);
        /// <summary>
        /// Update one User by input UserID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="firstname"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        public void UpdateUserById(int id, string username, string password, string firstname, string lastName, string email)
        {
            _connection.UpdateUserById(id, username, password, firstname, lastName, email);
        }

        //LOGIN VALIDATION
        /// <summary>
        /// Check if the username and password is correct and returns a boolean.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>false if the login is not correct</returns>
        public bool LoginValidation(string username, string password) => _connection.LoginValidation(username, password);
    }
}
