namespace HULK_COMPILER
{
    public abstract class BinaryExpression : Expression
    {
        public Expression left;
        public Expression right;

        public BinaryExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }
    }
    //+
    public class SumExpression : BinaryExpression
    {
        public SumExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override string Evaluate()
        {
            return (double.Parse(this.left.Evaluate()) + double.Parse(this.right.Evaluate())).ToString();
        }
    }
    //-
    public class RestExpression : BinaryExpression
    {
        public RestExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override string Evaluate()
        {
            return (double.Parse(this.left.Evaluate()) - double.Parse(this.right.Evaluate())).ToString();
        }
    }
    //*
    public class MultExpression : BinaryExpression
    {
        public MultExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override string Evaluate()
        {
            return (double.Parse(this.left.Evaluate()) * double.Parse(this.right.Evaluate())).ToString();
        }
    }
    // /
    public class DivExpression : BinaryExpression
    {
        public DivExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override string Evaluate()
        {
            return (double.Parse(this.left.Evaluate()) / double.Parse(this.right.Evaluate())).ToString();
        }
    }
    //^
    public class ExpExpression : BinaryExpression
    {
        public ExpExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override string Evaluate()
        {
            return Math.Pow(double.Parse(this.left.Evaluate()), double.Parse(this.right.Evaluate())).ToString();
        }
    }
    //%
    public class ModExpression : BinaryExpression
    {
        public ModExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override string Evaluate()
        {
            return (double.Parse(this.left.Evaluate()) % double.Parse(this.right.Evaluate())).ToString();
        }
    }
}