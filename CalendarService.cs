using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MyCalendarApp.Helpers;
using MyCalendarApp.Models;

namespace MyCalendarApp
{
    public class CalendarService
    {
        private static readonly string FilePath = Path.Combine(Environment.CurrentDirectory + @"\MyCalendarData.xml");
        private static readonly FileHelpersXml<List<Calendar>> FileHelper = new(FilePath);

        private static void ShowCurrentTime()
        {
            var currentTime = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            Console.WriteLine("Current time: " + currentTime + "\n");
        }

        public void ShowCalendar()
        {
            ShowCurrentTime();

            var calendarList = FileHelper.DeserializeFromFile().ToList();
            foreach (var item in calendarList)
            {
                var eventList = item.EventList.ToList();
                var sortedList = eventList.OrderBy(x => x.DateOfStart);

                Console.WriteLine("--- " + item.CalendarName + " ---");
                Console.ForegroundColor = item.Color;
                foreach (var calEvent in sortedList)
                {
                    Console.WriteLine("Name: " + calEvent.EventName);
                    Console.WriteLine("Date of start: " + calEvent.DateOfStart.ToString("dddd, dd MMMM yyyy HH:mm"));
                    Console.WriteLine("Date of end: " + calEvent.DateOfEnd.ToString("dddd, dd MMMM yyyy HH:mm"));
                    Console.WriteLine("Description: " + calEvent.Description);
                    Console.WriteLine(calEvent.IsBusy ? "Busy: YES" : "Busy: NO");
                    Console.Write("\n");
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write("\nClick any button to continue...");
            Console.ReadKey();
        }

        internal void ShowTasks()
        {
            throw new NotImplementedException();
        }

        internal void AddNew()
        {
            throw new NotImplementedException();
        }

        internal void Edit()
        {
            throw new NotImplementedException();
        }

        internal void Delete()
        {
            throw new NotImplementedException();
        }

    }
}