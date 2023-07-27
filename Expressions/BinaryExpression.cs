namespace HULK_COMPILER
{
    public class BinaryExpression : Expression
    {
        public Expression left; 
        public Expression right;

        public BinaryExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public override double Evaluate()
        {
            throw new NotImplementedException();
        }
    }
    //+
    public class SumExpression : BinaryExpression
    {
        public SumExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override double Evaluate()
        {
            return this.left.Evaluate() + this.right.Evaluate();
        }
    }
    //-
    public class RestExpression : BinaryExpression
    {
        public RestExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override double Evaluate()
        {
            return this.left.Evaluate() - this.right.Evaluate();
        }
    }
    //*
    public class MultExpression : BinaryExpression
    {
        public MultExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override double Evaluate()
        {
            return this.left.Evaluate() * this.right.Evaluate();
        }
    }
    // /
    public class DivExpression : BinaryExpression
    {
        public DivExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override double Evaluate()
        {
            return this.left.Evaluate() / this.right.Evaluate();
        }
    }
    //^
    public class ExpExpression : BinaryExpression
    {
        public ExpExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override double Evaluate()
        {
            return Math.Pow(this.left.Evaluate(),this.right.Evaluate());
        }
    }
    //%
    public class ModExpression : BinaryExpression
    {
        public ModExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override double Evaluate()
        {
            return this.left.Evaluate() % this.right.Evaluate();
        }
    }
}