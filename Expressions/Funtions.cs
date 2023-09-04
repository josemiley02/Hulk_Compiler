namespace HULK_COMPILER
{
    public class Funtion
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
    }
    public class FunCallExpression : Expression
    {
        Funtion funtion;
        List<Expression> expressions;
        public FunCallExpression (Funtion funtion, List<Expression> expressions)
        {
            this.expressions = expressions;
            this.funtion = funtion;
        }

        public override string Evaluate()
        {
            throw new NotImplementedException();
        }

        public override Scope GetScope(Scope actual)
        {
            Scope scope = new Scope(actual, new(), new());
            for (int i = 0; i < expressions.Count; i++)
            {
                try
                {
                    scope.Corpus_Values.Add(funtion.Cant_Arg[i], expressions[i]);
                }
                catch (System.IndexOutOfRangeException)
                {
                    
                    throw;
                }
            }
            actual.Childrens.Add(scope);
            return actual;
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

        public override Scope GetScope(Scope actual)
        {
            return toprint.GetScope(actual);
        }
    }
}
