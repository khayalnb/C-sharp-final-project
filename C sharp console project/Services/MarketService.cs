using C_sharp_console_project.Date.Entities;
using System;
using ConsoleTables;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_console_project.Services
{
    class MarketService:IMarketable
    {
        //Product Methods
        public List<Product> Products { get; set; }
        public List<Sale> Sales { get; set; }
        public MarketService()
        {
            Products = new();
            Sales = new();
        }
        
        public void AddProduct(string productname, double price, int productcount, Category category)
        {
            Product product = new();
            product.ProductName = productname;
            product.Price = price;
            product.Categories = category;
            product.ProductCount = productcount;
            Products.Add(product);
        }
        public void ChangeProduct(int a)
        {
            int b = 0;
            double c = 0;
            int d = 0;
            var change = Products.FirstOrDefault(i => i.No == a);
            if (change==null)
            {
                throw new ArgumentNullException("Bele bir mehsul yoxdur");

            }
            do
            {
                Console.WriteLine("1 Adi deyis");
                Console.WriteLine("2 Kateqoriyani deyis");
                Console.WriteLine("3 Qiymeti deyis");
                Console.WriteLine("4 Sayi deyis");
                Console.WriteLine("5 cixis");
                Console.WriteLine("Hansı emeliyyat etmek istəyirsen?");
                string strb = Console.ReadLine();
                while (!int.TryParse(strb, out b))
                {
                    Console.WriteLine("Zehmet olmasa duzgun reqem daxil edin");
                    strb = Console.ReadLine();
                }
                if (b<=0 ||b>=6)
                {
                    throw new ArgumentOutOfRangeException("Daxil etdiyiniz emeliyyat movcud deyil");

                }

                switch (b)
                {
                    case 1:
                        Console.WriteLine("Adi daxil et");
                        string newname = Console.ReadLine();
                        change.ProductName = newname;
                        break;
                    case 2:
                        Console.WriteLine("Kateqoriyani daxil et");
                        Console.WriteLine("Categories");
                        int index = 1;
                        foreach(var item in Enum.GetValues(typeof(Category)))
                        {
                            Console.WriteLine($"{index}.{item}");
                            index++;

                        }
                        int pick = 0;
                        Console.WriteLine("Zehmet olmasa kateqoriyani secin");
                        string strpick = Console.ReadLine();
                        while(!int.TryParse(strpick,out pick))
                        {
                            Console.WriteLine("Zehmet olmasa duzgun reqem daxil edin");
                            strpick = Console.ReadLine();
                        }
                        if (pick <= 0 || pick >= 6)
                        {
                            throw new ArgumentNullException("Daxil etdiyiniz kateqoriya movcud deyil");

                        }

                        Category sort = new();

                        switch (pick)
                        {
                            case (int)Category.Cake:
                                sort = Category.Cake;
                                break;
                            case(int)Category.Chocolate:
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
                        break;
                    case 3:
                        Console.WriteLine("Meblegi daxil et");
                        string doubl = Console.ReadLine();
                        while (!double.TryParse(doubl, out c))
                        {
                            Console.WriteLine("Duzgun reqem daxil et");
                            doubl = Console.ReadLine();
                        }
                        change.Price = c;
                        break;
                    case 4:
                        Console.WriteLine("Sayi daxil edin");
                        string newcount = Console.ReadLine();
                        while (!int.TryParse(newcount, out d))
                        {
                            Console.WriteLine("Duzgun reqem daxil et");
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
            if (index==-1)
            {
                throw new ArgumentOutOfRangeException("Daxil etdiyiniz mehsul movcud deyil");

            }
            Products.RemoveAt(index);
        }
        public List<Product> SerchforCategoryProduct(Category category)
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
        public void AddSale(int no, int count ,Sale sale)
        {
            SaleItem saleItem = new();

            int index = Products.FindIndex(a => a.No == no);
            if (index==-1)
            {
                throw new ArgumentOutOfRangeException("Daxil etdiyiniz mehsul movcud deyil");

            }
            var result = Products.ElementAt(index);
            result.ProductCount = result.ProductCount - count;
            if (result.ProductCount<0)
            {
                throw new ArgumentNullException("Daxil etdiyiniz sayda mehsul movcud deyil");

            }
            double b = (double)(result.Price * count);
            sale.Price  += b;
            saleItem.products = result;
            saleItem.Quantity += count;
            sale.Items.Add(saleItem);
            
        }
        public void ReturnofProduct(int no, string name, int count)
        {
            Sale sale = Sales.FirstOrDefault(a => a.No == no);
            if (sale==null)
            {
                throw new ArgumentNullException("Daxil etdiyiniz satis movcud deyil");

            }
            SaleItem saleitem = sale.Items.FirstOrDefault(a => a.Quantity >= count);
            Product product = Products.FirstOrDefault(a => a.ProductName == name);
            if (product==null)
            {
                throw new ArgumentOutOfRangeException("Daxil etdiyiniz mehsul movcud deyil");

            }
            sale.Items.Remove(saleitem);
            product.ProductCount += count;
            sale.Price -= product.Price * count;
            if (saleitem.Quantity-count<=-1)
            {
                throw new ArgumentNullException("Daxil etdiyiniz satisda bu qeder mehsul movcud deyil");

            }
            saleitem.Quantity -= count;
            sale.Items.Add(saleitem);

        }
        public void DeleteSale(int no)
        {
            int index = Sales.FindIndex(a => a.No == no);
            if (index==-1 )
            {
                throw new ArgumentNullException("Daxil etdiyiniz satis movcud deyil");

            }
            Sales.RemoveAt(index);
        }
        public List<Sale> RangeOfDateSale(DateTime dates,DateTime datee)
        {
            var result = Sales.FindAll(a => a.Date >= dates && a.Date <= datee);
            return result.ToList();
        }
        public List<Sale> RangeOfPriceSale(double price1,double price2)
        {
            var result = Sales.FindAll(a => a.Price >= price1 && a.Price <= price2);
            return result.ToList();
        }
        public List<Sale> OneDayDale(DateTime day)
        {
            var result = Sales.FindAll(a => a.Date.Day == day.Day && a.Date.Month == day.Month && a.Date.Year == day.Year); 
            return result.ToList();
        }
        public List<Sale> TheNoSale(int no)
        {
            var result = Sales.FindAll(a => a.No == no);
            if (result.Count==0)
            {
                throw new ArgumentNullException($"{no}  nomreli satis movcud deyil");

            }
            return result.ToList();
        }

    }
}
