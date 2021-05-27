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
               

                int sl1 = 0;
                int sl2 = 0;
                int sl3= 0;

                do
                {
                    Console.WriteLine("=*=*=*=*=*=*=*=*Bazar Store=*=*=*=*=*=*=*=");
                    Console.WriteLine("1 Mehsullar uzerinde emeliyyat etmek ");
                    Console.WriteLine("2 Satislar uzerinde emeliyyat etmek");
                    Console.WriteLine("3 Sistemden cixis");
                    Console.WriteLine("Hansi emeliyyati etmek isteyirsiniz?");
                    string selection = Console.ReadLine();
                    while (!int.TryParse(selection, out sl1))
                    {
                        selection = Console.ReadLine();
                    }
                    switch (sl1)
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
                                Console.WriteLine("Hansı əməliyyati etmək istəyirsiniz?");
                                string strb = Console.ReadLine();
                                while (!int.TryParse(strb, out sl2))
                                {
                                    Console.WriteLine("Zehmət olmasa nomrəni daxil edin");
                                    strb = Console.ReadLine();
                                }
                                switch (sl2)
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
                            } while (sl2 != 0);
                            break;
                        case 2:
                            do
                            {
                                Console.WriteLine("1 Yeni satis elave etmek");
                                Console.WriteLine("2 Satisdaki hansisa mehsulun geri qaytarilmasi");
                                Console.WriteLine("3 Satisin silinmesi");
                                Console.WriteLine("4 Butun satislarin ekrana cixarilmasi");
                                Console.WriteLine("5 Verilen tarix araligina gore satislarin gosterilmesi");
                                Console.WriteLine("6 Verilen mebleg araligina gore satislarin gosterilmesi ");
                                Console.WriteLine("7 Verilmis bir tarixde olan satislarin gosterilmesi");
                                Console.WriteLine("8 Verilmis nomreye esasen hemin nomreli satisin melumatlarinin gosterilmesi");
                                Console.WriteLine("0 Çixiş");
                                Console.WriteLine("=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");
                                Console.WriteLine("Hansı əməliyyatı etmək istəyirsiniz?");

                                string strc = Console.ReadLine();
                                while (!int.TryParse(strc, out sl3))
                                {
                                    Console.WriteLine("Ədedi duzgun daxil edin");
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


                            } while (sl3 != 0);
                            break;

                        default:
                            break;
                    }

                } while (sl1 != 3);
            }
        }

    }
}

