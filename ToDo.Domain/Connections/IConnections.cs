using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Connections
{
    public interface IConnections
    {
        #region Task Connections
        public void NewTask(string taskName, string taskDescription, string priority);
        public List<Tasks> ShowAllTask();
        public Tasks ShowTaskById(int id);
        public void DeleteTaskById(int id);
        public void UpdateTask(int id, string taskName, string taskDescription, string priority);
        public void TaskIsCompleted(int taskId);
        public void DeleteAll();
        public List<Tasks> usersTask(int userId);
        #endregion

        #region Users Connections
        public void AddNewUser(string username, string password, string firstName, string lastName, string email);
        public List<Users> ShowAllUsers();
        public Users ShowUserById(int userId);
        public void DeleteUserById(int userId);
        public void UpdateUserById(int id, string username, string password, string firstname, string lastName, string email);
        public bool LoginValidation(string userName, string password);
        public Users GetUserIdByUsername(string username, string password);
        
        #endregion
    }
}
