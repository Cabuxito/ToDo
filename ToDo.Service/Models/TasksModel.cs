using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Service.Models
{
    public class TasksModel
    {
        public int Task_Id { get; init; }
        public string Task_Name { get; set; }
        public string Task_Description { get; set; }
        public DateTime Task_Created { get; set; }
        public string Priority { get; set; }
        public bool Task_Status { get; set; }
    }
}
