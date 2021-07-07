using System;
using System.Collections.Generic;
using System.Linq;
using MyCalendar.App.Models;
using MyCalendar.App.Helpers;
using MyCalendar.App.MainMenuService;

namespace MyCalendar.App.CalendarService
{
    public class ShowService : BaseService
    {
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
                    var sortedList = eventList.OrderBy(x => x.DateOfStart).ToList();

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

                    if (!passedEventList.Any()) continue;
                    {
                        Console.WriteLine("\nPASSED EVENTS: ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        foreach (var calEvent in passedEventList.OrderByDescending(x => x.DateOfEnd))
                        {
                            Console.WriteLine($"Name: {calEvent.Name}");
                            Console.WriteLine($"Date of start: {calEvent.DateOfStart:dddd, dd MMMM yyyy HH:mm}");
                            Console.WriteLine($"Date of end: {calEvent.DateOfEnd:dddd, dd MMMM yyyy HH:mm}");
                            Console.WriteLine($"Description: {calEvent.Description}");
                            Console.WriteLine(calEvent.IsBusy ? "Busy: YES" : "Busy: NO");
                            Console.Write("\n");
                        }
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }
            ScrollUp();
        }

        public static void ShowTaskMenu()
        {
            var actionService = new MenuActionService();
            MenuActionService.Initialize(actionService);

            var loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("Select operation:");
                var addMenu = actionService.GetMenuActionsByMenuName("MarkTaskDone");
                foreach (var line in addMenu)
                    Console.WriteLine($"{line.Id}. {line.Name}");
                Console.Write("> ");

                var operation = Console.ReadKey();
                switch (operation.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        ShowTasks();
                        break;

                    case '2':
                        Console.Clear();
                        MarkAs(false);
                        break;

                    case '3':
                        Console.Clear();
                        MarkAs(true);
                        break;

                    case '4':
                        loop = false;
                        break;

                    default:
                        Console.Write("\nThere is no such option. Choose a different key.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void ShowTasks()
        {
            ShowCurrentTime();

            var tasksList = FileHelperTask.DeserializeFromFile().ToList();

            var undoneTasks = tasksList
            .Where(x => x.IsDone == false)
            .Select(x => x)
            .OrderBy(x => x.DayOfTask)
            .ToList();

            var daysOfUndoneTasks = undoneTasks
            .Select(x => x.DayOfTask)
            .OrderBy(x => x.Date)
            .Distinct()
            .ToList();

            var doneTasks = tasksList
            .Where(x => x.IsDone)
            .Select(x => x)
            .Distinct()
            .OrderBy(x => x.DayOfTask)
            .ToList();

            var daysOfDoneTasks = doneTasks
            .Select(x => x.DayOfTask)
            .OrderBy(x => x.Date)
            .Distinct()
            .ToList();

            var isEmpty = !tasksList.Any();
            if (isEmpty)
                Console.WriteLine("There is nothing here yet.");
            else
            {
                // SHOWING UNDONE TASKS
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("=== TO DO ===");
                foreach (var day in daysOfUndoneTasks)
                {
                    Console.WriteLine($"--- {day:dddd, dd MMMM yyyy} ---");
                    foreach (var task in undoneTasks.Where(task => day == task.DayOfTask))
                    {
                        Console.WriteLine($"[ ] {task.Name}");
                    }
                    Console.WriteLine();
                }

                // SHOWING DONE TASKS
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("=== DONE ===");
                foreach (var day in daysOfDoneTasks)
                {
                    Console.WriteLine($"--- {day:dddd, dd MMMM yyyy} ---");
                    foreach (var task in doneTasks.Where(task => day == task.DayOfTask))
                    {
                        Console.WriteLine($"[+] {task.Name}");
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            ScrollUp();
        }

        private static void MarkAs(bool isDone)
        {
            var tasksList = FileHelperTask.DeserializeFromFile().ToList();

            var undoneTasks = tasksList
                .Where(x => x.IsDone == false)
                .Select(x => x)
                .OrderBy(x => x.DayOfTask)
                .ToList();

            var daysOfUndoneTasks = undoneTasks
                .Select(x => x.DayOfTask)
                .OrderBy(x => x.Date)
                .Distinct()
                .ToList();

            var doneTasks = tasksList
                .Where(x => x.IsDone)
                .Select(x => x)
                .Distinct()
                .OrderBy(x => x.DayOfTask)
                .ToList();

            var daysOfDoneTasks = doneTasks
                .Select(x => x.DayOfTask)
                .OrderBy(x => x.Date)
                .Distinct()
                .ToList();

            var days = isDone ? daysOfDoneTasks : daysOfUndoneTasks;
            var tasks = isDone ? doneTasks : undoneTasks;

            var count = 1;
            foreach (var day in days)
            {
                Console.WriteLine($"--- {day:dddd, dd MMMM yyyy} ---");
                foreach (var task in tasks.Where(task => day == task.DayOfTask))
                {
                    Console.WriteLine($"{count}. {task.Name}");
                    count++;
                }
                Console.WriteLine();
            }
            Console.Write("Select operation: ");
            var enteredKeyOption = CheckValid.IsInputNumber(tasks.Count);

            Console.Write("Press 'Y' if you are sure to save changes: ");
            var enteredKey = Console.ReadKey();
            if (enteredKey.Key == ConsoleKey.Y)
            {
                var selectedTask = tasks.ElementAt(enteredKeyOption - 1);
                foreach (var task in tasksList.Where(task => selectedTask == task))
                {
                    task.IsDone = !isDone;
                }
                FileHelperTask.SerializeToFile(tasksList);
                Console.WriteLine("\n\nEditing done! Click any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n\nOperation stopped. Click any key to continue...");
                Console.ReadKey();
            }
        }

        private static void ShowCurrentTime()
        {
            var currentTime = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm");
            Console.WriteLine($"Current time: {currentTime}\n");
        }

        private static void ScrollUp()
        {
            Console.Write("\nClick any button to continue...");
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
            Console.ReadKey();
            Console.CursorVisible = true;
        }
    }
}