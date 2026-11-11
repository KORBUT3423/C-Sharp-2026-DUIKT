class Bike : Transport
{
    public Bike()
    {
        Name = "Велосипед";
        MaxWeight = 10;
    }

    public override double CalculateCost(Order order)
    {
        return 20 + 5 * order.Distance;
    }

    public override bool CanTake(Order order)
    {
        if (order.Distance > 10)
            return false;
        return base.CanTake(order);
    }
}