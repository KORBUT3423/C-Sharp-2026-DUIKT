class Order
{
    public int Number;
    public string Description;
    public double Weight;
    public double Distance;
    public Transport Transport; 

    public Order(int number, string description, double weight, double distance)
    {
        Number = number;
        Description = description;
        Weight = weight;
        Distance = distance;
    }
}