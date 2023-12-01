namespace Module2lesson20
{        
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to product database application. \n");
            MenuService.AddNewMenu("MainMenu", MenuService.mainMenuItems);
            while (true)
            {
                var selectedMenuItem = MenuService.getMenuItemSelection("MainMenu");
                int selectedSubMenuItemId = 0;
                if (selectedMenuItem.IsSubmenu)
                {
                    string subMenuTitle = MenuService.getSubMenuTitle(selectedMenuItem.Id);
                    selectedSubMenuItemId = MenuService.getSubMenuItemSelection(selectedMenuItem, subMenuTitle);
                }
                ActionToPerform actionToPerform = MenuAction.GetActionToPerform(selectedMenuItem.Id, selectedSubMenuItemId);
                
                if (actionToPerform == ActionToPerform.ExitProgram)
                {
                    Console.WriteLine($"\n\nThe program has been completed.");
                    break;
                }
                MenuAction.PerformAction(actionToPerform);               
                Console.WriteLine("");
            }
        }
    }
}