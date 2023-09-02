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
        public override string Semantic_Walk()
        {
            string a = left.Semantic_Walk();
            string b = right.Semantic_Walk();
            if (a == "Double" && b == "Double")
            {
                return "Boolean";
            }
            else
            {
                throw new Semantic_Error("You can't opearte " + a + " with " + b);
            }
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
        public override string Semantic_Walk()
        {
            string a = left.Semantic_Walk();
            string b = right.Semantic_Walk();
            if (a == "Double" && b == "Double")
            {
                return "Boolean";
            }
            else
            {
                throw new Semantic_Error("You can't opearte " + a + " with " + b);
            }
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
        public override string Semantic_Walk()
        {
            string a = left.Semantic_Walk();
            string b = right.Semantic_Walk();
            if (a == "Double" && b == "Double")
            {
                return "Boolean";
            }
            else
            {
                throw new Semantic_Error("You can't opearte " + a + " with " + b);
            }
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
        public override string Semantic_Walk()
        {
            string a = left.Semantic_Walk();
            string b = right.Semantic_Walk();
            if (a == "Double" && b == "Double")
            {
                return "Boolean";
            }
            else
            {
                throw new Semantic_Error("You can't opearte " + a + " with " + b);
            }
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
        public override string Semantic_Walk()
        {
            string a = left.Semantic_Walk();
            string b = right.Semantic_Walk();
            if (a == b)
            {
                return "Boolean";
            }
            else
            {
                throw new Semantic_Error("You can't opearte " + a + " with " + b);
            }
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
        public override string Semantic_Walk()
        {
            string a = left.Semantic_Walk();
            string b = right.Semantic_Walk();
            if (a == b)
            {
                return "Boolean";
            }
            else
            {
                throw new Semantic_Error("You can't opearte " + a + " with " + b);
            }
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
        public override string Semantic_Walk()
        {
            string a = left.Semantic_Walk();
            string b = right.Semantic_Walk();
            if (a == "Boolean" && b == "Boolean")
            {
                return "Boolean";
            }
            else
            {
                throw new Semantic_Error("You can't opearte " + a + " with " + b);
            }
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
        public override string Semantic_Walk()
        {
            string a = left.Semantic_Walk();
            string b = right.Semantic_Walk();
            if (a == "Boolean" && b == "Boolean")
            {
                return "Boolean";
            }
            else
            {
                throw new Semantic_Error("You can't opearte " + a + " with " + b);
            }
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
        public override string Semantic_Walk()
        {
            string result_Arg = Arg!.Semantic_Walk();
            if (result_Arg == "Boolean")
            {
                return result_Arg;
            }
            else
            {
                throw new Semantic_Error("The funtion Cos not work wiht a " + result_Arg);
            }
        }
    }
}