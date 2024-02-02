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
                var selectedMenuItem = MenuService.GetMenuItemSelection("MainMenu");
                int selectedSubMenuItemId = 0;
                if (selectedMenuItem.HaveSubmenu)
                {
                    string subMenuTitle = MenuService.GetSubMenuTitle(selectedMenuItem.Id);
                    selectedSubMenuItemId = MenuService.GetSubMenuItemSelection(selectedMenuItem, subMenuTitle);
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