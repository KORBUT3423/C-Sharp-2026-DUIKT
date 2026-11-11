class Truck : Transport
{
    public Truck()
    {
        Name = "Вантажівка";
        MaxWeight = 5000;
    }

    public override double CalculateCost(Order order)
    {
        return 200 + 15 * order.Distance + 0.5 * order.Weight;
    }
}