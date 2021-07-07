using System.Collections.Generic;
using System.Linq;

namespace MyCalendar.App.MainMenuService
{
    public class MenuActionService
    {
        private readonly List<MenuAction> _menuActions;

        public MenuActionService()
        {
            _menuActions = new List<MenuAction>();
        }

        private void AddNewAction(int id, string name, string menuName)
        {
            var menuAction = new MenuAction(id, name) { MenuName = menuName };
            _menuActions.Add(menuAction);
        }

        public IEnumerable<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            return _menuActions.Where(menuAction => menuAction.MenuName == menuName).ToList();
        }

        public static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Show calendar", "Main");
            actionService.AddNewAction(2, "Show tasks", "Main");
            actionService.AddNewAction(3, "Add new...", "Main");
            actionService.AddNewAction(4, "Edit...", "Main");
            actionService.AddNewAction(5, "Delete...", "Main");
            actionService.AddNewAction(6, "Exit", "Main");

            actionService.AddNewAction(1, "Calendar", "AddMenu");
            actionService.AddNewAction(2, "Event", "AddMenu");
            actionService.AddNewAction(3, "Task", "AddMenu");
            actionService.AddNewAction(4, "Cancel action", "AddMenu");

            actionService.AddNewAction(1, "Calendar", "EditMenu");
            actionService.AddNewAction(2, "Event", "EditMenu");
            actionService.AddNewAction(3, "Task", "EditMenu");
            actionService.AddNewAction(4, "Cancel action", "EditMenu");

            actionService.AddNewAction(1, "Calendar", "DeleteMenu");
            actionService.AddNewAction(2, "Event", "DeleteMenu");
            actionService.AddNewAction(3, "Task", "DeleteMenu");
            actionService.AddNewAction(4, "Everything", "DeleteMenu");
            actionService.AddNewAction(5, "Cancel action", "DeleteMenu");

            actionService.AddNewAction(1, "Show all tasks", "MarkTaskDone");
            actionService.AddNewAction(2, "Mark task as complete", "MarkTaskDone");
            actionService.AddNewAction(3, "Mark task as incomplete", "MarkTaskDone");
            actionService.AddNewAction(4, "Cancel action", "MarkTaskDone");

            return actionService;
        }
    }
}