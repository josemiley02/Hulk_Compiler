namespace HULK_COMPILER
{
    public class NumberExpression : Expression
    {
        public double Value;
        public NumberExpression(double Value)
        {
            this.Value = Value;
        }
        public override double Evaluate()
        {
            return this.Value;
        }
    }
    public class TrueOrFalseExpression : Expression
    {
        public bool Value;
        public TrueOrFalseExpression(bool Value)
        {
            this.Value = Value;
        }
        public override double Evaluate()
        {
            return this.Value ? 1 : 0;
        }
    }
    public class IdenExpression : Expression
    {
        public Token ID;

        public IdenExpression(Token iD)
        {
            ID = iD;
        }

        public override double Evaluate()
        {
            return Program.RAM![this.ID].Evaluate();
        }
    }
}