using ProjectOOPw68340;
using System.Xml.Linq;

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
                        break;
                    case 2:
                            foreach (var produkt in Produkty)
                            {
                            Console.WriteLine($"Product ID: {produkt.ProductID}, Name: {produkt.Name}, Price: {produkt.PriceOfProduct}");
                            }
                        break;
                    case 3:
                        DodajKlienta();
                        break;
                    case 4:
                        DodajVIPklienta();
                        break;
                    case 5:
                        foreach (var klient in Klienci)
                        {
                            Console.WriteLine($"Customer ID: {klient.CustomerID}, Name: {klient.Name}, Age: {klient.Age}");
                        }
                        foreach (var PremiumKlienci in PremiumKlienci)
                        {
                            Console.WriteLine($"VIP Customer ID: {PremiumKlienci.CustomerID},\n Name: {PremiumKlienci.Name},\n Age: {PremiumKlienci.Age},\n MembershipLevel: {PremiumKlienci.MembershipLevel},\n Discount: {PremiumKlienci.Discount} % ");
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