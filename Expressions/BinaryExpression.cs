using System.Runtime.CompilerServices;

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

        public override void GetScope(Scope actual)
        {
            left.GetScope(actual);
            right.GetScope(actual);
            return;
        }

        public override Scope.Declared Semantic_Walk()
        {
            var a = left.Semantic_Walk();
            var b = right.Semantic_Walk();
            if (a == Scope.Declared.Double && b == Scope.Declared.Double)
            {
                return a;
            }
            if (a == Scope.Declared.NoAsig || b == Scope.Declared.NoAsig)
            {
                return a;
            }
            else
            {
                throw new Semantic_Error("You can't opearte " + a + " with " + b);
            }
        }
    }
    //-
    public class RestExpression : BinaryExpression
    {
        public RestExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override void GetScope(Scope actual)
        {
            left.GetScope(actual);
            right.GetScope(actual);
            return;
        }

        public override string Evaluate()
        {
            return (double.Parse(this.left.Evaluate()) - double.Parse(this.right.Evaluate())).ToString();
        }
        public override Scope.Declared Semantic_Walk()
        {
            var a = left.Semantic_Walk();
            var b = right.Semantic_Walk();
            if (a == Scope.Declared.Double && b == Scope.Declared.Double)
            {
                return a;
            }
            if (a == Scope.Declared.NoAsig || b == Scope.Declared.NoAsig)
            {
                return a;
            }
            else
            {
                throw new Semantic_Error("You can't opearte " + a + " with " + b);
            }
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
        public override void GetScope(Scope actual)
        {
            left.GetScope(actual);
            right.GetScope(actual);
            return;
        }

        public override Scope.Declared Semantic_Walk()
        {
            var a = left.Semantic_Walk();
            var b = right.Semantic_Walk();
            if (a == Scope.Declared.Double && b == Scope.Declared.Double)
            {
                return a;
            }
            if (a == Scope.Declared.NoAsig || b == Scope.Declared.NoAsig)
            {
                return a;
            }
            else
            {
                throw new Semantic_Error("You can't opearte " + a + " with " + b);
            }
        }
    }
    // /
    public class DivExpression : BinaryExpression
    {
        public DivExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override void GetScope(Scope actual)
        {
            left.GetScope(actual);
            right.GetScope(actual);
            return;
        }

        public override string Evaluate()
        {
            return (double.Parse(this.left.Evaluate()) / double.Parse(this.right.Evaluate())).ToString();
        }
        public override Scope.Declared Semantic_Walk()
        {
            var a = left.Semantic_Walk();
            var b = right.Semantic_Walk();
            if (a == Scope.Declared.Double && b == Scope.Declared.Double)
            {
                return a;
            }
            if (a == Scope.Declared.NoAsig || b == Scope.Declared.NoAsig)
            {
                return a;
            }
            else
            {
                throw new Semantic_Error("You can't opearte " + a + " with " + b);
            }
        }
    }
    //^
    public class ExpExpression : BinaryExpression
    {
        public ExpExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override void GetScope(Scope actual)
        {
            left.GetScope(actual);
            right.GetScope(actual);
            return;
        }

        public override string Evaluate()
        {
            return Math.Pow(double.Parse(this.left.Evaluate()), double.Parse(this.right.Evaluate())).ToString();
        }
        public override Scope.Declared Semantic_Walk()
        {
            var a = left.Semantic_Walk();
            var b = right.Semantic_Walk();
            if (a == Scope.Declared.Double && b == Scope.Declared.Double)
            {
                return a;
            }
            if (a == Scope.Declared.NoAsig || b == Scope.Declared.NoAsig)
            {
                return a;
            }
            else
            {
                throw new Semantic_Error("You can't opearte " + a + " with " + b);
            }
        }
    }
    //%
    public class ModExpression : BinaryExpression
    {
        public ModExpression(Expression left, Expression right) : base(left, right)
        {
        }
        public override void GetScope(Scope actual)
        {
            left.GetScope(actual);
            right.GetScope(actual);
            return;
        }

        public override string Evaluate()
        {
            return (double.Parse(this.left.Evaluate()) % double.Parse(this.right.Evaluate())).ToString();
        }
        public override Scope.Declared Semantic_Walk()
        {
            var a = left.Semantic_Walk();
            var b = right.Semantic_Walk();
            if (a == Scope.Declared.Double && b == Scope.Declared.Double)
            {
                return a;
            }
            if (a == Scope.Declared.NoAsig || b == Scope.Declared.NoAsig)
            {
                return a;
            }
            else
            {
                throw new Semantic_Error("You can't opearte " + a + " with " + b);
            }
        }
    }
    public class LogExpression : Expression
    {
        List<Expression> Base_Arg;
        public LogExpression(List<Expression> base_arg)
        {
            Base_Arg = base_arg;
        }
        public override string Evaluate()
        {
            if (Base_Arg.Count == 1)
            {
                return Math.Log10(double.Parse(Base_Arg[0].Evaluate())).ToString();
            }
            
            double arg = double.Parse(Base_Arg[0].Evaluate());
            double newbase = double.Parse(Base_Arg[1].Evaluate());
            return Math.Log(arg,newbase).ToString();
        }

        public override void GetScope(Scope actual)
        {
            if (Base_Arg.Count != 0)
            {
                foreach (var item in Base_Arg)
                {
                    item.GetScope(actual);
                }
                return;
            }
            throw new Semantic_Error("The Logarit needs one Arg");
        }

        public override Scope.Declared Semantic_Walk()
        {
            if (Base_Arg.Count <= 2)
            {
                foreach (var item in Base_Arg)
                {
                    if (item.Semantic_Walk() != Scope.Declared.Double)
                    {
                        throw new Semantic_Error("This is not a nuber");
                    }
                }
                return Scope.Declared.Double;
            }
            throw new Semantic_Error("The Logarit not work with more that two arguments");
        }
    }
}