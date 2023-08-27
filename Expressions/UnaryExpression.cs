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
        public override string Evaluate()
        {
            return this.Value.ToString();
        }
    }
    public class LogExpression : UnaryExpression
    {
        public LogExpression(Expression arg) : base(arg)
        {
        }
        public override string Evaluate()
        {
            return Math.Log10(double.Parse(this.Arg!.Evaluate())).ToString();
        }
    }
    public class RootExpression : UnaryExpression
    {
        public RootExpression(Expression arg) : base(arg)
        {
        }
        public override string Evaluate()
        {
            return Math.Sqrt(double.Parse(this.Arg!.Evaluate())).ToString();
        }
    }
    public class SenExpression : UnaryExpression
    {
        public SenExpression(Expression arg) : base(arg)
        {
        }
        public override string Evaluate()
        {
            return Math.Sin(double.Parse(this.Arg!.Evaluate())).ToString();
        }
    }
    public class CosExpression : UnaryExpression
    {
        public CosExpression(Expression arg) : base(arg)
        {
        }
        public override string Evaluate()
        {
            return Math.Cos(double.Parse(this.Arg!.Evaluate())).ToString();
        }
    }
    public class TanExpression : UnaryExpression
    {
        public TanExpression(Expression arg) : base(arg)
        {
        }
        public override string Evaluate()
        {
            return Math.Tan(double.Parse(this.Arg!.Evaluate())).ToString();
        }
    }
}