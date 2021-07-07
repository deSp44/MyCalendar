using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MyCalendar.App.Helpers;
using MyCalendar.App.MainMenuService;
using MyCalendar.App.Models;

namespace MyCalendar.App.CalendarService
{
    public class AddService : BaseService
    {
        public void AddMenu()
        {
            var actionService = new MenuActionService();
            MenuActionService.Initialize(actionService);

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
                        AddCalendar();
                        break;

                    case '2':
                        AddEvent();
                        break;

                    case '3':
                        AddTask();
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

        private static void AddCalendar()
        {
            var newCalendar = new Calendar();

            Console.Clear();
            Console.Write("Enter new calendar name: ");
            newCalendar.Name = Console.ReadLine();
            Console.WriteLine("Enter calendar color by number: ");
            var values = Enum.GetValues(typeof(ConsoleColor));
            var count = 1;
            foreach (var item in values)
            {
                Console.WriteLine($"{count}. {item}");
                count++;
            }
            newCalendar.Color = CheckValid.IsValidColor();

            Console.Write("Press 'Y' if you are sure to add: ");
            var enteredKey = Console.ReadKey();
            if (enteredKey.Key == ConsoleKey.Y)
            {
                var calendarList = FileHelperEvent.DeserializeFromFile();
                var calendarWithHighestId = calendarList.OrderByDescending(x => x.Id).FirstOrDefault();
                newCalendar.Id = calendarWithHighestId?.Id + 1 ?? 1;
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
        }

        private static void AddEvent()
        {
            var newEvent = new Event();

            Console.Clear();
            Console.Write("Enter event name: ");
            newEvent.Name = Console.ReadLine();
            Console.Write("Enter event start date in correct format - DD-MM-YYYY hh:mm: ");
            newEvent.DateOfStart = CheckValid.IsValidDateExtended();
            Console.Write("Enter event end date in correct format - DD-MM-YYYY hh:mm: ");
            newEvent.DateOfEnd = CheckValid.IsValidDateExtended();
            Console.Write("Enter event description: ");
            newEvent.Description = Console.ReadLine();
            Console.Write("Status (FREE/BUSY): ");
            newEvent.IsBusy = CheckValid.IsBusy();
  
            var list = FileHelperEvent.DeserializeFromFile();

            if (!list.Any())
            {
                Console.WriteLine("\n\nOperation stopped. No calendar has been created yet. If you want to add event, create calendar first.");
                Console.ReadKey();
            }
            else
            {
                var countCalendar = 1;
                Console.WriteLine("Choose calendar: ");
                foreach (var item in list)
                {
                    Console.ForegroundColor = item.Color;
                    Console.WriteLine($"{countCalendar}.  {item.Name}");
                    countCalendar++;
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                var enteredKeyOption = CheckValid.IsInputNumber(countCalendar);

                Console.Write("Press 'Y' if you are sure to add: ");
                var enteredKey = Console.ReadKey();
                if (enteredKey.Key == ConsoleKey.Y)
                {
                    for (var index = 1; index <= list.Count; index++)
                    {
                        if (index != enteredKeyOption) continue;

                        var eventWithHighestId = list[index - 1].EventList.OrderByDescending(x => x.Id).FirstOrDefault();
                        newEvent.Id = eventWithHighestId?.Id + 1 ?? 1;
                        list[index - 1].EventList.Add(newEvent);

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
            }
        }

        private static void AddTask()
        {
            var newTask = new Task();

            Console.Clear();
            Console.Write("Enter task name: ");
            newTask.Name = Console.ReadLine();
            Console.Write("Enter task date in correct format - DD-MM-YYYY: ");
            newTask.DayOfTask = CheckValid.IsValidDateNormal();

            Console.Write("Press 'Y' if you are sure to add: ");
            var enteredKey = Console.ReadKey();
            if (enteredKey.Key == ConsoleKey.Y)
            {
                var tasksList = FileHelperTask.DeserializeFromFile();
                var taskWithHighestId = tasksList.OrderByDescending(x => x.Id).FirstOrDefault();
                newTask.Id = taskWithHighestId?.Id + 1 ?? 1;
                tasksList.Add(newTask);
                FileHelperTask.SerializeToFile(tasksList);

                Console.WriteLine("\n\nAdding done! Click any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n\nOperation stopped. Click any key to continue...");
                Console.ReadKey();
            }
        }
    }
}