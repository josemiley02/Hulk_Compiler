namespace HULK_COMPILER
{
    public class MoreExpression : BinaryExpression
    {
        public MoreExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override double Evaluate()
        {
            return this.left.Evaluate() > this.right.Evaluate() ? 1 : 0;
        }
    }
    public class MoreEqualExpression : BinaryExpression
    {
        public MoreEqualExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override double Evaluate()
        {
            return this.left.Evaluate() >= this.right.Evaluate() ? 1 : 0;
        }
    }
    public class LessExpression : BinaryExpression
    {
        public LessExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override double Evaluate()
        {
            return this.left.Evaluate() < this.right.Evaluate() ? 1 : 0;
        }
    }
    public class LessEqualExpression : BinaryExpression
    {
        public LessEqualExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override double Evaluate()
        {
            return this.left.Evaluate() <= this.right.Evaluate() ? 1 : 0;
        }
    }
    public class EqualExpression : BinaryExpression
    {
        public EqualExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override double Evaluate()
        {
            return this.left.Evaluate() == this.right.Evaluate() ? 1 : 0;
        }
    }
    public class NotEqualExpression : BinaryExpression
    {
        public NotEqualExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override double Evaluate()
        {
            return this.left.Evaluate() != this.right.Evaluate() ? 1 : 0;
        }
    }
    public class AndExpression : BinaryExpression
    {
        public AndExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override double Evaluate()
        {
            return this.left.Evaluate() == 1 && this.right.Evaluate() == 1 ? 1 : 0;
        }
    }
    public class OrExpression : BinaryExpression
    {
        public OrExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override double Evaluate()
        {
            return this.left.Evaluate() == 1 || this.right.Evaluate() == 1 ? 1 : 0;
        }
    }
    public class NotExpression : UnaryExpression
    {
        public NotExpression(Expression arg) : base(arg)
        {
        }
        public override double Evaluate()
        {
            return this.Evaluate() == 0 ? 1 : 0;
        }
    }
}