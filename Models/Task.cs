using System;

namespace MyCalendarApp.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public DateTime DayOfTask { get; set; }
        public bool IsDone { get; set; }
    }
}