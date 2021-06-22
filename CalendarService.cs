using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MyCalendarApp.Helpers;
using MyCalendarApp.MainMenuService;
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

        public static void ShowCalendar()
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

        public static void ShowTasks()
        {
            ShowCurrentTime();

            var taskList = FileHelperTask.DeserializeFromFile().ToList();
            var sortedList = taskList.OrderBy(x => x.DayOfEvent);

            Console.WriteLine("--- TO DO ----");
            foreach (var task in sortedList)
            {
                if (!task.IsDone)
                {
                    //Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine($"Name: {task.TaskName} Date: {task.DayOfEvent.ToString("dddd, dd MMMM yyyy")}");
                    Console.Write("\n");
                }
            }

            Console.WriteLine("--- DONE ---");
            foreach (var task in sortedList)
            {
                if (task.IsDone)
                {
                    Console.WriteLine($"Name: {task.TaskName} Date: {task.DayOfEvent.ToString("dddd, dd MMMM yyyy")}");
                    Console.Write("\n");
                }
            }

            //TODO : MARK TASK AS DONE

            Console.Write("\nClick any button to continue...");
            Console.ReadKey();
        }

        public static void AddNew()
        {
            var actionService = new MenuActionService();
            actionService = Initialize(actionService);

            var loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("Select element that you want add:");
                var addMenu = actionService.GetMenuActionsByMenuName("AddMenu");
                foreach (var line in addMenu)
                    Console.WriteLine($"{line.Id}. {line.Name}");
                Console.Write("> ");

                var operation = Console.ReadKey();
                switch (operation.KeyChar)
                {
                    case '1':
                        var newCalendar = new Calendar();
                        Console.Clear();
                        Console.Write("Enter new calendar name: ");
                        var name = Console.ReadLine();
                        Console.WriteLine("Enter calendar color by name: ");

                        
                        var values = Enum.GetValues(typeof(CalendarColor));
                        var count = 1;
                        foreach (var item in values)
                        {
                            Console.WriteLine($"{count}. {item}");
                            count++;
                        }
                        Console.Write("> ");
                        var choosenColor = (CalendarColor)(int.Parse(Console.ReadLine()));

                        if (Convert.ToInt32(choosenColor) < 0 || Convert.ToInt32(choosenColor) > 18)
                        {
                            Console.WriteLine("Invalid color! Click any key to continue...");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            newCalendar.Color = (ConsoleColor)choosenColor;
                            newCalendar.CalendarName = name;
                        }

                        Console.Write("Press 'Y' if you are sure to add: ");
                        var enteredKey = Console.ReadKey();
                        if (enteredKey.Key == ConsoleKey.Y)
                        {
                            var calendarList = FileHelperEvent.DeserializeFromFile();
                            var calendarWithHighestId = calendarList.OrderByDescending(x => x.Id).FirstOrDefault();
                            newCalendar.Id = calendarWithHighestId == null ? 1 : calendarWithHighestId.Id + 1;
                            calendarList.Add(newCalendar);
                            FileHelperEvent.SerializeToFile(calendarList);
                            Console.WriteLine("\n\nAdding done! Click any key to continue...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\n\nOperation stopped. Click any key to continue...");
                            Console.ReadKey();
                        }
                        break;

                    case '2':
                        var newEvent = new Event();

                        Console.Clear();
                        Console.Write("Enter event name: ");
                        newEvent.EventName = Console.ReadLine();
                        Console.Write("Enter event start date: ");
                        // TODO : ADD VALIDATION
                        newEvent.DateOfStart = Convert.ToDateTime(Console.ReadLine());
                        // TODO : ADD VALIDATION
                        Console.Write("Enter event end date: ");
                        newEvent.DateOfEnd = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("Enter event description: ");
                        newEvent.Description = Console.ReadLine();
                        Console.Write("Is busy?: ");
                        // TODO : ADD VALIDATION
                        newEvent.IsBusy = Convert.ToBoolean(Console.ReadLine());

                        var countCalendar = 1;
                        var list = FileHelperEvent.DeserializeFromFile();

                        Console.WriteLine("Choose calendar: ");
                        foreach (var item in list)
                        {
                            Console.ForegroundColor = item.Color;
                            Console.WriteLine($"{countCalendar}.  {item.CalendarName}");
                            countCalendar++;
                        }
                        Console.ForegroundColor = ConsoleColor.White;

                        var enteredKeyOption = int.Parse(Console.ReadLine());
                        countCalendar = 1;

                        Console.Write("Press 'Y' if you are sure to add: ");
                        enteredKey = Console.ReadKey();
                        if (enteredKey.Key == ConsoleKey.Y)
                        {
                            for (int index = 1; index <= list.Count; index++)
                            {
                                if (index != enteredKeyOption)
                                    continue;
                                else
                                {
                                    var eventWithHighestId = list[index-1].EventList.OrderByDescending(x => x.Id).FirstOrDefault();
                                    newEvent.Id = eventWithHighestId == null ? 1 : eventWithHighestId.Id + 1;
                                    list[index-1].EventList.Add(newEvent);
                                }
                                    
                            }
                            FileHelperEvent.SerializeToFile(list);
                            Console.WriteLine("\n\nAdding done! Click any key to continue...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\n\nOperation stopped. Click any key to continue...");
                            Console.ReadKey();
                        }
                        break;

                    case '3':
                        // TODO : ADDING TASK
                        break;

                    case '4':
                        loop = false;
                        break;

                    default:
                        Console.Write("There is no such option. Choose a different key.");
                        Console.ReadKey();
                        break;
                }
            }            
        }

        internal void Edit()
        {
            throw new NotImplementedException();
        }

        internal void Delete()
        {
            throw new NotImplementedException();
        }

        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Calendar", "AddMenu");
            actionService.AddNewAction(2, "Event", "AddMenu");
            actionService.AddNewAction(3, "Task", "AddMenu");
            actionService.AddNewAction(4, "Cancel action", "AddMenu");

            return actionService;
        }
    }
}