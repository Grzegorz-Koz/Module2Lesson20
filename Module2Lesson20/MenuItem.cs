
namespace Module2lesson20
{
    internal class MenuItem
    {
        private static int numberOfCreatedMenuItems = 0;

        public int Id { get; set; } = 0;        
        public string PositionName { get; set; }      
        public List<string> SubPositionNames { get; set; }
             
        public bool HaveSubmenu { get; set; }
        public MenuItem(string positionName, List<string> subPositionNames)
        {
            numberOfCreatedMenuItems++;
            Id = numberOfCreatedMenuItems;
            PositionName = positionName;
            SubPositionNames = subPositionNames;
            HaveSubmenu = subPositionNames.Count > 0;
        }
    }
}
