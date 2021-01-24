namespace Money
{
    public interface IExpression
    {
        Money Reduce(Bank bank, string to);
        IExpression Plus(IExpression addened);
        IExpression Times(int multiplier);
    }
}