
namespace Module2lesson20
{
    internal class MenuItem
    {
        /*
         * Item list:
         * - The first element of the list - It is menu label.
         * - (Optionally) Second, third, ... elements of the list - Labels of a submenu for the menu item.
         */

        private static int numberOfCreatedMenuItems = 0;
        public List<String> Item { get; set; }
        public int Id { get; set; } = 0;       
        public bool IsSubmenu { get; set; }
        public MenuItem(List<string> item)
        {
            numberOfCreatedMenuItems++;
            Id = numberOfCreatedMenuItems;
            Item = item;
            // I assume that the submenu must contain at least 2 items.
            // That is, the entire list of at least 3 elements.:
            IsSubmenu = item.Count > 2 ? true : false;
        }
    }
}
