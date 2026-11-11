class Car : Transport
{
    public Car()
    {
        Name = "Автомобіль";
        MaxWeight = 300;
    }

    public override double CalculateCost(Order order)
    {
        return 50 + 8 * order.Distance + order.Weight;
    }
}