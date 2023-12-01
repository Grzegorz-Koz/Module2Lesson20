using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    public class MenuActionService
    {
        // Klasa do trzymania listy akcji

        private List<MenuAction> menuActions;   
        
        public MenuActionService() 
        {
            menuActions = new List<MenuAction>();
        }
        public void AddNewAction (int id, string name, string menuName)
        {
            // Tworzy nowy menu item i następnie dodaje go do listy menuActions
            MenuAction menuAction = new MenuAction ()
            {
                Id = id,
                Name = name,
                MenuName = menuName
            };
            menuActions.Add (menuAction);
        }
        public List<MenuAction> GetMenuActionsByMenuName (string menuName) 
        {
            // Wyświetla menu na podstawie jego nazwy
            List<MenuAction> result = new List<MenuAction> ();  
            foreach (var menuAction in menuActions)
            {
                if (menuAction.MenuName == menuName)
                {
                    result.Add (menuAction);
                }
            }
            return result;
        }
    }
}
