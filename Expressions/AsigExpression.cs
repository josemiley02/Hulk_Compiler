namespace HULK_COMPILER
{
    //Expresion for the let part in a let-in expression
    public class AsigExpression : Expression
    {
        Token target;
        Expression asig;
        Scope? where;

        public AsigExpression(Token target, Expression asig)
        {
            this.target = target;
            this.asig = asig;
        }

        public override Scope.Declared Semantic_Walk()
        {
            foreach (var item in where!.Declared_Type.Keys)
            {
                if (item.Value == target.Value)
                {
                    where.Declared_Type[item] = asig.Semantic_Walk();
                    return where.Declared_Type[item];
                }
            }
            throw new();
        }
        public override string Evaluate()
        {
            foreach (var item in where!.Declared_Type.Keys)
            {
                if (item.Value == target.Value)
                {
                    string result = asig.Evaluate();
                    where.Corpus_Values.Add(target, result);
                    return result;
                }
            }
            throw new();
        }

        public override void GetScope(Scope actual)
        {
            actual.Declared_Type.Add(target, Scope.Declared.NoAsig);
            asig.GetScope(actual);
            where = actual;
        }
    }
    //Let-In Expression with two parts, the let part and after-in part
    public class LetInExpression : Expression
    {
        Expression let_part;
        Expression after_in;
        public LetInExpression(Expression let_part, Expression after_in)
        {
            this.after_in = after_in;
            this.let_part = let_part;
        }

        public override string Evaluate()
        {
            let_part.Evaluate();
            return after_in.Evaluate();
        }

        public override void GetScope(Scope actual)
        {
            Scope firstson = new Scope(actual, new(), new());
            let_part.GetScope(firstson);
            Scope next = new Scope(firstson, new(), new());
            after_in.GetScope(next);
        }

        public override Scope.Declared Semantic_Walk()
        {
            let_part.Semantic_Walk();
            return after_in.Semantic_Walk();
        }
    }
}