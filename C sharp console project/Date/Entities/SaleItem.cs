using C_sharp_console_project.Date.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_console_project.Date.Entities
{
    public class SaleItem : BaseEntity
    {
        public static int count = 0;

        
        public Product products { get; set; }
        

        public  SaleItem()
        {
            count++;
            No = count;
        } 

        

    }
}
