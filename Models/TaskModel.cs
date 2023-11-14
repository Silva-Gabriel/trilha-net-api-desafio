using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrilhaApiDesafio.Enums;

namespace TrilhaApiDesafio.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTask { get; set; }
        public StatusTaskEnum Status { get; set; }
    }
}