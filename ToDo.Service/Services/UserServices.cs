using System;
using System.Collections.Generic;
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
        private Connections _connection = new();

        public void NewUser(string username, string password, string firstName, string lastName, string email)
        {
            _connection.AddNewUser(username, password, firstName, lastName, email);
        }

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
        public void DeleteUserById(int userId)
        {
            _connection.DeleteUserById(userId);
        }
        public void UpdateUserById(int id, string username, string password, string firstname, string lastName, string email)
        {
            _connection.UpdateUserById(id, username, password, firstname, lastName, email);
        }
    }
}
