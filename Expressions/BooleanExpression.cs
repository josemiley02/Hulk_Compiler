namespace HULK_COMPILER
{
    public class MoreExpression : BinaryExpression
    {
        public MoreExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override void GetScope(Scope actual)
        {
            left.GetScope(actual);
            right.GetScope(actual);
        }
        public override string Evaluate()
        {
            return (double.Parse(this.left.Evaluate()) > double.Parse(this.right.Evaluate())).ToString();
        }
        public override Scope.Declared Semantic_Walk()
        {
            var a = left.Semantic_Walk();
            var b = right.Semantic_Walk();
            if (a == Scope.Declared.Double && b == Scope.Declared.Double)
            {
                return Scope.Declared.Boolean;
            }
            else
            {
                Utils.Error = "! SEMANTIC ERROR: You can't Operate " + a + " with " + b;
                Application.ThrowError(Utils.Error);
            }
            throw new();
        }
    }
    public class MoreEqualExpression : BinaryExpression
    {
        public MoreEqualExpression(Expression left, Expression right) : base(left, right){}
        public override void GetScope(Scope actual)
        {
            left.GetScope(actual);
            right.GetScope(actual);
        }

        public override string Evaluate()
        {
            return (double.Parse(this.left.Evaluate()) >= double.Parse(this.right.Evaluate())).ToString();
        }
        public override Scope.Declared Semantic_Walk()
        {
            var a = left.Semantic_Walk();
            var b = right.Semantic_Walk();
            if (a == Scope.Declared.Double && b == Scope.Declared.Double)
            {
                return Scope.Declared.Boolean;
            }
            else
            {
                Utils.Error = "! SEMANTIC ERROR: You can't Operate " + a + " with " + b;
                Application.ThrowError(Utils.Error);
            }
            throw new();
        }
    }
    public class LessExpression : BinaryExpression
    {
        public LessExpression(Expression left, Expression right) : base(left, right){}
        public override void GetScope(Scope actual)
        {
            left.GetScope(actual);
            right.GetScope(actual);
        }

        public override string Evaluate()
        {
            return (double.Parse(this.left.Evaluate()) < double.Parse(this.right.Evaluate())).ToString();
        }
        public override Scope.Declared Semantic_Walk()
        {
            var a = left.Semantic_Walk();
            var b = right.Semantic_Walk();
            if (a == Scope.Declared.Double && b == Scope.Declared.Double)
            {
                return Scope.Declared.Boolean;
            }
            else
            {
                Utils.Error = "! SEMANTIC ERROR: You can't Operate " + a + " with " + b;
                Application.ThrowError(Utils.Error);
            }
            throw new();
        }
    }
    public class LessEqualExpression : BinaryExpression
    {
        public LessEqualExpression(Expression left, Expression right) : base(left, right){}
        public override void GetScope(Scope actual)
        {
            left.GetScope(actual);
            right.GetScope(actual);
        }
        public override string Evaluate()
        {
            return (double.Parse(this.left.Evaluate()) <= double.Parse(this.right.Evaluate())).ToString();
        }
        public override Scope.Declared Semantic_Walk()
        {
            var a = left.Semantic_Walk();
            var b = right.Semantic_Walk();
            if (a == Scope.Declared.Double && b == Scope.Declared.Double)
            {
                return Scope.Declared.Boolean;
            }
            else
            {
                Utils.Error = "! SEMANTIC ERROR: You can't Operate " + a + " with " + b;
                Application.ThrowError(Utils.Error);
            }
            throw new();
        }
    }
    public class DoubleEqualExpression : BinaryExpression
    {
        public DoubleEqualExpression(Expression left, Expression right) : base(left, right){}
        public override void GetScope(Scope actual)
        {
            left.GetScope(actual);
            right.GetScope(actual);
        }

        public override string Evaluate()
        {
            return (this.left.Evaluate() == this.right.Evaluate()).ToString();
        }
        public override Scope.Declared Semantic_Walk()
        {
            var a = left.Semantic_Walk();
            var b = right.Semantic_Walk();
            if (a == b)
            {
                return Scope.Declared.Boolean;
            }
            else
            {
                Utils.Error = "! SEMANTIC ERROR: You can't Operate " + a + " with " + b;
                Application.ThrowError(Utils.Error);
            }
            throw new();
        }
    }
    public class NotEqualExpression : BinaryExpression
    {
        public NotEqualExpression(Expression left, Expression right) : base(left, right){}
        public override void GetScope(Scope actual)
        {
            left.GetScope(actual);
            right.GetScope(actual);
        }
        public override string Evaluate()
        {
            return (this.left.Evaluate() != this.right.Evaluate()).ToString();
        }
        public override Scope.Declared Semantic_Walk()
        {
            var a = left.Semantic_Walk();
            var b = right.Semantic_Walk();
            if (a == b)
            {
                return Scope.Declared.Boolean;
            }
            else
            {
                Utils.Error = "! SEMANTIC ERROR: You can't Operate " + a + " with " + b;
                Application.ThrowError(Utils.Error);
            }
            throw new();
        }
    }
    public class AndExpression : BinaryExpression
    {
        public AndExpression(Expression left, Expression right) : base(left, right){}
        public override void GetScope(Scope actual)
        {
            left.GetScope(actual);
            right.GetScope(actual);
        }

        public override string Evaluate()
        {
            return (this.left.Evaluate() == "True" && this.right.Evaluate() == "True").ToString();
        }
        public override Scope.Declared Semantic_Walk()
        {
            var a = left.Semantic_Walk();
            var b = right.Semantic_Walk();
            if (a == Scope.Declared.Boolean && b == Scope.Declared.Boolean)
            {
                return Scope.Declared.Boolean;
            }
            else
            {
                Utils.Error = "! SEMANTIC ERROR: You can't Operate " + a + " with " + b;
                Application.ThrowError(Utils.Error);
            }
            throw new();
        }
    }
    public class OrExpression : BinaryExpression
    {
        public OrExpression(Expression left, Expression right) : base(left, right){}
        public override void GetScope(Scope actual)
        {
            left.GetScope(actual);
            right.GetScope(actual);
        }
        public override string Evaluate()
        {
            return (this.left.Evaluate() == "True" || this.right.Evaluate() == "True").ToString();
        }
        public override Scope.Declared Semantic_Walk()
        {
            var a = left.Semantic_Walk();
            var b = right.Semantic_Walk();
            if (a == Scope.Declared.Boolean && b == Scope.Declared.Boolean)
            {
                return Scope.Declared.Boolean;
            }
            else
            {
                Utils.Error = "! SEMANTIC ERROR: You can't Operate " + a + " with " + b;
                Application.ThrowError(Utils.Error);
            }
            throw new();
        }
    }
    public class NotExpression : UnaryExpression
    {
        public NotExpression(Expression arg) : base(arg){}
        public override string Evaluate()
        {
            return this.Arg!.Evaluate() == "False" ? "True" : "False";
        }

        public override void GetScope(Scope actual)
        {
            Arg!.GetScope(actual);
        }
        public override Scope.Declared Semantic_Walk()
        {
            var result_Arg = Arg!.Semantic_Walk();
            if (result_Arg == Scope.Declared.Boolean)
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