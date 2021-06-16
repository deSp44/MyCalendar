using System.Collections.Generic;

namespace MyCalendarApp.MainMenuService
{
    public class MenuActionService
    {
        private readonly List<MenuAction> _menuActions;

        public MenuActionService()
        {
            _menuActions = new List<MenuAction>();
        }


        public void AddNewAction(int id, string name, string menuName)
        {
            var menuAction = new MenuAction(id, name) { MenuName = menuName };
            _menuActions.Add(menuAction);
        }

        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            var result = new List<MenuAction>();
            foreach (var menuAction in _menuActions)
            {
                if (menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }
    }
}