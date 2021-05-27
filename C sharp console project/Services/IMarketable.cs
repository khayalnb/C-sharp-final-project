using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_console_project.Date.Entities
{
    interface IMarketable
    {
        //Product
        public void AddProduct(string Productname, double Price, int Count, string Category)
        {

        }
        public void ChangeProduct(int code, string ProductName, double Price, int NewCode, int count, string Category)
        {

        }
        public void ClearProduct(int Code)
        {


        }
        public void AllProductsView()
        {

        }
        public void SearchforPriceproduct(double startprice, double endprice)
        {

        }
        public void SearchforCategoryproduct(string Category)
        {

        }
        public void SearchforNameproduct(string Name)
        {

        }
        //Sale
        public void Addnewsales()
        {


        }
        public void Returnofsale()
        {

        }
        public void Deletesale()
        {

        }
        public void Displayallsale()
        {

        }
        public void Displayrangeofdatesale()
        {

        }
        public void Displayrangeofpricesale()
        {
        }
        public void Displayotheonedaysale()
        {

        }
        public void DisplayofNosale()
        {

        }



    }
}
