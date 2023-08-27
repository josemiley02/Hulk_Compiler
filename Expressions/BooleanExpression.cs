namespace HULK_COMPILER
{
    public class MoreExpression : BinaryExpression
    {
        public MoreExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override string Evaluate()
        {
            return (double.Parse(this.left.Evaluate()) > double.Parse(this.right.Evaluate())).ToString();
        }
    }
    public class MoreEqualExpression : BinaryExpression
    {
        public MoreEqualExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override string Evaluate()
        {
            return (double.Parse(this.left.Evaluate()) >= double.Parse(this.right.Evaluate())).ToString();
        }
    }
    public class LessExpression : BinaryExpression
    {
        public LessExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override string Evaluate()
        {
            return (double.Parse(this.left.Evaluate()) < double.Parse(this.right.Evaluate())).ToString();
        }
    }
    public class LessEqualExpression : BinaryExpression
    {
        public LessEqualExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override string Evaluate()
        {
            return (double.Parse(this.left.Evaluate()) <= double.Parse(this.right.Evaluate())).ToString();
        }
    }
    public class DoubleEqualExpression : BinaryExpression
    {
        public DoubleEqualExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override string Evaluate()
        {
            return (this.left.Evaluate() == this.right.Evaluate()).ToString();
        }
    }
    public class NotEqualExpression : BinaryExpression
    {
        public NotEqualExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override string Evaluate()
        {
            return (this.left.Evaluate() != this.right.Evaluate()).ToString();
        }
    }
    public class AndExpression : BinaryExpression
    {
        public AndExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override string Evaluate()
        {
            return (this.left.Evaluate() == "True" && this.right.Evaluate() == "True").ToString();
        }
    }
    public class OrExpression : BinaryExpression
    {
        public OrExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override string Evaluate()
        {
            return (this.left.Evaluate() == "True" || this.right.Evaluate() == "True").ToString();
        }
    }
    public class NotExpression : UnaryExpression
    {
        public NotExpression(Expression arg) : base(arg)
        {
        }
        public override string Evaluate()
        {
            return this.Arg!.Evaluate() == "False" ? "True" : "Talse";
        }
    }
}