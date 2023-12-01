namespace Warehouse
{
    internal class Program
    {
        public const string FILE_NAME = @"C:\WarehouseFiles\ImportFile.xlsx";
        static void Main(string[] args)
        {
            // Przywitanie

            // Wybór akcji:
            // a) Stworzenie nowego przedmiotu
            // b) Usunięcie przedmiotu
            // c) Sprawdzenie stanu magazynowego
            // d) Zwrócenie listy przedmiotów o zadanym filtrze (nazwa kategorii)

            // a1) Najpierw dostanę do wyboru kategorię produktu
            // a2) Zostanę poproszony o wprowadzenie szczegółów produktu
            // b1) Zostanę poproszony o id produktu lub jego nazwę
            // b2) Usunięcie produktu
            // c1) Zostanę poproszony o wprowadzenie id produktu
            // c2) Wyświetlenie wszystkich info o produkcie 
            // d1) Zostanę poproszony o id lub nazwę kategorii
            // d2) Wyświetlenie listy produktów

            // Dzięki tej pętli wracamy do pierwszego menu

            MenuActionService actionService = new MenuActionService();
            ItemService itemService = new ItemService();
            actionService = Initialize(actionService);

            while (true)
            {


                Console.WriteLine("Welcome to Warahouse App!");
                Console.WriteLine("Choose option:");

                var mainMenu = actionService.GetMenuActionsByMenuName("Main");
                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                }
                var operation = Console.ReadKey();
                
                switch (operation.KeyChar)
                {
                    case '1':
                        var keyInfo = itemService.AddNewItemView(actionService);
                        var id = itemService.AddNewItem(keyInfo.KeyChar);
                        break;
                    case '2':
                        var removeId = itemService.RemoveItemView();
                        itemService.RemoveItem(removeId);
                        break;
                    case '3':
                        var detailId = itemService.ItemDetailSelectionView();
                        itemService.ItemDetailView(detailId);
                        break;
                    case '4':
                        var typeId = itemService.ItemTypeSelctionView();
                        itemService.ItemsByTypeIdView(typeId);
                        break;
                    default:
                        Console.WriteLine("Action you entered does not exist.");
                        break;
                }


            }

            

        }

        private static MenuActionService Initialize(MenuActionService actionService)
        {
            // Główne menu:
            actionService.AddNewAction(1, "Add item", "Main");
            actionService.AddNewAction(2, "Remove item", "Main");
            actionService.AddNewAction(3, "Show details", "Main");
            actionService.AddNewAction(4, "List of Items", "Main");

            actionService.AddNewAction(1, "Clothing", "AddNewItemMenu");
            actionService.AddNewAction(2, "Electronics", "AddNewItemMenu");
            actionService.AddNewAction(3, "Grocery", "AddNewItemMenu");
            
            return actionService;
        }
    }
}