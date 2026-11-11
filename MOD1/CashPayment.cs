using System;

class CashPayment : IPayment
{
    public void Pay(double sum)
    {
        Console.WriteLine("Оплачено готівкою " + sum + " грн");
    }
}