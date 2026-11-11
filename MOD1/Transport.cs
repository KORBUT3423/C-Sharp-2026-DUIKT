abstract class Transport
{
    public string Name;
    public double MaxWeight;
    public bool IsBusy;

    public abstract double CalculateCost(Order order);

    public virtual bool CanTake(Order order)
    {
        return order.Weight <= MaxWeight;
    }
}