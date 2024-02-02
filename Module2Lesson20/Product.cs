using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2lesson20
{
    public enum ProductColor
    {
        Blue = 1,
        Green = 2,
        Red = 3
    }
    
    public enum ProductSize
    {
        Small = 1,
        Medium = 2, 
        Large = 3
    }

    public enum ProductProperty
    {
        ProductColor = 1,
        ProductSize = 2
    }
    
    public class Product
    {
        public string Name { get; private set; }
        public ProductColor Color { get; private set; }
        public ProductSize Size { get; private set; }
        public Product(string productName, ProductColor productColor, ProductSize productSize)
        {
            Name = productName;
            Color = productColor;
            Size = productSize;
        }

    }
}
