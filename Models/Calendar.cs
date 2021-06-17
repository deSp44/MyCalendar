using System;
using System.Collections.Generic;

namespace MyCalendarApp.Models
{
    public class Calendar
    {
        public int Id { get; set; }
        public string CalendarName { get; set; }
        public List<Event> EventList { get; set; }
        public ConsoleColor Color { get; set; }
    }
}