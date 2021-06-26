using System;

namespace MyCalendarApp.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfEnd { get; set; }
        public string Description { get; set; }
        public bool IsBusy { get; set; }
    }
}