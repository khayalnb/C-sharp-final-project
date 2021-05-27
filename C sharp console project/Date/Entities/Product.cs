using C_sharp_console_project.Date.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_console_project.Date.Entities
{
    

   public enum Category
    {
        Drink = 1,
        Chocolate,
        Tea,
        Meat,
        Cake


    }
    public class Product :BaseEntity
    {
        public static int count = 0;

        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Categories { get; set; }
        public int ProductCount { get; set; }
       
        public Product()
        {
            count++;
            No = count;
        } 

        
    }

  
}
