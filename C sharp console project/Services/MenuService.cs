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
            if (name==null)
            {
                throw new ArgumentNullException("mehsulun adin daxil edin");

            }
            Console.WriteLine("Zehmet olmasa mehsulun qiymetin daxil edin:");
            string pricestr = Console.ReadLine();
            while (!double.TryParse(pricestr, out price))
            {
                Console.WriteLine("Zehmet olmasa duzgun nomreni daxil edin");
                pricestr = Console.ReadLine();
            }
            Console.WriteLine("Zehmet olmasa mehsulun kategoriyasın daxil edin:");
            if (price<=0)
            {
                throw new ArgumentOutOfRangeException("Daxil etdiyiniz mebleg menfi ola bilmez");

            }
            int index = 1;
            foreach (var item in Enum.GetValues(typeof(Category)))
            {
                Console.WriteLine($"{index}. {item}");
                index++;
            }

            int pick = 0;
            string strpick = Console.ReadLine();
            while (!int.TryParse(strpick, out pick)) 
            {
                Console.WriteLine("Zehmet olmasa duzgun reqem daxil edin");
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
            if (pick>=6 || pick<=6)
            {
                throw new ArgumentNullException("Daxil etdiyiniz kateqoriya movcud deyil");

            }
            Console.WriteLine("Zehmet olmasa mehsul sayını daxil edin");
            string countstr = Console.ReadLine();
            while (!Int32.TryParse(countstr, out count))
            {
                Console.WriteLine("Zehmet olmasa duzgun nomreni daxil edin");
                countstr = Console.ReadLine();
            }
            if (count<=0)
            {
                throw new ArgumentOutOfRangeException("Mehsulun sayi menfi ola bilmez");
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
            Console.WriteLine("Deyisdirmek istediyiniz mehsulun No-sun secin: ");
            string codestr = Console.ReadLine();
            while (!int.TryParse(codestr, out code))
            {
                Console.WriteLine("Zehmet olmasa duzgun nomreni daxil edin:");
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
            Console.WriteLine("Zehmet olmasa silmek istediyiniz mehsulun No-sun secin:");
            string strno = Console.ReadLine();
            while (!int.TryParse(strno, out no))
            {
                Console.WriteLine("Zehmet olmasa duzgun nomreni daxil edin:");
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
            Console.WriteLine("Zehmet olmasa kateqoriyani secin");
            string strpick = Console.ReadLine();
            while (!int.TryParse(strpick, out pick))
            {
                Console.WriteLine("Zehmet olmasa duzgun nomreni daxil edin");
                strpick = Console.ReadLine();
            }
            if (pick<=0 || pick>=6)
            {
                throw new ArgumentNullException("daxil etdiyiniz kateqoriya movcud deyil");

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
            Console.WriteLine("Zehmet olmasa baslanqic meblegi daxil edin:");
            string strstartprice = Console.ReadLine();

            while (!double.TryParse(strstartprice, out startprice))
            {
                Console.WriteLine("Zehmet olmasa meblegi duzgun daxil edin:");
                strstartprice = Console.ReadLine();
            }
            if (startprice<= 0)
            {
                throw new ArgumentOutOfRangeException("Mehsulun qiymeti menfi ola bilmez");
            }
            
            Console.WriteLine("Zehmet olmasa son deyer meblegin daxil edin:");
            string strendprice = Console.ReadLine();
            while (!double.TryParse(strendprice, out endprice))
            {
                Console.WriteLine("Zehmet olmasa meblegi duzgun daxil edin:");
                strendprice = Console.ReadLine();
            }
            if (endprice<=0)
            {
                throw new ArgumentOutOfRangeException("Mehsulun qiymeti menfi ola bilmez");

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
            Console.WriteLine("Zehmet olmasa mehsulun adin daxil edin:");
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
                if (sell<=0 ||sell>=3)
                {
                    throw new ArgumentOutOfRangeException("Daxil etdiyiniz emeliyyat mevcud deyil");

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
            Console.WriteLine("Zehmet olmasa qaytarmaq istediyiniz satisin NO-sun daxil edin");
            string strno = Console.ReadLine();
            while (!int.TryParse(strno, out no))
            {
                Console.WriteLine("Zehmet olmasa nomreni duzgun daxil edin");
                strno = Console.ReadLine();
            }
            Console.WriteLine("Zehmet olmasa qaytarmaq istediyiniz mehsulun adin daxil edin ");
            string name = Console.ReadLine();
            Console.WriteLine("Zehmet olmasa qaytarmaq istediyiniz mehsulun sayin daxil edin");
            string strcount = Console.ReadLine();
            while (!int.TryParse(strcount, out count))
            {
                Console.WriteLine("Zehmet olmasa duzgun say daxil edin");
                strcount = Console.ReadLine();
            }
            marketservice.ReturnofProduct(no,name,count); 
        }     
        public static void DeleteSale()
        {
            int no = 0;
            var table = new ConsoleTable("No", "Price", "Count", "Date");
            foreach(var sale in marketservice.Sales)
            {
                table.AddRow(sale.No, sale.Price, sale.Items.Count, sale.Date);
            }
            table.Write();
            Console.WriteLine();
            Console.WriteLine("Zehmet olmasa silmek istediyiniz satisin  No-sun daxil edin:");
            string strno = Console.ReadLine();
            while (!int.TryParse(strno, out no))
            {
                Console.WriteLine("Zehmet olmasa nomreni duzgun daxil edin");
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
            Console.WriteLine("Zehmet olmasa vaxti daxil edin (dd.mm.yyyy)");
            string strdate1 = Console.ReadLine();
            Console.WriteLine("Zehmet olmasa vaxti daxil edin (dd.mm.yyyy)");
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
            Console.WriteLine("Zehmet olmasa baslangic qiymeti daxil edin");
            string strprice1 = Console.ReadLine();
            while (!double.TryParse(strprice1, out price1))
            {
                Console.WriteLine("Zehmet olmasa duzgun mebleg daxil edin");
                strprice1 = Console.ReadLine();

            }
            Console.WriteLine("Zehmet olmasa son deyer qiymeti daxil edin");
            string endprice2 = Console.ReadLine();
            while (!double.TryParse(endprice2, out price2))
            {
                Console.WriteLine("Zehmet olmasa duzgun mebleg daxil edin");
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
            Console.WriteLine("(Zehmet olmasa vaxti daxil edin(dd.mm.yyyy))");
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
            Console.WriteLine("Zehmet olmasa daxil edin No");
            string strno = Console.ReadLine();
            while (!int.TryParse (strno ,out no))
            {
                Console.WriteLine("Zehmet olmasa daxil edin No:");
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

