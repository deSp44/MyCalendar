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
        private static readonly string FilePathCal = Path.Combine(Environment.CurrentDirectory + @"\CalendarEventData.xml");
        private static readonly string FilePathTask = Path.Combine(Environment.CurrentDirectory + @"\CalendarTaskData.xml");
        private static readonly FileHelpersXml<List<Calendar>> FileHelperEvent = new(FilePathCal);
        private static readonly FileHelpersXml<List<Task>> FileHelperTask = new(FilePathTask);

        private static void ShowCurrentTime()
        {
            var currentTime = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            Console.WriteLine("Current time: " + currentTime + "\n");
        }

        public void ShowCalendar()
        {
            ShowCurrentTime();

            var calendarList = FileHelperEvent.DeserializeFromFile().ToList();
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

        public void ShowTasks()
        {
            ShowCurrentTime();

            var taskList = FileHelperTask.DeserializeFromFile().ToList();
            var sortedList = taskList.OrderBy(x => x.DayOfEvent);

            Console.WriteLine("--- TO DO ----");
            foreach (var task in sortedList)
            {
                if (!task.IsDone)
                {
                    Console.WriteLine("Name: " + task.TaskName);
                    Console.WriteLine("Date: " + task.DayOfEvent.ToString("dddd, dd MMMM yyyy"));
                    Console.Write("\n");
                }
            }

            Console.WriteLine("--- DONE ---");
            foreach (var task in sortedList)
            {
                if (task.IsDone)
                {
                    Console.WriteLine("Name: " + task.TaskName);
                    Console.WriteLine("Date: " + task.DayOfEvent.ToString("dddd, dd MMMM yyyy"));
                    Console.Write("\n");
                }
            }

            //TODO : MARK TASK AS DONE

            Console.Write("\nClick any button to continue...");
            Console.ReadKey();
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