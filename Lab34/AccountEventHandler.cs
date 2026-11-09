using System;

namespace Lab34
{
    public class AccountEventHandler
    {
        public void HandleBalanceReachedMinimum(object? sender, BalanceEventArgs e)
        {
            Console.WriteLine("\nУВАГА! Баланс рахунку досяг мінімального значення!");
            Console.WriteLine("Попередній баланс: " + e.PreviousBalance + " грн.");
            Console.WriteLine("Поточний баланс: " + e.CurrentBalance + " грн.");
            Console.WriteLine("Мінімальний баланс: " + e.MinimumBalance + " грн.");

            if (sender is MobileAccount)
            {
                Console.WriteLine("Подія надійшла від об'єкта мобільного рахунку.");
            }
        }
    }
}
