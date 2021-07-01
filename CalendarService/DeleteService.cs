using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MyCalendarApp.Helpers;
using MyCalendarApp.MainMenuService;
using MyCalendarApp.Models;

namespace MyCalendarApp.CalendarService
{
    public static class DeleteService
    {
        private static readonly string FilePathCal = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MyCalendarApp\CalendarEventData.xml");
        private static readonly string FilePathTask = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MyCalendarApp\CalendarTaskData.xml");
        private static readonly FileHelpersXml<List<Calendar>> FileHelperEvent = new(FilePathCal);
        private static readonly FileHelpersXml<List<Task>> FileHelperTask = new(FilePathTask);

        public static void DeleteMenu()
        {
            var actionService = new MenuActionService();
            actionService = Initialize(actionService);

            var loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("Select element that you want delete:");
                var deleteMenu = actionService.GetMenuActionsByMenuName("DeleteMenu");
                foreach (var line in deleteMenu)
                    Console.WriteLine($"{line.Id}. {line.Name}");
                Console.Write("> ");

                var operation = Console.ReadKey();
                switch (operation.KeyChar)
                {
                    case '1':
                        DeleteCalendar();
                        break;

                    case '2':
                        DeleteEvent();
                        break;

                    case '3':
                        DeleteTask();
                        break;

                    case '4':
                        DeleteEverything();
                        break;

                    case '5':
                        loop = false;
                        break;

                    default:
                        Console.Write("\nThere is no such option. Choose a different key.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void DeleteCalendar()
        {
            Console.Clear();
            var calendarList = FileHelperEvent.DeserializeFromFile();
            
            var count = 1;
            foreach (var calendar in calendarList)
            {
                Console.ForegroundColor = calendar.Color;
                Console.WriteLine($"{count}. {calendar.Name}");
                count++;
            }
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("Select calendar that you want delete: ");
            var enteredKeyOption = CheckValid.IsInputNumber(count);
            Console.Write("Press 'Y' if you are sure to delete that calendar: ");
            var enteredKey = Console.ReadKey();
            if (enteredKey.Key == ConsoleKey.Y)
            {
                calendarList.RemoveAt(enteredKeyOption - 1);
                FileHelperEvent.SerializeToFile(calendarList);
                Console.WriteLine("\n\nRemoving done! Click any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n\nOperation stopped. Click any key to continue...");
                Console.ReadKey();
            }

        }

        private static void DeleteEvent()
        {
            Console.Clear();
            var calendarList = FileHelperEvent.DeserializeFromFile();

            var calendarCount = 1;
            foreach (var calendar in calendarList)
            {
                Console.ForegroundColor = calendar.Color;
                Console.WriteLine($"{calendarCount}. {calendar.Name}");
                calendarCount++;
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Select calendar where event you want to delete is: ");
            var enteredCalendarOption = CheckValid.IsInputNumber(calendarCount);
            var selectedCalendar = calendarList.ElementAt(enteredCalendarOption - 1);

            var eventCount = 1;
            foreach (var item in selectedCalendar.EventList)
            {
                Console.WriteLine($"{eventCount}. {item.Name} {item.DateOfStart:dd MMMM yyyy HH:mm} - {item.DateOfEnd:dd MMMM yyyy HH:mm}");
                eventCount++;
            }
            Console.Write("Select event that you want delete: ");
            var enteredEventOption = CheckValid.IsInputNumber(eventCount);

            Console.Write("Press 'Y' if you are sure to delete that calendar: ");
            var enteredKey = Console.ReadKey();
            if (enteredKey.Key == ConsoleKey.Y)
            {
                calendarList.ElementAt(enteredCalendarOption - 1).EventList.RemoveAt(enteredEventOption - 1);
                FileHelperEvent.SerializeToFile(calendarList);
                Console.WriteLine("\n\nRemoving done! Click any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n\nOperation stopped. Click any key to continue...");
                Console.ReadKey();
            }
        }

        private static void DeleteTask()
        {
            Console.Clear();
            var tasksList = FileHelperTask.DeserializeFromFile();
            
            var count = 1;
            foreach (var task in tasksList)
            {
                Console.WriteLine($"{count}. {task.Name}");
                count++;
            }

            Console.Write("Select task that you want delete: ");
            var enteredKeyOption = CheckValid.IsInputNumber(count);
            Console.Write("Press 'Y' if you are sure to delete that task: ");
            var enteredKey = Console.ReadKey();
            if (enteredKey.Key == ConsoleKey.Y)
            {
                tasksList.RemoveAt(enteredKeyOption-1);
                FileHelperTask.SerializeToFile(tasksList);
                Console.WriteLine("\n\nRemoving done! Click any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n\nOperation stopped. Click any key to continue...");
                Console.ReadKey();
            }
        }

        private static void DeleteEverything()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("!!! WARNING !!!");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Are you sure you want to delete EVERYTHING?");
            Console.Write("There is no going back. Please write (YES/NO) :");
            Console.ForegroundColor = ConsoleColor.Gray;

            var decision = CheckValid.CheckYesOrNo();
            if (decision)
            {
                File.Delete(FilePathCal);
                File.Delete(FilePathTask);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nAll your data has been deleted! Choose any key to continue...");
                Console.ForegroundColor = ConsoleColor.Gray; Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nNothing has been deleted. Choose any key to continue...");
                Console.ForegroundColor = ConsoleColor.Gray; Console.ReadKey();
            }
        }

        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Calendar", "DeleteMenu");
            actionService.AddNewAction(2, "Event", "DeleteMenu");
            actionService.AddNewAction(3, "Task", "DeleteMenu");
            actionService.AddNewAction(4, "Everything", "DeleteMenu");
            actionService.AddNewAction(5, "Cancel action", "DeleteMenu");

            return actionService;
        }
    }
}