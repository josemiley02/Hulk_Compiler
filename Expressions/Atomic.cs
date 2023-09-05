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

        public override void GetScope(Scope actual)
        {
            return;
        }

        public override string Semantic_Walk()
        {
            string result = Value.GetType().ToString();
            string To_return = "";
            for (int i = result.Length - 1; result[i] != '.'; i--)
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

        public override void GetScope(Scope actual)
        {
            return;
        }

        public override string Semantic_Walk()
        {
            string result = Value.GetType().ToString();
            string To_return = "";
            for (int i = result.Length - 1; result[i] != '.'; i--)
            {
                To_return = result[i] + To_return;
            }
            return To_return;
        }
    }
    public class IdenExpression : Expression
    {
        public Token ID;
        public Expression Value;
        private Scope Here = new(null!, new(), new());

        public IdenExpression(Token iD, Expression value)
        {
            ID = iD;
            Value = value;
        }
        public override string Evaluate()
        {
            foreach (var item in Here.Corpus_Values.Keys)
            {
                if (item.Value == ID.Value)
                {
                    return Here.Corpus_Values[item].Evaluate();
                }
            }
            throw new();
        }

        public override void GetScope(Scope actual)
        {
            if (actual.Father == null) throw new Semantic_Error("NOT");
            foreach (var item in actual.Father.Declared_Type.Keys)
            {
                if (item.Value == ID.Value)
                {
                    Here = actual.Father;
                    return;
                }
            }
            GetScope(actual.Father);
        }

        public override string Semantic_Walk()
        {
            foreach (var item in Here.Declared_Type.Keys)
            {
                if (item.Value == ID.Value)
                {
                    return Here.Declared_Type[item];
                }
            }
            throw new Exception();
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

        public override void GetScope(Scope actual)
        {
            return;
        }

        public override string Semantic_Walk()
        {
            string result = value.GetType().ToString();
            string To_return = "";
            for (int i = result.Length - 1; result[i] != '.'; i--)
            {
                To_return = result[i] + To_return;
            }
            return To_return;
        }
    }
}