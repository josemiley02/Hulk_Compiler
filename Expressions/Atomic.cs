namespace HULK_COMPILER
{
    public class NumberExpression : Expression
    {
        public double Value;
        public NumberExpression(double Value)
        {
            this.Value = Value;
        }
        public override string Evaluate()
        {
            return this.Value.ToString();
        }
    }
    public class TrueOrFalseExpression : Expression
    {
        public bool Value;
        public TrueOrFalseExpression(bool Value)
        {
            this.Value = Value;
        }
        public override string Evaluate()
        {
            return this.Value.ToString();
        }
    }
    public class IdenExpression : Expression
    {
        public Token ID;

        public IdenExpression(Token iD)
        {
            ID = iD;
        }

        public override string Evaluate()
        {
            return Program.RAM![this.ID].Evaluate();
        }
    }
    public class ChainExpression : Expression
    {
        string value;
        public ChainExpression(string Value)
        {
            value = Value;
        }
        public override string Evaluate()
        {
            return value;
        }
    }
}