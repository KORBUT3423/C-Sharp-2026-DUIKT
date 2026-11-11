using System;
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        DeliveryService service = new DeliveryService();
        Bike bike = new Bike();
        Car car = new Car();
        Truck truck = new Truck();
        service.AddTransport(bike);
        service.AddTransport(car);
        service.AddTransport(truck);
        Order o1 = new Order(1, "Піца", 2, 5);
        Order o2 = new Order(2, "Документи", 1, 25);
        Order o3 = new Order(3, "Холодильник", 80, 12);
        Order o4 = new Order(4, "Цегла", 2000, 40);
        service.AddOrder(o1);
        service.AddOrder(o2);
        service.AddOrder(o3);
        service.AddOrder(o4);
// вартість
        service.ShowCosts(o1);
        service.ShowCosts(o2);
        service.ShowCosts(o3);
        service.ShowCosts(o4);
        Console.WriteLine();
// призначення
        service.Assign(o1, bike);
        service.Assign(o2, bike); 
        service.Assign(o4, car); 
        service.Assign(o1, car); 
        service.Assign(o3, car);
        service.Assign(o4, truck);
        Console.WriteLine();
        service.ShowOrders();
        Console.WriteLine();
// доставка
        service.Deliver(o1, new CardPayment());
        service.Deliver(o3, new CashPayment());
        service.Deliver(o2, new CardPayment()); 
        Console.WriteLine();
// велосипед вільний, але далеко
        service.Assign(o2, bike);
        service.Assign(o2, car);
        Console.WriteLine();
        service.ShowOrders();
        service.ShowHistory();
    }
}