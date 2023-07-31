namespace HULK_COMPILER
{
    public class UnaryExpression : Expression
    {
        public double Value;
        public Expression? Arg;

        public UnaryExpression(Expression arg)
        {
            this.Arg = arg;
        }
        public override double Evaluate()
        {
            return this.Value;
        }
    }
    public class LogExpression : UnaryExpression
    {
        public LogExpression(Expression arg) : base(arg)
        {
        }
        public override double Evaluate()
        {
            return Math.Log2(this.Arg!.Evaluate());
        }
    }
    public class RootExpression : UnaryExpression
    {
        public RootExpression(Expression arg) : base(arg)
        {
        }
        public override double Evaluate()
        {
            return Math.Sqrt(this.Arg!.Evaluate());
        }
    }
    public class SenExpression : UnaryExpression
    {
        public SenExpression(Expression arg) : base(arg)
        {
        }
        public override double Evaluate()
        {
            return Math.Sin(this.Arg!.Evaluate());
        }
    }
    public class CosExpression : UnaryExpression
    {
        public CosExpression(Expression arg) : base(arg)
        {
        }
        public override double Evaluate()
        {
            return Math.Cos(this.Arg!.Evaluate());
        }
    }
    public class TanExpression : UnaryExpression
    {
        public TanExpression(Expression arg) : base(arg)
        {
        }
        public override double Evaluate()
        {
            return Math.Tan(this.Arg!.Evaluate());
        }
    }
}