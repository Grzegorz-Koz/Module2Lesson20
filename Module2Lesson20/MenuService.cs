using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Module2lesson20
{
    public enum SubMenuTitle
    {
        AddProduct = 1,
        RemoveProducts = 2,
        ShowProductDetails = 3,
        ListOfProducts = 4,
        ExitProgram = 5
    }
    
    internal static class MenuService
    {
        private static List<Menu> _menus;        

        public static List<MenuItem> mainMenuItems { get; } = new List<MenuItem>()
        {
            { new MenuItem("Add product", new(){})},
            { new MenuItem("Remove products",
                           new() {"Remove the product(s) with the given name",
                                 "Remove products with the given product property value",
                                 "Remove all products"})},
            { new MenuItem("Show product properties", new(){})},
            { new MenuItem("List of products",
                           new(){"List by product color",
                                 "List by product size",
                                 "List all products"})},
            { new MenuItem("Exit program", new(){})},
        };

        static MenuService() 
        {
            _menus = new List<Menu>();
        }

        public static void AddNewMenu(string menuName, List<MenuItem> menuItems)
        {
            Menu menu = new Menu();
            menu.MenuName = menuName;
            menu.MenuItems = menuItems;
            _menus.Add(menu);
        }

        public static void RemoveMenu(string menuName)
        {
            foreach (Menu item in _menus)
            {
                if (item.MenuName == menuName) 
                {
                    _menus.Remove(item);
                }
            }
        }                
        
        public static MenuItem GetMenuItemSelection(string menuName)
        {
            // Displays menu and returns user selection
            Console.WriteLine("What would you like to do?");
            int numberOfMenuItems = 0;
            Menu menu = new Menu();
            foreach (Menu item in _menus)
            {
                menu = item;
                if (item.MenuName == menuName)
                {
                    numberOfMenuItems = item.MenuItems.Count;
                    foreach (MenuItem menuItem in item.MenuItems)
                    {
                        Console.WriteLine($"{menuItem.Id}) {menuItem.PositionName}");                        
                    }
                }
            }            
            Console.WriteLine($"Select action (numbers 1 - {numberOfMenuItems}):");
            int operation = DataGetter.GetIntFromReadKeyInRange(1, numberOfMenuItems);            
            return menu.MenuItems[operation - 1];  // Because we count from 0
        }
        
        public static int GetSubMenuItemSelection(MenuItem menuItem, string subMenuTitle)
        {
            // Displays submenu and returns user selection
            int subMenuItemId = 1;
            Console.WriteLine($"\n{subMenuTitle}");
            foreach (String subMenuItem in menuItem.SubPositionNames)
            {
                Console.WriteLine($"{subMenuItemId}) {subMenuItem}");
                subMenuItemId++;
            }
            Console.WriteLine($"Select action (numbers 1 - {subMenuItemId-1}):");
            int operation = DataGetter.GetIntFromReadKeyInRange(1, subMenuItemId - 1);
            return operation;
        }
        
        public static string GetSubMenuTitle(int menuItemId)
        {
            string Title;
            SubMenuTitle subMenuTitle = (SubMenuTitle)menuItemId; // = new SubMenuTitle();
            return subMenuTitle switch
            {
                SubMenuTitle.AddProduct => "",
                SubMenuTitle.RemoveProducts => "\nChoose how you want to remove products:",
                SubMenuTitle.ShowProductDetails => "",
                SubMenuTitle.ListOfProducts => "\nAccording to what criteria should I list the products?",
                SubMenuTitle.ExitProgram => ""
            };
        }
    }
}
