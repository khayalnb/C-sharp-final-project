using C_sharp_console_project.Services;
using System;
using System.Text;

namespace C_sharp_console_project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            {

                int a = 0;
                int b = 0;
                int c = 0;

                do
                {
                    Console.WriteLine("=*=*=*=*=*=*=*=*Bazar Store=*=*=*=*=*=*=*=");
                    Console.WriteLine("1 Mehsullar uzerinde emeliyyat etmek ");
                    Console.WriteLine("2 Satislar uzerinde emeliyyat etmek");
                    Console.WriteLine("3 Sistemden cixis");
                    Console.WriteLine("Hansi emeliyati etmek isteyirsiniz?");
                    string stra = Console.ReadLine();
                    while (!int.TryParse(stra, out a))
                    {
                        stra = Console.ReadLine();
                    }
                    switch (a)
                    {
                        case 1:
                            do
                            {
                                Console.WriteLine("1 Yeni mehsul elave et ");
                                Console.WriteLine("2 Mehsul uzerinde duzelis et");
                                Console.WriteLine("3 Mehsulu sil");
                                Console.WriteLine("4 Butun mehsullari goster");
                                Console.WriteLine("5 Categoriyasina gore mehsullari goster");
                                Console.WriteLine("6 Qiymet araligina gore mehsullari goster");
                                Console.WriteLine("7 Mehsullar arasinda ada gore axtaris et ");
                                Console.WriteLine("0-Exit");
                                Console.WriteLine("Hansı əməliyyati etmək istəyirsən?");
                                string strb = Console.ReadLine();
                                while (!int.TryParse(strb, out b))
                                {
                                    Console.WriteLine("Zehmet olmasa nomreni daxil edin");
                                    strb = Console.ReadLine();
                                }
                                switch (b)
                                {
                                    case 1:
                                        MenuService.AddProduct();
                                        break;
                                    case 2:
                                        MenuService.ChangeProducts();
                                        break;
                                    case 3:
                                        MenuService.ClearProduct();
                                        break;
                                    case 4:
                                        MenuService.AllProductsView();
                                        break;
                                    case 5:
                                        MenuService.SerachforCategoryproduct();
                                        break;
                                    case 6:
                                        MenuService.SearchforPricCeProduct();
                                        break;
                                    case 7:
                                        MenuService.SearchforNameProduct();
                                        break;

                                    default:
                                        break;
                                }
                            } while (b != 0);
                            break;
                        case 2:
                            do
                            {
                                Console.WriteLine("1-Add new sales");
                                Console.WriteLine("2-Return of sale");
                                Console.WriteLine("3-Delete sale");
                                Console.WriteLine("4-Display all sale");
                                Console.WriteLine("5-Display range of date sale");
                                Console.WriteLine("6-Display range of price sale");
                                Console.WriteLine("7-Display o the one day sale");
                                Console.WriteLine("8-Display of No sale");
                                Console.WriteLine("0-Exit");
                                Console.WriteLine("=================================");
                                Console.WriteLine("Which operation do you want to do");

                                string strc = Console.ReadLine();
                                while (!int.TryParse(strc, out c))
                                {
                                    Console.WriteLine("Ededi duzgun daxil edin");
                                    strc = Console.ReadLine();
                                }
                                //switch (c)
                                //{
                                //    case 1:
                                //        MenuServices.YenisatisElaveEtmek();
                                //        break;
                                //    case 2:
                                //        MenuServices.MehsulunGeriqaytarilmasi();
                                //        break;
                                //    case 3:
                                //        MenuServices.SatisinSilinmesi();
                                //        break;
                                //    case 4:
                                //        MenuServices.UmumiSatisinQaytarilmasi();
                                //        break;
                                //    case 5:
                                //        MenuServices.TarixeGoreTapmaq();
                                //        break;
                                //    case 6:
                                //        MenuServices.QiymeteGoreTapmaq();
                                //        break;
                                //    case 7:
                                //        MenuServices.TekZamanGoreSatisinTapilmasi();
                                //        break;
                                //    case 8:
                                //        MenuServices.NomreyeGoreTapmaq();
                                //        break;
                                //    default:
                                //        break;
                                //}


                            } while (c != 0);
                            break;

                        default:
                            break;
                    }

                } while (a != 3);
            }
        }

    }
}

