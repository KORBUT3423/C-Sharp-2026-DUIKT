using System;

class CardPayment : IPayment
{
    public void Pay(double sum)
    {
        Console.WriteLine("Оплачено карткою " + sum + " грн");
    }
}