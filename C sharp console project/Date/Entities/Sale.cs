using C_sharp_console_project.Date.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_console_project.Date.Entities
{
    public class Sale:SaleItem
    {
        public double Cost { get; set; }
        public List<SaleItem> Items { get; set; }
        public DateTime Date { get; set; }

        public Sale()
        {
            count++;
            No = count;
            Date = DateTime.Now;
        }

        

    }
}
