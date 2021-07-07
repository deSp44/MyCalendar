using System;
using System.Collections.Generic;

namespace MyCalendar.App.Models
{
    public class Calendar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Event> EventList { get; set; }
        public ConsoleColor Color { get; set; }
    }
}