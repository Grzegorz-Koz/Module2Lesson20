using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2lesson20
{

    public static class MenuAction
    {        
        public static ActionToPerform GetActionToPerform(int selectedMenuItemId, int selectedSubMenuItemId)
        {
            string concatenation = selectedMenuItemId.ToString() + selectedSubMenuItemId.ToString();
            bool isValid = int.TryParse(concatenation, out int actionToPerform);
            return (ActionToPerform)actionToPerform;
        }
        public static void PerformAction(ActionToPerform actionToPerform)
        {
            switch (actionToPerform)
            {
                case ActionToPerform.AddProduct:                    
                    ProductService.AddNewProduct();                    
                    break;
                case ActionToPerform.RemoveProducts:
                    //
                    break;
                case ActionToPerform.RemoveProductWithName:
                    ProductService.RemoveProductWithName();
                    break;
                case ActionToPerform.RemoveProductsWithProperty:
                    ProductService.RemoveProductsWithProperty();
                    break;
                case ActionToPerform.RemoveAllProducts:
                    ProductService.RemoveAllProducts();
                    break;
                case ActionToPerform.ShowProductProperties:
                    ProductService.ShowProductProperties();
                    break;
                case ActionToPerform.ListOfProducts:
                    //
                    break;
                case ActionToPerform.ListOfProductsByColor:
                    ProductService.ListOfProductsByProperty(ActionToPerform.ListOfProductsByColor);
                    break;
                case ActionToPerform.ListOfProductsBySize:
                    ProductService.ListOfProductsByProperty(ActionToPerform.ListOfProductsBySize);
                    break;
                case ActionToPerform.ListAllProducts:
                    ProductService.ListAllProducts();
                    break;
                case ActionToPerform.ExitProgram:
                    //
                    break;
                default:
                    // wyrzucić wyjątek
                    break;
            }            
        }
    }
}
