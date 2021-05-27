using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_console_project.Services
{
    public class MenuService
    {
        static MarketService marketservice = new();
        public static void AddProduct()
        {
            int count = 0;
            double price = 0;
            Console.WriteLine("Please enter products name:");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter products price:");
            string pricestr = Console.ReadLine();
            while (!double.TryParse(pricestr, out price))
            {
                Console.WriteLine("Please enter the correct number: ");
                pricestr = Console.ReadLine();
            }
            Console.WriteLine("Please enter products category:");
            string category = Console.ReadLine();
            Console.WriteLine("Please enter products count:");
            string countstr = Console.ReadLine();
            while (!Int32.TryParse(countstr, out count))
            {
                Console.WriteLine("Please enter the correct number:");
                countstr = Console.ReadLine();
            }
            marketservice.AddProduct(name, price, count, category);
        }
        public static void ChangeProducts()
        {
            int code = 0;


            var table = new ConsoleTable("No", "Name", "Category", "Price", "Count");
            foreach (var products in marketservice.Products)
            {
                table.AddRow(products.No, products.ProductName, products.Categories, products.Price, products.ProductCount);
            }
            table.Write();
            Console.WriteLine();
            Console.WriteLine("Which the change product No ");
            string codestr = Console.ReadLine();
            while (!int.TryParse(codestr, out code))
            {
                Console.WriteLine("Please enter number correct:");
                codestr = Console.ReadLine();
            }

            marketservice.ChangeProduct(code);
        }
        public static void ClearProduct()
        {
            int no = 0;
            var table = new ConsoleTable("No", "Name", "Category", "Price", "Count");
            foreach (var products in marketservice.Products)
            {
                table.AddRow(products.No, products.ProductName, products.Categories, products.Price, products.ProductCount);
            }
            table.Write();
            Console.WriteLine();
            Console.WriteLine("Please write the delete product No:");
            string strno = Console.ReadLine();
            while (!int.TryParse(strno, out no))
            {
                Console.WriteLine("Please enter number correctly:");
                strno = Console.ReadLine();
            }
            marketservice.ClearProduct(no);
        }
        public static void AllProductsView()
        {
            var table = new ConsoleTable("No", "Name", "Category", "Price", "Count");
            foreach (var products in marketservice.Products)
            {
                table.AddRow(products.No, products.ProductName, products.Categories, products.Price, products.ProductCount);
            }
            table.Write();
            Console.WriteLine();

        }
        public static void SerachforCategoryproduct()
        {
            var table = new ConsoleTable("No", "Name", "Category", "Price", "Count");
            Console.WriteLine("Please enter the category:");
            string category = Console.ReadLine();
            foreach (var products in marketservice.SerchforCategoryProduct(category))
            {
                table.AddRow(products.No, products.ProductName, products.Categories, products.Price, products.ProductCount);

            }
            table.Write();
            Console.WriteLine();

        }
        public static void SearchforPricCeProduct()
        {
            double startprice = 0;
            double endprice = 0;
            Console.WriteLine("Please enter the start price:");
            string strstartprice = Console.ReadLine();

            while (!double.TryParse(strstartprice, out startprice))
            {
                Console.WriteLine("Please enter the number correctly:");
                strstartprice = Console.ReadLine();
            }
            Console.WriteLine("please enter the end price:");
            string strendprice = Console.ReadLine();
            while (!double.TryParse(strendprice, out endprice))
            {
                Console.WriteLine("Please enter the number correctly:");
                strendprice = Console.ReadLine();
            }
            var table = new ConsoleTable("No", "Name", "Category", "Price", "Count");
            foreach (var products in marketservice.SearchforPriceProduct(startprice, endprice))
            {
                table.AddRow(products.No, products.ProductName, products.Categories, products.Price, products.ProductCount);
            }
            table.Write();
            Console.WriteLine();
        }
        public static void SearchforNameProduct()
        {
            var table = new ConsoleTable("No", "Name", "Category", "Price", "Count");
            Console.WriteLine("Please enter the product name:");
            string name = Console.ReadLine();
            foreach (var products in marketservice.SearchforNameProduct(name))
            {
                table.AddRow(products.No, products.ProductName, products.Categories, products.Price, products.ProductCount);
            }
            table.Write();
            Console.WriteLine();
        }
    }
}
