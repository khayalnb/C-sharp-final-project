using C_sharp_console_project.Date.Entities;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_console_project.Services
{
    
    class MenuService
    {
        
        static MarketService marketservice = new();

        
        
        public static void AddProduct()
        {
            

            int count = 0;
            double price = 0;
            Console.WriteLine("Zehmet olmasa mehsulun adin daxil edin:");
            string name = Console.ReadLine();
            Console.WriteLine("Zehmet olmasa mehsulun qiymetin daxil edin:");
            string pricestr = Console.ReadLine();
            while (!double.TryParse(pricestr, out price))
            {
                Console.WriteLine("Please enter the correct number: ");
                pricestr = Console.ReadLine();
            }
            Console.WriteLine("Zehmet olmasa mehsulun kategoriyasın daxil edin:");
            int index = 1;
            foreach (var item in Enum.GetValues(typeof(Category)))
            {

                Console.WriteLine($"{index}. {item}");
                index++;

            }

            int pick = Convert.ToInt32(Console.ReadLine());
            Category sort = new();
            switch (pick)
            {
                case (int)Category.Cake:
                    sort = Category.Cake;

                    break;
                case (int)Category.Chocolate:
                    sort = Category.Chocolate;

                    break;
                case (int)Category.Drink:
                    sort = Category.Drink;

                    break;
                case (int)Category.Fruit:
                    sort = Category.Fruit;

                    break;
                case (int)Category.Tea:
                    sort = Category.Tea;

                    break;
                default:
                    break;
            }
            Console.WriteLine("Please enter products count");
            string countstr = Console.ReadLine();
            while (!Int32.TryParse(countstr, out count))
            {
                Console.WriteLine("Please enter the correct number");
                countstr = Console.ReadLine();
            }
            marketservice.AddProduct(name, price, count, sort);

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
            int index = 1;
            foreach (var item in Enum.GetValues(typeof(Category)))
            {
                Console.WriteLine($"{index}. {item}");
                index++;

            }
            int pick = 0;
            Console.WriteLine("Please select category");
            string strpick = Console.ReadLine();
            while (!int.TryParse(strpick, out pick))
            {
                Console.WriteLine("Please enter the correct numer");
                strpick = Console.ReadLine();
            }
            Category sort = new();
            switch (pick)
            {
                case (int)Category.Cake:
                    sort = Category.Cake;

                    break;
                case (int)Category.Chocolate:
                    sort = Category.Chocolate;

                    break;
                case (int)Category.Fruit:
                    sort = Category.Fruit;

                    break;
                case (int)Category.Drink:
                    sort = Category.Drink;

                    break;
                case (int)Category.Tea:
                    sort = Category.Tea;

                    break;
                default:
                    break;
            }

            foreach (var products in marketservice.SerchforCategoryProduct(sort))
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
        //Sale
        public static void AddSale()
        {
            Sale sale = new();
            int sell = 0;
            do
            {
                Console.WriteLine("1 Hansi mehsulu almaq isteyirsiniz ?");
                Console.WriteLine("2 Cixis");
                Console.WriteLine("Hansi elemeliyyat; etmek isteyirsiniz? ");
                string strsell = Console.ReadLine();
                while (!int.TryParse(strsell, out sell))
                {
                    Console.WriteLine("Ededi duz daxil edin");
                    strsell = Console.ReadLine();

                }
                switch (sell)
                {
                    case 1:
                        int no = 0;
                        var table = new ConsoleTable("No", "Name", "Category", "Price", "Count");

                        foreach (var products in marketservice.Products)
                        {
                            table.AddRow(products.No, products.ProductName, products.Categories, products.Price, products.ProductCount);

                        }
                        table.Write();
                        Console.WriteLine();
                        Console.WriteLine("Secmek istediyiniz mehsulun nomresin daxil edin:");
                        
                        string strno = Console.ReadLine();

                        while (!int.TryParse(strno, out no))
                        {
                            Console.WriteLine("Nomreni duzgun daxil edin");
                            strno = Console.ReadLine();


                        }
                        
                        int count = 0;
                        Console.WriteLine("Secdiyiniz mehsulun sayin qeyd edin");
                        string strcount = Console.ReadLine();

                        while (!int.TryParse(strcount, out count))
                        {
                            Console.WriteLine("Sayi duzgun qeyd edin:");
                            strcount = Console.ReadLine();

                        }
                        marketservice.AddSale(no, count, sale);

                            break;
                    case 2:
                        marketservice.Sales.Add(sale);
                        break;
                    default:
                        break;
                                 
                }

            } while (sell !=2) ;
 
        }
        public static void ReturnOfProduct()
        {
            int no= 0;
            int count = 0;
            var table= new ConsoleTable("No", "Sale Price", "Count", "Date");
            foreach (var sale in marketservice.Sales)
            {
                table.AddRow(sale.No, sale.Price, sale.Items.Count, sale.Date);

            }
            table.Write();
            Console.WriteLine();
            Console.WriteLine("Please enter the return sale NO");
            string strno = Console.ReadLine();
            while (!int.TryParse(strno, out no))
            {
                Console.WriteLine("Please enter the correct NO");
                strno = Console.ReadLine();
            }
            Console.WriteLine("Please write the return product name ");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter the return product count ");
            string strcount = Console.ReadLine();
            while (!int.TryParse(strcount, out count))
            {
                Console.WriteLine("Please enter the correct count");
                strcount = Console.ReadLine();
            }
            marketservice.ReturnofProduct(no,name,count); 
        }     
        public void DeleteSale()
        {
            int no = 0;
            var table = new ConsoleTable("No", "Price", "Count", "Date");
            foreach(var sale in marketservice.Sales)
            {
                table.AddRow(sale.No, sale.Price, sale.Items.Count, sale.Date);
            }
            table.Write();
            Console.WriteLine();
            Console.WriteLine("Please write the delete sale No");
            string strno = Console.ReadLine();
            while (!int.TryParse(strno, out no))
            {
                Console.WriteLine("Please enter the number correctly");
                strno = Console.ReadLine();
            }
            marketservice.DeleteSale(no);

        }
        public static void AllSaleView()
        {
            var table = new ConsoleTable("No", "Price", "Count", "Date");
            foreach (var sale in marketservice.Sales)
            {
                table.AddRow(sale.No, sale.Price, sale.Items.Count, sale.Date);
            }
            table.Write();
            Console.WriteLine();
        }
        public static void RangeOfDateSale()
        {
            Console.WriteLine("Please enter time (dd.mm.yyyy)");
            string strdate1 = Console.ReadLine();
            Console.WriteLine("Please enter time (dd.mm.yyyy)");
            string strdate2 = Console.ReadLine();
            DateTime date1 = DateTime.Parse(strdate1);
            DateTime date2 = DateTime.Parse(strdate2);
            var table = new ConsoleTable("No", "Sale Price", "Count", "Date");
            foreach (var sale in marketservice.RangeOfDateSale(date1, date2))
            {
                table.AddRow(sale.No, sale.Price, sale.Items.Count, sale.Date);
            }
            table.Write();
            Console.WriteLine();
        }
        public static void RangeOfPriceSale()
        {
            double price1 = 0;
            double price2 = 0;
            Console.WriteLine("Please enter the start price");
            string strprice1 = Console.ReadLine();
            while (!double.TryParse(strprice1, out price1))
            {
                Console.WriteLine("Please enter the correct number");
                strprice1 = Console.ReadLine();

            }
            Console.WriteLine("Please enter the start price");
            string endprice2 = Console.ReadLine();
            while (!double.TryParse(endprice2, out price2))
            {
                Console.WriteLine("Please enter the correct number");
                endprice2 = Console.ReadLine();

            }
            var table = new ConsoleTable("No", "Price", "Count", "Date");
            foreach(var sale in marketservice.RangeOfPriceSale(price1, price2))
            {
                table.AddRow(sale.No, sale.Price, sale.Items.Count, sale.Date);
            }
            table.Write();
            Console.WriteLine();
        }
        public static void OneDaySale()
        {
            Console.WriteLine("(Please enter time(dd.mm.yyyy))");
            string strday = Console.ReadLine();
            DateTime day = DateTime.Parse(strday);
            var table = new ConsoleTable("No", "Price", "Count", "Date");
            foreach(var sale in marketservice.OneDayDale(day))
            {
                table.AddRow(sale.No, sale.Price, sale.Items.Count, sale.Date);
            }
            table.Write();
            Console.WriteLine();
        }
        public static void TheNoSale() 
        {
            int no = 0;
            Console.WriteLine("Please enter the No");
            string strno = Console.ReadLine();
            while (!int.TryParse (strno ,out no))
            {
                Console.WriteLine("Please enter the No");
                strno = Console.ReadLine();
            }
            var table =new ConsoleTable("No", "Price", "Count", "Date");
            foreach(var sale in marketservice.TheNoSale(no))
            {
                table.AddRow(sale.No, sale.Price, sale.Items.Count, sale.Date);
            }
            table.Write();
            Console.WriteLine();
        }


    }
}
