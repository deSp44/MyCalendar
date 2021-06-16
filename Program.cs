using MyCalendarApp.MainMenuService;
using System;

namespace MyCalendarApp
{
    public static class Program
    {
        public static void Main()
        {
            var actionService = new MenuActionService();
            var calendarService = new CalendarService();
            actionService = Initialize(actionService);

            Console.WriteLine("Welcome to MyCalendar, the place where you manage your time!\n");
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select operation:");
                var mainMenu = actionService.GetMenuActionsByMenuName("Main");
                foreach (var line in mainMenu)
                    Console.WriteLine($"{line.Id}. {line.Name}");
                Console.Write("> ");

                var operation = Console.ReadKey();
                switch (operation.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        calendarService.ShowCalendar();
                        break;
                    case '2':
                        Console.Clear();
                        calendarService.ShowTasks();
                        break;
                    case '3':
                        Console.Clear();
                        calendarService.AddNewEvent();
                        break;
                    case '4':
                        Console.Clear();
                        calendarService.AddNewTask();
                        break;
                    case '5':
                        Console.Clear();
                        calendarService.EditEventOrTask();
                        break;
                    case '6':
                        Console.Clear();
                        calendarService.DeleteEventOrTask();
                        break;
                    case '7':
                        Console.Clear();
                        Console.Write("Goodbye!\n");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Write("There is no such option. Choose a different key.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Show calendar", "Main");
            actionService.AddNewAction(2, "Show tasks", "Main");
            actionService.AddNewAction(3, "Add a new event", "Main");
            actionService.AddNewAction(4, "Add a new task", "Main");
            actionService.AddNewAction(5, "Edit event or task", "Main");
            actionService.AddNewAction(6, "Delete event or task", "Main");
            actionService.AddNewAction(7, "Exit", "Main");

            return actionService;
        }
    }
}