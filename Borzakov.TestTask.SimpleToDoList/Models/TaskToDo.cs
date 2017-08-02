using System;
using System.Collections.Generic;

namespace Borzakov.TestTask.SimpleToDoList.Models
{
    public partial class TaskToDo
    {
        public int TaskId { get; set; }
        public string Text { get; set; }
        public bool IsDone { get; set; }
    }
}
