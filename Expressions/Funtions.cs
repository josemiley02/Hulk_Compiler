namespace HULK_COMPILER
{
    public class Funtion : Expression
    {
        public string Name;
        public List<Token> Cant_Arg;
        public Expression Body;

        public Funtion(string name, List<Token> cant_Arg, Expression body)
        {
            Name = name;
            Cant_Arg = cant_Arg;
            Body = body;
        }

        public override string Evaluate()
        {
            throw new NotImplementedException();
        }

        public override void GetScope(Scope actual)
        {
            foreach (var item in Cant_Arg)
            {
                actual.Declared_Type.Add(item, null!);
            }
            Scope next = new Scope(actual, new(), new());
            Body.GetScope(next);
        }

        public override string Semantic_Walk()
        {
            return "Funtion Declared";
        }
    }
    public class FunCallExpression : Expression
    {
        Funtion funtion;
        List<Expression> expressions;
        public FunCallExpression(Funtion funtion, List<Expression> expressions)
        {
            this.expressions = expressions;
            this.funtion = funtion;
        }

        public override string Evaluate()
        {
            throw new NotImplementedException();
        }

        public override void GetScope(Scope actual)
        {
            foreach (var item in expressions)
            {
                item.GetScope(actual);
            }
            return;
        }

        public override string Semantic_Walk()
        {
            throw new NotImplementedException();
        }
    }
    public class PrintExpression : Expression
    {
        public PrintExpression(Expression toprint)
        {
            this.toprint = toprint;
        }
        public Expression toprint;
        public override string Evaluate()
        {
            return toprint.Evaluate();
        }

        public override string Semantic_Walk()
        {
            return toprint.Semantic_Walk();
        }

        public override void GetScope(Scope actual)
        {
            toprint.GetScope(actual);
        }
    }
}
