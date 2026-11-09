using System;

namespace Lab34
{
    public class BalanceEventArgs : EventArgs
    {
        public decimal PreviousBalance { get; }
        public decimal CurrentBalance { get; }
        public decimal MinimumBalance { get; }

        public BalanceEventArgs(decimal previousBalance, decimal currentBalance, decimal minimumBalance)
        {
            PreviousBalance = previousBalance;
            CurrentBalance = currentBalance;
            MinimumBalance = minimumBalance;
        }
    }
}
