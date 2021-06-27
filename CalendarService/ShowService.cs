using MyCalendarApp.Helpers;
using MyCalendarApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyCalendarApp.CalendarService
{
    public static class ShowService
    {
        private static readonly string FilePathCal = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MyCalendarApp\CalendarEventData.xml");
        private static readonly string FilePathTask = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MyCalendarApp\CalendarTaskData.xml");
        private static readonly FileHelpersXml<List<Calendar>> FileHelperEvent = new(FilePathCal);
        private static readonly FileHelpersXml<List<Task>> FileHelperTask = new(FilePathTask);

        private static void ShowCurrentTime()
        {
            var currentTime = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm");
            Console.WriteLine($"Current time: {currentTime}\n");
        }

        public static void ShowCalendar()
        {
            ShowCurrentTime();

            var calendarList = FileHelperEvent.DeserializeFromFile().ToList();
            var passedEventList = new List<Event>();
            var isEmpty = !calendarList.Any();

            if (isEmpty)
                Console.WriteLine("There is nothing here yet.");
            else
            {
                foreach (var item in calendarList)
                {
                    var eventList = item.EventList.ToList();
                    var sortedList = eventList.OrderBy(x => x.DateOfStart);

                    Console.WriteLine("--- " + item.Name + " ---");
                    Console.ForegroundColor = item.Color;
                    foreach (var calEvent in sortedList)
                    {
                        if (calEvent.DateOfEnd > DateTime.Now)
                        {
                            Console.WriteLine($"Name: {calEvent.Name}");
                            Console.WriteLine($"Date of start: {calEvent.DateOfStart:dddd, dd MMMM yyyy HH:mm}");
                            Console.WriteLine($"Date of end: {calEvent.DateOfEnd:dddd, dd MMMM yyyy HH:mm}");
                            Console.WriteLine($"Description: {calEvent.Description}");
                            Console.WriteLine(calEvent.IsBusy ? "Busy: YES" : "Busy: NO");
                            Console.Write("\n");
                        }
                        else
                        {
                            passedEventList.Add(calEvent);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;

                    // TODO : BETTER PASSED EVENTS? 
                    if (passedEventList.Any())
                    {
                        Console.WriteLine("\nPASSED EVENTS: ");

                        foreach (var calEvent in passedEventList)
                        {
                            Console.WriteLine($"Name: {calEvent.Name}");
                            Console.WriteLine($"Date of start: {calEvent.DateOfStart:dddd, dd MMMM yyyy HH:mm}");
                            Console.WriteLine($"Date of end: {calEvent.DateOfEnd:dddd, dd MMMM yyyy HH:mm}");
                            Console.WriteLine($"Description: {calEvent.Description}");
                            Console.WriteLine(calEvent.IsBusy ? "Busy: YES" : "Busy: NO");
                            Console.Write("\n");
                        }
                    }
                }
            }
            Console.Write("\nClick any button to continue...");
            Console.ReadKey();
        }

        public static void ShowTasks()
        {
            ShowCurrentTime();

            var taskList = FileHelperTask.DeserializeFromFile().ToList();
            var isEmpty = !taskList.Any();

            if (isEmpty)
                Console.WriteLine("There is nothing here yet.");
            else
            {
                var sortedList = taskList.OrderBy(x => x.DayOfTask);

                Console.WriteLine("--- TO DO ----");
                foreach (var task in sortedList)
                {
                    if (task.IsDone)
                        continue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Name: {task.Name} \nDate: {task.DayOfTask:dddd, dd MMMM yyyy}");
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine("--- DONE ---");
                foreach (var task in sortedList)
                {
                    if (!task.IsDone)
                        continue;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"Name: {task.Name} \nDate: {task.DayOfTask:dddd, dd MMMM yyyy}");
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            //TODO : MARK TASK AS DONE

            Console.Write("\nClick any button to continue...");
            Console.ReadKey();
        }
    }
}