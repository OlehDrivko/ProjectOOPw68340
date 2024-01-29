class Orders : TotalID
{
    public static int CurentOrderID;
    public Product Product { get; set; }
    public Customer Customer { get; set; }
}