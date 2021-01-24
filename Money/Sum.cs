namespace Money
{
        public class Sum : IExpression
        {
            public IExpression augend;
            public IExpression addend;

            public Sum(IExpression augend, IExpression addend)
            {
                this.augend = augend;
                this.addend = addend;
            }

            public Money Reduce(Bank bank, string to)
            {
               
                return new Money(this.augend.Reduce(bank, to).amount + this.addend.Reduce(bank, to).amount, to);
            }

            public IExpression Plus(IExpression addened)
            {
                return new Sum(this, addened);
            }

            public IExpression Times(int multiplier)
            {
                return new Sum(this.augend.Times(multiplier), this.addend.Times(multiplier));
            }
        }
    }
