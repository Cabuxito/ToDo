using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Service.Models;

namespace ToDo.Service.Services
{
    public interface IUserService
    {
        public void NewUser(string username, string password, string firstName, string lastName, string email);
        public List<UsersModel> ShowAllUsers();
        public UsersModel ShowUserById(int userId);
        public void DeleteUserById(int userId);
        public void UpdateUserById(int id, string username, string password, string firstname, string lastName, string email);
        public bool LoginValidation(string username, string password);
        public void GetUserIdByUsername(string username, string password);
        public UsersModel LoadLoggedIn();
        public int LoggedIndId();

    }
}
