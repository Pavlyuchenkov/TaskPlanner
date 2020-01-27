using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskPlanner.Models
{
    public class Task
    {
        public int TaskId { get; set; } //used
        public string TaskName { get; set; } //used
        public string TaskDescrip { get; set; }
        //время постановки задачи
        public DateTime TaskTime { get; set; } //used
        public Task()
        {
            TaskTime = DateTime.Now;
        }
        //время выполнения задачи
        public DateTime EndTime { get; set; }
        //время затраченное на выполнение задачи
        public DateTime DifTime { get; set; }
    }
}
