namespace _21_Struct
{
    public struct Currency
    {
        public Currency(decimal amount, string symbol = "₺")
        {
            Amount = amount;
            Symbol = symbol;
        }

        public decimal Amount { get; set; }
        public string Symbol { get; set; }

        public string GetCurrency()
        {
            if (Symbol == "₺")
                return $"{Amount:F2}{Symbol}";
            else
                return $"{Symbol}{Amount:F2}";
        }
    }
}
