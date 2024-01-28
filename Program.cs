using ProjectOOPw68340;

namespace ProjectOOPw68340
{
    internal class Program
    {
        static void Main(string[] args)
        {

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