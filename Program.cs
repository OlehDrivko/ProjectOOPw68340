using ProjectOOPw68340;

namespace ProjectOOPw68340
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Dodaj Product");
                Console.WriteLine("2. Dodaj Klienta");
                Console.WriteLine("3. Dodaj Zamówienie");
                Console.WriteLine("4. Zobacz zamówienia");
                Console.WriteLine("5. Przetwórz zamówienie");
                Console.WriteLine("6. Wejśzie");

                int choice = GetUserChoice();

                switch (choice)
                {
                    case 1:
                        
                        break;
                    case 2:
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



        }
    }

    class TotalID
    {
        public int ProductID = 0 ;
        public int CustomerID = 0;
        public int OrderID = 0;
    }

    class Product :  TotalID
    {
        protected int CurentProductID;
        public string Name { get; set; }
        public string PriceOfProduct { get; set; }

        public Product(string ProductName, string ProductPriceOfProduct)
        {
            this.Name = ProductName;
            this.PriceOfProduct = ProductPriceOfProduct;
            CurentProductID++;
            ProductID = CurentProductID;
        }
    }


    class Customer : TotalID
    {
        protected int CurentCustomerID;
        public string Name { get; set; }
        public double Age { get; set; }
        public Customer(string CustomerName, double CustomerAge) 
        {
            this.Name= CustomerName;
            this.Age = CustomerAge;
            CurentCustomerID++;
            CustomerID = CurentCustomerID;
        }
    }
    class PremiumCustomer : Customer
    {
        public string MembershipLevel { get; set; }
        public double Discount { get; set; }

        public PremiumCustomer(string customerName, int customerAge, string membershipLevel, double discount) : base(customerName, customerAge)
        {
            MembershipLevel = membershipLevel;
            Discount = discount;
        }
    }


    class Orders : TotalID
    {
        protected int CurentOrderID;
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