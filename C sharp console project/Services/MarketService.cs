using C_sharp_console_project.Date.Entities;
using System;
using ConsoleTables;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_console_project.Services
{
    public class MarketService:IMarketable
    {
        //Product Methods
        public List<Product> Products { get; set; }
        public List<Sale> Sales { get; set; }
        public MarketService()
        {
            Products = new();
            Sales = new();
        }
        
        public void AddProduct(string name, double price, int count, string category)
        {
            Product product = new();
            product.ProductName = name;
            product.Price = price;
            product.Categories = category;
            product.ProductCount = count;
            Products.Add(product);
        }
        public void ChangeProduct(int a)
        {
            int b = 0;
            double c = 0;
            int d = 0;
            var change = Products.FirstOrDefault(i => i.No == a);
            do
            {
                Console.WriteLine("1-Change the name");
                Console.WriteLine("2-Change the category");
                Console.WriteLine("3-Change the price");
                Console.WriteLine("4-Change the count");
                Console.WriteLine("5-Exit");
                Console.WriteLine("What surgery do you want to do");
                string strb = Console.ReadLine();
                while (!int.TryParse(strb, out b))
                {
                    Console.WriteLine("Please enter number correct");
                    strb = Console.ReadLine();
                }

                switch (b)
                {
                    case 1:
                        Console.WriteLine("Enter new name");
                        string newname = Console.ReadLine();
                        change.ProductName = newname;
                        break;
                    case 2:
                        Console.WriteLine("Enter new category");
                        string newcategory = Console.ReadLine();
                        change.Categories = newcategory;
                        break;
                    case 3:
                        Console.WriteLine("Enter new price");
                        string doubl = Console.ReadLine();
                        while (!double.TryParse(doubl, out c))
                        {
                            Console.WriteLine("Please enter number correct");
                            doubl = Console.ReadLine();
                        }
                        change.Price = c;
                        break;
                    case 4:
                        Console.WriteLine("Enter the new count");
                        string newcount = Console.ReadLine();
                        while (!int.TryParse(newcount, out d))
                        {
                            Console.WriteLine("Please enter number correct");
                            newcount = Console.ReadLine();
                        }
                        change.ProductCount = d;
                        break;
                    default:
                        break;
                }

            } while (b != 5);
        }
        public void ClearProduct(int no)
        {
            int index = Products.FindIndex(a => a.No == no);
            Products.RemoveAt(index);
        }
        public List<Product> SerchforCategoryProduct(string category)
        {
            var result = Products.FindAll(a => a.Categories == category);
            return result;
        }
        public List<Product> SearchforPriceProduct(double startprice, double endprice)
        {
            var result = Products.FindAll(a => a.Price >= startprice && a.Price <= endprice);
            return result;
        }
        public List<Product> SearchforNameProduct(string name)
        {
            var result = Products.FindAll(a => a.ProductName == name);
            return result;
        }
        //Sale Methods
        public void AddSele(int no, int count)
        {
            int index = Products.FindIndex(a => a.No == no);
            var result = Products.ElementAt(index);
            result.ProductCount = result.ProductCount - count;
        }
    }
}
