﻿using TaskManagerExample.Enums;

namespace TaskManagerExample.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public TasksStatus Status { get; set; }
    }
}
