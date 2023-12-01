using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using System.Xml.Linq;
using System.Drawing;
using System.Diagnostics.Metrics;
using System.Threading.Channels;
using System.Collections;

namespace Module2lesson20
{
    internal static class ProductService
    {
        public static List<Product> Products { get; set; } = new List<Product>();
        
        private static Enum getEnumSelection(Type enumType)
        {
            int counter = 1;
            foreach (var name in Enum.GetNames(enumType))
            {
                Console.WriteLine($"{counter}) {name}");
                counter++;
            }            
            int selection = DataGetter.GetIntFromReadKeyInRange(1, counter - 1);
            Enum value = (Enum)Enum.ToObject(enumType, selection);
            return value;
        }
        
        public static Product AddNewProduct()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Enter new product name:");
            String productName = DataGetter.getNotEmptyText();

            Console.WriteLine("\nSelect new product color id:");
            Enum productColor = getEnumSelection(typeof(ProductColor));

            Console.WriteLine("\n\nSelect new product size id:");
            Enum productSize = getEnumSelection(typeof(ProductSize));

            Product product = new Product(productName, (ProductColor)productColor, (ProductSize)productSize);
            
            Products.Add(product);
            Console.WriteLine($"\n\nYou have added a new product:");
            Console.WriteLine($"- {product.Name}, {product.Color}, {product.Size}");
            return product;
        }
        
        public static void RemoveProductWithName()
        {
            Console.WriteLine("\n\nEnter product(s) name to remove:");
            String productName = DataGetter.getNotEmptyText();
            int counter = 0;
            List<Product> productsToRemove = new List<Product>();
            foreach (Product product in Products)
            {
                if (product.Name == productName)
                {                    
                    productsToRemove.Add(product);
                    counter++;
                }
            }

            string infoAboutRemovedProducts = $"\nYou have removed {counter} product(s) with \'{productName}\' name.";
            string nothingToRemove = $"\nThere is no products with name: {productName}.";
            string info;
            if (counter > 0)
            {
                Products = Products.Except(productsToRemove).ToList();
                info = infoAboutRemovedProducts;
            }
            else
            {
                info = nothingToRemove;
            }                                                            
            Console.WriteLine(info);
        }

        public static void RemoveProductsWithProperty()
        {
            Console.WriteLine("\n\nSelect property you would like to use to remove products:");
            Enum productProperty = getEnumSelection(typeof(ProductProperty));
            String commentToPerformAction; 
            switch ((ProductProperty)productProperty)
            {
                case ProductProperty.ProductColor:
                    commentToPerformAction = "\n\nSelect color for products you want to remove:";
                    RemoveProductsWithPropertyValue(typeof(ProductColor), ProductProperty.ProductColor, commentToPerformAction);
                    break;
                case ProductProperty.ProductSize:
                    commentToPerformAction = "\n\nSelect size for products you want to remove:";
                    RemoveProductsWithPropertyValue(typeof(ProductSize), ProductProperty.ProductSize, commentToPerformAction);
                    break;

            }
            

        }

        private static void RemoveProductsWithPropertyValue(Type enumType, ProductProperty productProperty, String commentToPerformAction)
        {
            Console.WriteLine(commentToPerformAction);
            Enum enumSelection = getEnumSelection(enumType);

            ProductColor color = 0;
            ProductSize size = 0;
            string info = "";
            switch (productProperty)
            {
                case ProductProperty.ProductColor:
                    color = (ProductColor)enumSelection;
                    info = $"with color '{color}'";
                    break;
                case ProductProperty.ProductSize:
                    size = (ProductSize)enumSelection;
                    info = $"with size '{size}'";
                    break;
            }            
            int counter = 0;
            List<Product> productsToRemove = new List<Product>();
            foreach (Product product in Products)
            {
                if (product.Color == color || product.Size == size)
                {                                        
                    productsToRemove.Add(product);
                    counter++;
                }
            }
                        
            string infoAboutOfRemoving;
            if (counter > 0)
            {
                Products = Products.Except(productsToRemove).ToList();
                infoAboutOfRemoving = $"\n\nYou have removed {counter} product(s) " + info + ".";
            }
            else
            {
                infoAboutOfRemoving = $"\n\nThere is no products " + info + " to remove.";
            }
            Console.WriteLine(infoAboutOfRemoving);
        }
        
        public static void RemoveAllProducts()
        {
            Products.Clear();
            Console.WriteLine("\n\nYou have removed all products.");
            Console.WriteLine("> List of products is empty <");
        }
        public static void ListAllProducts()
        {
            Console.WriteLine("\n\nList of all products:");
            if (Products.Count > 0)
            {
                foreach (Product product in Products)
                {
                    Console.WriteLine($" - {product.Name}, {product.Color}, {product.Size}");
                }
            }
            else
            {
                Console.WriteLine("> List of products is empty <");
            }
            
        }

        public static void ShowProductProperties()
        {
            Console.WriteLine("\n\nEnter product(s) name to display properties:");
            String productName = DataGetter.getNotEmptyText();
            Console.WriteLine($"\nProperties of products with the name \'{productName}\':");
            foreach (Product product in Products)
            {
                if (product.Name == productName)
                {
                    Console.WriteLine($" - {product.Name}, {product.Color}, {product.Size}");                    
                }
            }
        }
        
        public static void ListOfProductsByProperty(ActionToPerform actionToPerform)
        {
            Type enumType = null;
            string propertyName = "";
            switch (actionToPerform)
            {
                case ActionToPerform.ListOfProductsByColor:
                    propertyName = "color";
                    enumType = typeof(ProductColor);
                    break;
                case ActionToPerform.ListOfProductsBySize:
                    propertyName = "size";
                    enumType = typeof(ProductSize);
                    break;

            }
            Console.WriteLine($"\n\nSelect product {propertyName} id:");
            Enum productValue = getEnumSelection(enumType);
            string propertyValue = "";

            // Color and Size cannot have the value of 0 (because enums start from 1).
            // Thanks to this, I can select products, either for specific color or specific dimension (separable).
            ProductColor color = 0;
            ProductSize size = 0;
            switch (actionToPerform)
            {
                case ActionToPerform.ListOfProductsByColor:
                    color = (ProductColor)productValue;
                    propertyValue = color.ToString();
                    break;
                case ActionToPerform.ListOfProductsBySize:
                    size = (ProductSize)productValue;
                    propertyValue = size.ToString();
                    break;
            }
            Console.WriteLine($"\n\nProducts with {propertyName} \'{propertyValue}\':");

            int counter = 0;
            foreach (Product product in Products)
            {
                if (product.Color == color || product.Size == size)
                {
                    Console.WriteLine($" - {product.Name}, {product.Color}, {product.Size}");
                    counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("> There is no such products <");
            }
        }
    }
}
