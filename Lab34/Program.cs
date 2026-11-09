using System;
namespace Lab34
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            
            Console.WriteLine("ЗАВДАННЯ 1. ДЕЛЕГАТИ\n");

            char[,] matrix =
            {
                { 'А', 'Б', 'В' },
                { 'Г', 'Д', 'Е' },
                { 'Ж', 'З', 'И' }
            };

            DiagonalDelegate diagonal;
            // Анонімний метод
            diagonal = delegate (char[,] arr)
            {
                int size = Math.Min(arr.GetLength(0), arr.GetLength(1));
                char[] result = new char[size];

                for (int i = 0; i < size; i++)
                {
                    result[i] = arr[i, i];
                }

                return new string(result);
            };

            Console.WriteLine("Анонімний метод: " + diagonal(matrix));
            // Лямбда-вираз
            diagonal = (char[,] arr) =>
            {
                int size = Math.Min(arr.GetLength(0), arr.GetLength(1));
                char[] result = new char[size];

                for (int i = 0; i < size; i++)
                {
                    result[i] = arr[i, i];
                }

                return new string(result);
            };

            Console.WriteLine("Лямбда-вираз: " + diagonal(matrix));

            Console.WriteLine("\nЗАВДАННЯ 2. МОБІЛЬНИЙ РАХУНОК\n");

            MobileAccount account = new MobileAccount(50);

            AccountEventHandler handler = new AccountEventHandler();
            // Підписка на подію
            account.BalanceReachedMinimum += handler.HandleBalanceReachedMinimum;

            account.ActivatePackage("Безлім");

            account.TopUp(20);

            account.RegisterCall(15, 2);

            account.RegisterCall(15, 2);

            account.ShowStatus();
            // Відписка від події
            account.BalanceReachedMinimum -= handler.HandleBalanceReachedMinimum;

            Console.WriteLine("\nПрограму завершено.");
        }
    }
}
