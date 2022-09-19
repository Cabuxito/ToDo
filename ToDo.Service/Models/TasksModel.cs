using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Service.Models
{
    public class TasksModel
    {
        public int Task_Id { get; init; }
        [Required]
        public string Task_Name { get; set; }
        [Required, MaxLength(25)]
        public string Task_Description { get; set; }
        public DateTime Task_Created { get; set; }
        public string Priority { get; set; }
        public bool Task_Status { get; set; }
    }
}
