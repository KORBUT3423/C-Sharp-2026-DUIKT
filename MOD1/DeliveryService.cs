using System;
using System.Collections.Generic;

class DeliveryService
{
    List<Transport> transports = new List<Transport>();
    List<Order> orders = new List<Order>();
    List<Order> history = new List<Order>();

    public void AddTransport(Transport t)
    {
        transports.Add(t);
    }

    public void AddOrder(Order o)
    {
        orders.Add(o);
    }

    public void ShowCosts(Order o)
    {
        Console.WriteLine("Замовлення " + o.Number + " (" + o.Description + "):");
        foreach (Transport t in transports)
        {
            if (t.CanTake(o))
                Console.WriteLine(t.Name + " - " + t.CalculateCost(o) + " грн");
        }
    }

    public void Assign(Order o, Transport t)
    {
        if (o.Transport != null)
        {
            Console.WriteLine("Замовлення " + o.Number + " вже призначене");
            return;
        }
        if (t.IsBusy)
        {
            Console.WriteLine(t.Name + " зайнятий");
            return;
        }
        if (!t.CanTake(o))
        {
            Console.WriteLine(t.Name + " не може взяти замовлення " + o.Number);
            return;
        }

        t.IsBusy = true;
        o.Transport = t;
        Console.WriteLine("Замовлення " + o.Number + " везе " + t.Name);
    }

    public void Deliver(Order o, IPayment payment)
    {
        if (o.Transport == null)
        {
            Console.WriteLine("Замовлення " + o.Number + " не призначене");
            return;
        }

        payment.Pay(o.Transport.CalculateCost(o));
        o.Transport.IsBusy = false;
        orders.Remove(o);
        history.Add(o);
        Console.WriteLine("Замовлення " + o.Number + " доставлено");
    }

    public void ShowOrders()
    {
        Console.WriteLine("Активні замовлення:");
        foreach (Order o in orders)
        {
            if (o.Transport == null)
                Console.WriteLine(o.Number + " " + o.Description + " - чекає");
            else
                Console.WriteLine(o.Number + " " + o.Description + " - " + o.Transport.Name);
        }
    }

    public void ShowHistory()
    {
        Console.WriteLine("Історія:");
        foreach (Order o in history)
        {
            Console.WriteLine(o.Number + " " + o.Description + " - " + o.Transport.Name);
        }
    }
}
