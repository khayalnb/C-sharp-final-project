using C_sharp_console_project.Date.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_console_project.Date.Entities
{ 
    class Sale:SaleItem
    {
        private static int count = 0;
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public List<SaleItem> Items { get; set; }
       

        public Sale()
        {
            Date = DateTime.Now;
            Items = new();
            count++;
            No = count;
            
        }

        

    }
}
