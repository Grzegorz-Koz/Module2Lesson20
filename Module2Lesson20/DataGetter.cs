using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2lesson20
{
    public static class DataGetter
    {
        public static int GetIntFromReadKey(string errorMessage = "\nWpisz liczbę całkowitą:")
        {
            int userSelection;
            while (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out userSelection))
            {
                Console.WriteLine(errorMessage);
            }
            return userSelection;
        }
        
        public static int GetIntFromReadKeyInRange(int lowerLimit, int upperLimit)
        {
            string errorMessage = $"\nWpisz liczbę całkowitą z zakresu: {lowerLimit} - {upperLimit}";
            int userSelection; 
            while (!IsIntInRange(userSelection = GetIntFromReadKey(errorMessage), lowerLimit, upperLimit))
            {
                Console.WriteLine(errorMessage);                
            }
            return userSelection;
        }
        
        public static bool IsIntInRange(int inputInteger, int lowerLimit, int upperLimit)
        {
            return (inputInteger >= lowerLimit && inputInteger <= upperLimit);
        }
        
        public static string getNotEmptyText()
        {
            string input;
            while (string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                Console.WriteLine("Please, enter not empty value:");
            }
            return input;
        }
    }
}
