using System;
using MyCalendar.App.CalendarService;
using MyCalendar.App.MainMenuService;

namespace MyCalendar.App
{
    public static class Program
    {
        public static void Main()
        {
            var actionService = new MenuActionService();
            MenuActionService.Initialize(actionService);

            // MAIN MENU OF APPLICATION
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
                        ShowService.ShowCalendar();
                        break;
                    case '2':
                        Console.Clear();
                        ShowService.ShowTaskMenu();
                        break;
                    case '3':
                        Console.Clear();
                        AddService.AddMenu();
                        break;
                    case '4':
                        Console.Clear();
                        EditService.EditMenu();
                        break;
                    case '5':
                        Console.Clear();
                        DeleteService.DeleteMenu();
                        break;
                    case '6':
                        Console.Clear();
                        Console.Write("Goodbye!\n");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Write("\nThere is no such option. Choose a different key.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}