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

        public override string Semantic_Walk()
        {
            string a = left.Semantic_Walk();
            string b = right.Semantic_Walk();
            if (a == "Double" && b == "Double")
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
        public override string Semantic_Walk()
        {
            string a = left.Semantic_Walk();
            string b = right.Semantic_Walk();
            if (a == "Double" && b == "Double")
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

        public override string Semantic_Walk()
        {
            string a = left.Semantic_Walk();
            string b = right.Semantic_Walk();
            if (a == "Double" && b == "Double")
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
        public override string Semantic_Walk()
        {
            string a = left.Semantic_Walk();
            string b = right.Semantic_Walk();
            if (a == "Double" && b == "Double")
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
        public override string Semantic_Walk()
        {
            string a = left.Semantic_Walk();
            string b = right.Semantic_Walk();
            if (a == "Double" && b == "Double")
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
        public override string Semantic_Walk()
        {
            string a = left.Semantic_Walk();
            string b = right.Semantic_Walk();
            if (a == "Double" && b == "Double")
            {
                return a;
            }
            else
            {
                throw new Semantic_Error("You can't opearte " + a + " with " + b);
            }
        }
    }
}