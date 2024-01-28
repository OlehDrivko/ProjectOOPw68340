namespace ProjectOOPw68340
{
    internal class Program
    {
        static Queue<Orders> KolejkaZamowien = new Queue<Orders>();
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
                Console.WriteLine("7. Zobacz zamówienia");
                Console.WriteLine("8. Przetwórz zamówienie");
                Console.WriteLine("9. Wejśzie");

                int choice = GetUserChoice();

                switch (choice)
                {
                    case 1:
                        DodajProduct();
                        ZapiszDane();
                        break;
                    case 2:
                            foreach (var produkt in Produkty)
                            {
                            Console.WriteLine($"Product ID: {produkt.ProductID}, Name: {produkt.Name}, Price: {produkt.PriceOfProduct}");
                            }
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
                        foreach (var klient in Klienci)
                        {
                            Console.WriteLine($"Customer ID: {klient.CustomerID};\n Name: {klient.Name};\n Age: {klient.Age};");
                            Console.WriteLine("--------------------------");
                        }
                        foreach (var PremiumKlienci in PremiumKlienci)
                        {
                            Console.WriteLine($"VIP Customer ID: {PremiumKlienci.CustomerID};\n Name: {PremiumKlienci.Name};\n Age: {PremiumKlienci.Age};\n MembershipLevel: {PremiumKlienci.MembershipLevel};\n Discount: {PremiumKlienci.Discount}%; ");
                            Console.WriteLine("--------------------------");

                        }
                        break;
                    case 6:
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Zły wybór. Spróbuj ponownie.");
                        break;
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

            }
            }
        }


        class TotalID
    {
        public int ProductID;
        public int CustomerID ;
        public int OrderID;
    }

    class Product :  TotalID
    {
        protected static int CurentProductID;
        public string Name { get; set; }
        public decimal PriceOfProduct { get; set; }

        public Product()
        {
            CurentProductID++;
            ProductID = CurentProductID;
        }
    }


    class Customer : TotalID
    {
        protected static int CurentCustomerID;
        public string Name { get; set; }
        public double Age { get; set; }
        public Customer() 
        {
            CurentCustomerID++;
            CustomerID = CurentCustomerID;
        }
    }
    class PremiumCustomer : Customer
    {
        public string MembershipLevel { get; set; }
        public double Discount { get; set; }
    }


    class Orders : TotalID
    {
        protected static int CurentOrderID;
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public Orders(Product product, Customer customer)
        {
            CurentOrderID++;
            OrderID = CurentOrderID;
            Product = product;
            Customer = customer;
        }
    }
}