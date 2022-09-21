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
    public class TaskServices : ITaskServices
    {
        private Connections _connection = new();

        /// <summary>
        /// Caller NewTask from Domain and send parameters.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="taskName"></param>
        /// <param name="taskDescription"></param>
        /// <param name="createdTime"></param>
        /// <param name="priority"></param>
        public void NewTask(string taskName, string taskDescription, string priority)
        {
            _connection.NewTask(taskName, taskDescription, priority);
        }

        /// <summary>
        /// Show all Tasks from database.
        /// </summary>
        /// <returns>Returns Converted List from Domain.</returns>
        public List<TasksModel> ShowAllTask()
        {
            List<Tasks> myTask = _connection.ShowAllTask();
            List<TasksModel> modelTask = new List<TasksModel>();
            if (myTask == null)
            {
                return modelTask;
            }
            else
            {
                foreach (var item in myTask)
                {
                    modelTask.Add(new TasksModel
                    {
                        Task_Id = item.Task_Id,
                        Task_Name = item.Task_Name,
                        Task_Description = item.Task_Description,
                        Task_Created = item.Task_Created,
                        Priority = item.Priority,
                        Task_Status = item.Task_Status
                    });
                }
                return modelTask.OrderBy(x => x.Priority).ToList();
            }
            return modelTask;
        }

        /// <summary>
        /// Show one task by input ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One Task object</returns>
        public TasksModel ShowTaskById(int id)
        {
            Tasks myTask = _connection.ShowTaskById(id);
            TasksModel myModel = new TasksModel
            {
                Task_Id = myTask.Task_Id,
                Task_Name = myTask.Task_Name,
                Task_Description = myTask.Task_Description,
                Task_Created = myTask.Task_Created,
                Task_Status = myTask.Task_Status,
                Priority = myTask.Priority
            };
            return myModel;
        }

        /// <summary>
        /// Delete one task by input ID.
        /// </summary>
        /// <param name="taskid"></param>
        public void DeleteTaskById(int taskid)
        {
            _connection.DeleteTaskById(taskid);
        }

        /// <summary>
        /// Call UpdateTask from Domain and update parameters by user input.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="taskName"></param>
        /// <param name="taskDescription"></param>
        /// <param name="createdTime"></param>
        /// <param name="priority"></param>
        /// <param name="isCompleted"></param>
        public void UpdateTask(int id, string taskName, string taskDescription, string priority)
        {
            _connection.UpdateTask(id, taskName, taskDescription, priority);
        }
        /// <summary>
        /// Set task to completed.
        /// </summary>
        /// <param name="taskId"></param>
        public void TaskIsCompleted(int taskId)
        {
            _connection.TaskIsCompleted(taskId);
        }

        /// <summary>
        /// Delete all completed tasks
        /// </summary>
        public void DeleteAll() => _connection.DeleteAll();
    }
}
