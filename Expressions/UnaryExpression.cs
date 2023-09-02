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

        public override string Semantic_Walk()
        {
            return this.Arg!.Semantic_Walk();
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
        public override string Semantic_Walk()
        {
            string result_Arg = Arg!.Semantic_Walk();
            if (result_Arg == "Double")
            {
                return result_Arg;
            }
            else
            {
                throw new Semantic_Error("The funtion Log not work wiht a " + result_Arg);
            }
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
        public override string Semantic_Walk()
        {
            string result_Arg = Arg!.Semantic_Walk();
            if (result_Arg == "Double")
            {
                return result_Arg;
            }
            else
            {
                throw new Semantic_Error("The funtion Root not work wiht a " + result_Arg);
            }
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
        public override string Semantic_Walk()
        {
            string result_Arg = Arg!.Semantic_Walk();
            if (result_Arg == "Double")
            {
                return result_Arg;
            }
            else
            {
                throw new Semantic_Error("The funtion Sin not work wiht a " + result_Arg);
            }
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
        public override string Semantic_Walk()
        {
            string result_Arg = Arg!.Semantic_Walk();
            if (result_Arg == "Double")
            {
                return result_Arg;
            }
            else
            {
                throw new Semantic_Error("The funtion Cos not work wiht a " + result_Arg);
            }
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
        public override string Semantic_Walk()
        {
            string result_Arg = Arg!.Semantic_Walk();
            if (result_Arg == "Double")
            {
                return result_Arg;
            }
            else
            {
                throw new Semantic_Error("The funtion Tan not work wiht a " + result_Arg);
            }
        }
    }
}