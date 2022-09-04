using Domain.Task.States;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infrastructure.DataBase.Entities
{
    [Table("Tasks")]
    public class TaskDAL : DALObject
    {
        public virtual int EmployeeId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public TaskState CurrentState { get; set; }
        public DateTime? FinishDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
