using ProjectOOPw68340;
using System.Xml.Linq;

namespace ProjectOOPw68340
{
    internal class Program
    {
        static Queue<Orders> KolejkaZamowien = new Queue<Orders>();
        static List<Product> Produkty = new List<Product>();
        static List<Customer> Klienci = new List<Customer>();
        static List<Customer> PremiumKlienci = new List<Customer>();
        static void Main(string[] args)
        {


            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Dodaj Product");
                Console.WriteLine("2. Zobacz Produkty");
                Console.WriteLine("2. Dodaj Klienta");
                Console.WriteLine("3. Dodaj Zamówienie");
                Console.WriteLine("4. Zobacz zamówienia");
                Console.WriteLine("5. Przetwórz zamówienie");
                Console.WriteLine("6. Wejśzie");

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
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
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