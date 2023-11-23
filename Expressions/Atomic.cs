namespace HULK_COMPILER
{
    //ATOMICS EXPRESSIONS
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

        public override void GetScope(Scope actual){}

        public override Scope.Declared Semantic_Walk()
        {
            return Scope.Declared.Double;
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

        public override void GetScope(Scope actual){}

        public override Scope.Declared Semantic_Walk()
        {
            return Scope.Declared.Boolean;
        }
    }
    public class IdenExpression : Expression
    {
        public Token ID;
        public Expression Value;
        private Scope? Here;

        public IdenExpression(Token iD, Expression value)
        {
            ID = iD;
            Value = value;
        }
        public override string Evaluate()
        {
            foreach (var item in Here!.Corpus_Values.Keys)
            {
                if (item.Value == ID.Value)
                {
                    return Here.Corpus_Values[item];
                }
            }
            throw new();
        }

        public override void GetScope(Scope actual)
        {
            if (actual.Father == null)
            {
                Utils.Error = "! SEMANTIC ERROR: The varaible " + ID.Value + " does not exist in this context";
                Application.ThrowError(Utils.Error);
            }
            foreach (var item in actual.Father!.Declared_Type.Keys)
            {
                if (item.Value == ID.Value)
                {
                    Here = actual.Father;
                    return;
                }
            }
            GetScope(actual.Father);
        }

        public override Scope.Declared Semantic_Walk()
        {
            foreach (var item in Here!.Declared_Type.Keys)
            {
                if (item.Value == ID.Value)
                {
                    return Here.Declared_Type[item];
                }
            }
            Utils.Error = "! SEMANTIC ERROR: Tha variable " + ID.Value + ", is not declared in this scope";
            Application.ThrowError(Utils.Error);
            throw new();
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

        public override void GetScope(Scope actual){}

        public override Scope.Declared Semantic_Walk()
        {
            return Scope.Declared.String;
        }
    }
}