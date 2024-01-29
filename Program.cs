using System.Collections;

namespace ProjectOOPw68340
{
    internal class Program
    {
        static Queue<Orders> KolejkaZamowien = new Queue<Orders>();
        static Queue<VipOrders> VipKolejkaZamowiem = new Queue<VipOrders>();
        static List<Product> Produkty = new List<Product>();
        static List<Customer> Klienci = new List<Customer>();
        static List<PremiumCustomer> PremiumKlienci = new List<PremiumCustomer>();
        static void Main(string[] args)
        {

            WczytajDAne();
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Dodaj Product");
                Console.WriteLine("2. Zobacz Produkty");
                Console.WriteLine("--------------------------");
                Console.WriteLine("3. Dodaj Klienta");
                Console.WriteLine("4. Dodaj VIP Klienta");
                Console.WriteLine("5. Zobacz Klientów");
                Console.WriteLine("--------------------------");
                Console.WriteLine("6. Dodaj Zamówienie");
                Console.WriteLine("7. Dodaj VIP Zamówienie");
                Console.WriteLine("8. Zobacz zamówienia");
                Console.WriteLine("9. Przetwórz zamówienie");
                Console.WriteLine("10. Przetwórz VIP zamówienie");
                Console.WriteLine("11. Wejśzie");

                int choice = GetUserChoice();

                switch (choice)
                {
                    case 1:
                        DodajProduct();
                        ZapiszDane();
                        break;
                    case 2:
                        WyswietlProdukty();
                        break;
                    case 3:
                        DodajKlienta();
                        ZapiszDane();
                        break;
                    case 4:
                        DodajVIPklienta();
                        ZapiszDane();
                        break;
                    case 5:
                        Console.WriteLine("Klienci:");
                        WyswietlKlientów();
                        Console.WriteLine("VIP Klienci:");
                        WyswitlVIPKlientów();
                        break;
                    case 6:
                        DodajZamowienie();
                        ZapiszDane();
                        break;
                    case 7:
                        DodajVIPZamowienie();
                        ZapiszDane();
                        break;
                    case 8:
                        WyswietlZamowienie();
                        break;
                    case 9:
                        ProcessOrders();
                        ZapiszDane();
                        break;
                    case 10:
                        ProcessVIPOrders();
                        ZapiszDane();
                        break;
                    case 11:
                        ZapiszDane();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Zły wybór. Spróbuj ponownie.");
                        break;
                }
            }
            static void WyswietlProdukty()
            {
                foreach (var produkt in Produkty)
                {
                    Console.WriteLine($"Product ID: {produkt.ProductID}, Name: {produkt.Name}, Price: {produkt.PriceOfProduct}");
                }
            }
            static void WyswietlKlientów()
            {
                foreach (var klient in Klienci)
                {
                    Console.WriteLine($"Customer ID: {klient.CustomerID};\n Name: {klient.Name};\n Age: {klient.Age};");
                    Console.WriteLine("--------------------------");
                }
            }
            static void WyswitlVIPKlientów()
            {
                foreach (var PremiumKlienci in PremiumKlienci)
                {
                    Console.WriteLine($"VIP Customer ID: {PremiumKlienci.CustomerID};\n Name: {PremiumKlienci.Name};\n Age: {PremiumKlienci.Age};\n MembershipLevel: {PremiumKlienci.MembershipLevel};\n Discount: {PremiumKlienci.Discount}%; ");
                    Console.WriteLine("--------------------------");

                }
            }
            static int GetUserChoice()
            {
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Wpisz numer opcji.");
                }
                return choice;
            }
            static void DodajProduct()
            {
                Console.Write("Podaj nazwę produktu: ");
                string ProductsName = Console.ReadLine();
                Console.Write("Podaj cenę produktu: ");
                decimal PriceOfProduct = decimal.Parse(Console.ReadLine());

                Product produkt = new Product { Name = ProductsName, PriceOfProduct = PriceOfProduct };
                Produkty.Add(produkt);
                Console.WriteLine("Produkt dodany pomyślnie.");

            }
            static void DodajKlienta()
            {
                Console.WriteLine("Podaj Imię klienta: ");
                string CustomerName = Console.ReadLine();
                Console.WriteLine("Podaj wiek klienta:");
                double WiekKlienta = double.Parse(Console.ReadLine());

                Customer customer = new Customer { Name = CustomerName, Age = WiekKlienta };
                Klienci.Add (customer);
                Console.WriteLine("Klient dodany pomyślnie.");
            }
            static void DodajVIPklienta()
            {
                Console.WriteLine("Podaj Imię VIP klienta: ");
                string VIPCustomerName = Console.ReadLine();
                Console.WriteLine("Podaj wiek VIP klienta:");
                double WiekVIPKlienta = double.Parse(Console.ReadLine());
                Console.WriteLine("Podaj związek:");
                string MembershipLevelWithVIPCUSTOMER = Console.ReadLine();
                Console.WriteLine("Podaj ile obniżki:");
                double DiscountVIP = double.Parse(Console.ReadLine());

                PremiumCustomer premiumCustomer = new PremiumCustomer { Name = VIPCustomerName, Age = WiekVIPKlienta , MembershipLevel = MembershipLevelWithVIPCUSTOMER, Discount = DiscountVIP };
                PremiumKlienci.Add(premiumCustomer);
                Console.WriteLine(" VIP Klient dodany pomyślnie. ");
            }
            static void ZapiszDane()
            {
                using (StreamWriter pisarz = new StreamWriter("produkty.txt"))
                {
                    foreach (var produkt in Produkty)
                    {
                        pisarz.WriteLine($"{produkt.ProductID},{produkt.Name},{produkt.PriceOfProduct}");
                    }
                }

                using (StreamWriter pisarz = new StreamWriter("klienci.txt"))
                {
                    foreach (var klient in Klienci)
                    {
                        pisarz.WriteLine($"{klient.CustomerID},{klient.Name},{klient.Age}");
                    }
                }
                using (StreamWriter pisarz = new StreamWriter("klienciVIP.txt"))
                {
                    foreach (var vipklient in PremiumKlienci)
                    {
                        pisarz.WriteLine($"{vipklient.CustomerID},{vipklient.Name},{vipklient.Age},{vipklient.MembershipLevel},{vipklient.Discount}");
                    }
                }
                using (StreamWriter pisarz = new StreamWriter("zamowienia.txt"))
                {
                    foreach (var zamowienie in KolejkaZamowien)
                    {
                        pisarz.WriteLine($"{zamowienie.OrderID},{zamowienie.Product.ProductID},{zamowienie.Customer.CustomerID}");
                    }
                }


            }
            static void WczytajDAne()
            {
                if (File.Exists("produkty.txt"))
                {
                    string[] linieProduktow = File.ReadAllLines("produkty.txt");
                    foreach (var linia in linieProduktow)
                    {
                        string[] czesci = linia.Split(',');
                        int id = int.Parse(czesci[0]);
                        string nazwa = czesci[1];
                        decimal cena = decimal.Parse(czesci[2]);
                        Produkty.Add(new Product { ProductID = id, Name = nazwa, PriceOfProduct = cena });
                    }
                }
                if (File.Exists("klienci.txt"))
                {
                    string[] linieKlientow = File.ReadAllLines("klienci.txt");
                    foreach (var linia in linieKlientow)
                    {
                        string[] czesci = linia.Split(',');
                        int id = int.Parse(czesci[0]);
                        string nazwa = czesci[1];
                        double age = double.Parse(czesci[2]);
                        Klienci.Add(new Customer { CustomerID = id, Name = nazwa, Age = age,  });
                    }
                }
                if (File.Exists("klienciVIP.txt"))
                {
                    string[] linieVIPKlientow = File.ReadAllLines("klienciVIP.txt");
                    foreach (var linia in linieVIPKlientow)
                    {
                        string[] czesci = linia.Split(',');
                        int id = int.Parse(czesci[0]);
                        string nazwa = czesci[1];
                        double age = double.Parse(czesci[2]);
                        string membershipLevel = czesci[3];
                        double discount = double.Parse(czesci[4]);

                        PremiumKlienci.Add(new PremiumCustomer { CustomerID = id, Name = nazwa, Age = age, MembershipLevel = membershipLevel, Discount = discount });
                    }
                }

                if (File.Exists("zamowienia.txt"))
                {
                    string[] linieZamowien = File.ReadAllLines("zamowienia.txt");
                    foreach (var linia in linieZamowien)
                    {
                        string[] czesci = linia.Split(',');
                        int idZamowienia = int.Parse(czesci[0]);
                        int idProduktu = int.Parse(czesci[1]);
                        int idKlienta = int.Parse(czesci[2]);

                        Product produkt = Produkty.Find(p => p.ProductID == idProduktu);
                        Customer klient = Klienci.Find(c => c.CustomerID == idKlienta);

                        KolejkaZamowien.Enqueue(new Orders { OrderID = idZamowienia, Product = produkt, Customer = klient});
                    }
                }

            }
            static void DodajZamowienie()
            {
                if (Produkty.Count == 0 || Klienci.Count == 0)
                {
                    Console.WriteLine("Dodaj przynajmniej jeden produkt i jednego klienta.");
                    return;
                }
                Console.WriteLine("Lista produktów:");
                WyswietlProdukty();
                Console.WriteLine("Podaj ID produktu do zamówienia:");
                int WybranyProductID = int.Parse(Console.ReadLine());
                Product ZamówionyProduct = Produkty.Find(p => p.ProductID == WybranyProductID);
                if (ZamówionyProduct == null)
                {
                    Console.WriteLine("Product o podanym ID nie znaleziony!");
                    return;
                }
                Console.WriteLine("Lista Klientów:");
                WyswietlKlientów();
                Console.WriteLine("Podaj ID Klienta do zamówienia:");
                int WybranyKlientID = int.Parse(Console.ReadLine());
                Customer WybranyKlient = Klienci.Find(k => k.CustomerID == WybranyKlientID);
                Orders Zamowienie = new Orders
                {
                    Product = ZamówionyProduct,
                    Customer = WybranyKlient
                };
                KolejkaZamowien.Enqueue(Zamowienie);
                Console.WriteLine("Zamówienie dodane pomyślnie.");
            }
            static void DodajVIPZamowienie()
                {
                    Console.WriteLine("Lista produktów:");
                    WyswietlProdukty();
                    Console.WriteLine("Podaj ID produktu do zamówienia:");
                    int WybranyProductID = int.Parse(Console.ReadLine());
                    Product ZamówionyProduct = Produkty.Find(p => p.ProductID == WybranyProductID);
                    if (ZamówionyProduct == null)
                    {
                        Console.WriteLine("Product o podanym ID nie znaleziony!");
                        return;
                    }
                    Console.WriteLine("Lista VIP Klientów:");
                    WyswitlVIPKlientów();
                    Console.WriteLine("Podaj ID VIP Klienta do zamówienia:");
                    int WybranyKlientID = int.Parse(Console.ReadLine());
                    PremiumCustomer WybranyVIPKlient = PremiumKlienci.Find(pk => pk.CustomerID == WybranyKlientID);
                    VipOrders ZamowienieVIP = new VipOrders
                    {
                        Product = ZamówionyProduct,
                        PremiumCustomer = WybranyVIPKlient
                    };
                    VipKolejkaZamowiem.Enqueue(ZamowienieVIP);
                    Console.WriteLine("Zamówienie dodane pomyślnie.");
                }
            static void WyswietlZamowienie()
            {
                foreach (var zamowienia in KolejkaZamowien)
                {
                    Console.WriteLine($" Zamówienie o ID: {zamowienia.OrderID} :\n Klient : ID - {zamowienia.Customer.CustomerID}, Imię - {zamowienia.Customer.Name}, Wiek - {zamowienia.Customer.Age};\n Zamówiony produkt : ID - {zamowienia.Product.ProductID}, Nazwa - {zamowienia.Product.Name}, Cena - {zamowienia.Product.PriceOfProduct};   ");
                }
                foreach (var zamowieniaVIP in VipKolejkaZamowiem)
                {
                    Console.WriteLine($" Zamówienie o ID: {zamowieniaVIP.OrderID} :\n Klient : ID - {zamowieniaVIP.PremiumCustomer.CustomerID}, Imię - {zamowieniaVIP.PremiumCustomer.Name}, Wiek - {zamowieniaVIP.PremiumCustomer.Age}, Status - {zamowieniaVIP.PremiumCustomer.MembershipLevel};\n Zamówiony produkt : ID - {zamowieniaVIP.Product.ProductID}, Nazwa - {zamowieniaVIP.Product.Name}, Cena - {zamowieniaVIP.Product.PriceOfProduct}, Istnieje możliwość rabatu - {zamowieniaVIP.PremiumCustomer.Discount}%;   ");

                }
            }
            static void ProcessOrders()
            {
                if (KolejkaZamowien.Count == 0)
                {
                    Console.WriteLine("Niema zamówień.");
                    return;
                }

                Orders order = KolejkaZamowien.Dequeue();
                Console.WriteLine($"Zamówienie Obrobione: Klien: {order.Customer.Name}, Product: {order.Product.Name}, Cena: {order.Product.PriceOfProduct}, ");
            }
            static void ProcessVIPOrders()
            {
                if (KolejkaZamowien.Count == 0)
                {
                    Console.WriteLine("Niema zamówień.");
                    return;
                }

                VipOrders Viporder = VipKolejkaZamowiem.Dequeue();
                Console.WriteLine($"Zamówienie Obrobione: Klien: {Viporder.PremiumCustomer.Name}, Product: {Viporder.Product.Name}, Cena: {Viporder.Product.PriceOfProduct}, Status : {Viporder.PremiumCustomer.MembershipLevel}, Promocja : {Viporder.PremiumCustomer.Discount};");
            }

        }
        }
    }