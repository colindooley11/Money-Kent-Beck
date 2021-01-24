namespace Money
{
    public class Money : IExpression
    {
        public double amount;
        public string currency;

        public Money(double amount, string currency)
        {
            this.amount = amount;
            this.currency = currency;
        }
        
        public override bool Equals(object? obj)
        {
            Money money = (Money) obj;
            if (this.Currency() != money.Currency())
            {
                return false;
            }
            return money.amount == amount;
        }

        public Money Reduce(Bank bank, string to)
        {
            int rate = bank.Rate(currency, to);
            return new Money(amount / rate, to);
        }

        public static Money Dollar(double amount)
        {
            return new Money(amount, "USD");
        }

        public static Money Franc(double amount)
        {
            return new Money(amount, "CHF");
        }

        public virtual string Currency()
        {
            return currency; 
        }

        public IExpression Times(int multiplier)
        {
            return new Money(amount * multiplier, currency);
        }

        public IExpression Plus(IExpression addened)
        {
            return new Sum(this, addened);
        }
    }
}