class TotalID
{
    private static int currentProductID = 0;
    private static int currentCustomerID = 0;
    private static int currentOrderID = 0;

    public int ProductID { get; set; }
    public int CustomerID { get; set; }
    public int OrderID { get; set; }

    public TotalID()
    {
        ProductID = ++currentProductID;
        CustomerID = ++currentCustomerID;
        OrderID = ++currentOrderID;
    }
}
