namespace HULK_COMPILER
{
    public abstract class UnaryExpression : Expression
    {
        public double Value;
        public Expression? Arg;

        public UnaryExpression(Expression arg)
        {
            this.Arg = arg;
        }
    }
    //SQRT
    public class RootExpression : UnaryExpression
    {
        public RootExpression(Expression arg) : base(arg)
        {
        }
        public override void GetScope(Scope actual)
        {
            Arg!.GetScope(actual);
        }
        public override string Evaluate()
        {
            return Math.Sqrt(double.Parse(this.Arg!.Evaluate())).ToString();
        }
        public override Scope.Declared Semantic_Walk()
        {
            var result_Arg = Arg!.Semantic_Walk();
            if (result_Arg == Scope.Declared.Double)
            {
                return result_Arg;
            }
            Utils.Error = "! SEMANTIC ERROR: Invalid Argument for the Root";
            Application.ThrowError(Utils.Error);
            throw new();
        }
    }
    //SIN
    public class SenExpression : UnaryExpression
    {
        public SenExpression(Expression arg) : base(arg)
        {
        }
        public override void GetScope(Scope actual)
        {
            Arg!.GetScope(actual);
        }
        public override string Evaluate()
        {
            return Math.Sin(double.Parse(this.Arg!.Evaluate())).ToString();
        }
        public override Scope.Declared Semantic_Walk()
        {
            var result_Arg = Arg!.Semantic_Walk();
            if (result_Arg == Scope.Declared.Double)
            {
                return result_Arg;
            }
            Utils.Error = "! SEMANTIC ERROR: Invalid Argument for the Sin";
            Application.ThrowError(Utils.Error);
            throw new();
        }
    }
    //COS
    public class CosExpression : UnaryExpression
    {
        public CosExpression(Expression arg) : base(arg)
        {
        }
        public override void GetScope(Scope actual)
        {
            Arg!.GetScope(actual);
        }
        public override string Evaluate()
        {
            return Math.Cos(double.Parse(this.Arg!.Evaluate())).ToString();
        }
        public override Scope.Declared Semantic_Walk()
        {
            var result_Arg = Arg!.Semantic_Walk();
            if (result_Arg == Scope.Declared.Double)
            {
                return result_Arg;
            }
            Utils.Error = "! SEMANTIC ERROR: Invalid Argument for the Cos";
            Application.ThrowError(Utils.Error);
            throw new();
        }
    }
    //TAN
    public class TanExpression : UnaryExpression
    {
        public TanExpression(Expression arg) : base(arg)
        {
        }
        public override void GetScope(Scope actual)
        {
            Arg!.GetScope(actual);
        }
        public override string Evaluate()
        {
            return Math.Tan(double.Parse(this.Arg!.Evaluate())).ToString();
        }
        public override Scope.Declared Semantic_Walk()
        {
            var result_Arg = Arg!.Semantic_Walk();
            if (result_Arg == Scope.Declared.Double)
            {
                return result_Arg;
            }
            Utils.Error = "! SEMANTIC ERROR: Invalid Argument for the Tan";
            Application.ThrowError(Utils.Error);
            throw new();
        }
    }
}