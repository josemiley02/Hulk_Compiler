namespace HULK_COMPILER
{
    public class AsigExpression : Expression
    {
        Token target;
        Expression asig;

        public AsigExpression(Token target, Expression asig)
        {
            this.target = target;
            this.asig = asig;
        }
        public override string Semantic_Walk()
        {
            throw new NotImplementedException();
        }
        public override string Evaluate()
        {
            throw new NotImplementedException();
        }
    }
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
            throw new NotImplementedException();
        }

        public override string Semantic_Walk()
        {
            throw new NotImplementedException();
        }
    }
}