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
        public void NewTask(string taskName, string taskDescription, string priority);
        public List<Tasks> ShowAllTask();
        public Tasks ShowTaskById(int id);
        public void DeleteTaskById(int id);
        public void UpdateTask(int id, string taskName, string taskDescription, string priority);
        public void TaskIsCompleted(int taskId);
        public void DeleteAll();
    }
}
