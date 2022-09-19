using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Service.Models;

namespace ToDo.Service.Services
{
    public interface ITaskServices
    {
        public void NewTask(string taskName, string taskDescription, string priority);
        public List<TasksModel> ShowAllTask();
        public TasksModel ShowTaskById(int id);
        public void DeleteTaskById(int taskid);
        public void UpdateTask(int id, string taskName, string taskDescription, string priority, bool status);
        public void TaskIsCompleted(int taskId);
    }
}
