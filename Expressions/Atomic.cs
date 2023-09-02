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

        public override string Semantic_Walk()
        {
            string result = Value.GetType().ToString();
            string To_return = "";
            for (int i = result.Length - 1; result[i] != '.' ; i--)
            {
                To_return = result[i] + To_return;
            }
            return To_return;
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

        public override string Semantic_Walk()
        {
            string result = Value.GetType().ToString();
            string To_return = "";
            for (int i = result.Length - 1; result[i] != '.' ; i--)
            {
                To_return = result[i] + To_return;
            }
            return To_return;
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

        public override string Semantic_Walk()
        {
            return Program.RAM![ID].Semantic_Walk();
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

        public override string Semantic_Walk()
        {
            string result = value.GetType().ToString();
            string To_return = "";
            for (int i = result.Length - 1; result[i] != '.' ; i--)
            {
                To_return = result[i] + To_return;
            }
            return To_return;
        }
    }
}