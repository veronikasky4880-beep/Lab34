using System;
namespace Lab34
{
    public class MobileAccount
    {
        private decimal balance;
        private string packageName;
        private bool packageActive;
        private int totalCallMinutes;

        public decimal MinimumBalance { get; } = 10;

        public event EventHandler<BalanceEventArgs>? BalanceReachedMinimum;

        public MobileAccount(decimal initialBalance)
        {
            balance = initialBalance;
            packageName = "Не активовано";
            packageActive = false;
            totalCallMinutes = 0;
        }

        public void ActivatePackage(string name)
        {
            packageName = name;
            packageActive = true;

            Console.WriteLine("Тарифний пакет \"" + packageName + "\" активовано.");
        }

        public void TopUp(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сума поповнення повинна бути більшою за 0.");
                return;
            }

            balance += amount;

            Console.WriteLine("Рахунок поповнено на " + amount + " грн.");
            Console.WriteLine("Поточний баланс: " + balance + " грн.");
        }

        public void RegisterCall(int minutes, decimal costPerMinute)
        {
            if (minutes <= 0 || costPerMinute <= 0)
            {
                Console.WriteLine("Некоректні дані дзвінка.");
                return;
            }

            decimal callCost = minutes * costPerMinute;

            if (callCost > balance)
            {
                Console.WriteLine("Недостатньо коштів для здійснення дзвінка.");
                return;
            }

            decimal previousBalance = balance;

            balance -= callCost;
            totalCallMinutes += minutes;

            Console.WriteLine("Тривалість дзвінка: " + minutes + " хв.");
            Console.WriteLine("Вартість дзвінка: " + callCost + " грн.");
            Console.WriteLine("Поточний баланс: " + balance + " грн.");

            if (previousBalance > MinimumBalance &&
                balance <= MinimumBalance)
            {
                OnBalanceReachedMinimum(
                    new BalanceEventArgs(previousBalance, balance, MinimumBalance)
                );
            }
        }

        public void ShowStatus()
        {
            Console.WriteLine("\n--- Стан мобільного рахунку ---");
            Console.WriteLine("Тарифний пакет: " + packageName);
            Console.WriteLine("Статус пакета: " + (packageActive ? "Активний" : "Неактивний"));
            Console.WriteLine("Баланс: " + balance + " грн.");
            Console.WriteLine("Мінімальний баланс: " + MinimumBalance + " грн.");
            Console.WriteLine("Загальна тривалість дзвінків: " + totalCallMinutes + " хв.");
        }

        protected virtual void OnBalanceReachedMinimum(BalanceEventArgs e)
        {
            BalanceReachedMinimum?.Invoke(this, e);
        }
    }
}
