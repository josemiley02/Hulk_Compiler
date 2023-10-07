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
        public SumExpression(Expression left, Expression right) : base(left, right){}

        public override string Evaluate()
        {
            string result = "";
            try
            {
                result = (double.Parse(this.left.Evaluate()) + double.Parse(this.right.Evaluate())).ToString();
            }
            catch (System.Exception)
            {
                Utils.Error = "! SEMANTIC ERROR: Invalid Operation";
                Application.ThrowError(Utils.Error);
            }
            return result;
        }

        public override void GetScope(Scope actual)
        {
            left.GetScope(actual);
            right.GetScope(actual);
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
                Utils.Error = "! SEMANTIC ERROR: You can't Operate " + a + " with " + b;
                Application.ThrowError(Utils.Error);
            }
            throw new();
        }
    }
    //-
    public class RestExpression : BinaryExpression
    {
        public RestExpression(Expression left, Expression right) : base(left, right){}
        public override void GetScope(Scope actual)
        {
            left.GetScope(actual);
            right.GetScope(actual);
        }

        public override string Evaluate()
        {
            string result = "";
            try
            {
                result = (double.Parse(this.left.Evaluate()) - double.Parse(this.right.Evaluate())).ToString();
            }
            catch (System.Exception)
            {
                Utils.Error = "! SEMANTIC ERROR: Invalid Operation";
                Application.ThrowError(Utils.Error);
            }
            return result;
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
                Utils.Error = "! SEMANTIC ERROR: You can't Operate " + a + " with " + b;
                Application.ThrowError(Utils.Error);
            }
            throw new();
        }
    }
    //*
    public class MultExpression : BinaryExpression
    {
        public MultExpression(Expression left, Expression right) : base(left, right){}

        public override string Evaluate()
        {
            string result = "";
            try
            {
                result = (double.Parse(this.left.Evaluate()) * double.Parse(this.right.Evaluate())).ToString();
            }
            catch (System.Exception)
            {
                Utils.Error = "! SEMANTIC ERROR: Invalid Operation";
                Application.ThrowError(Utils.Error);
            }
            return result;
        }
        public override void GetScope(Scope actual)
        {
            left.GetScope(actual);
            right.GetScope(actual);
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
                Utils.Error = "! SEMANTIC ERROR: You can't Operate " + a + " with " + b;
                Application.ThrowError(Utils.Error);
            }
            throw new();
        }
    }
    // /
    public class DivExpression : BinaryExpression
    {
        public DivExpression(Expression left, Expression right) : base(left, right){}
        public override void GetScope(Scope actual)
        {
            left.GetScope(actual);
            right.GetScope(actual);
        }
        public override string Evaluate()
        {
            string result = "";
            try
            {
                result = (double.Parse(this.left.Evaluate()) / double.Parse(this.right.Evaluate())).ToString();
            }
            catch (System.Exception)
            {
                Utils.Error = "! SEMANTIC ERROR: Invalid Operation";
                Application.ThrowError(Utils.Error);
            }
            return result;
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
                Utils.Error = "! SEMANTIC ERROR: You can't Operate " + a + " with " + b;
                Application.ThrowError(Utils.Error);
            }
            throw new();
        }
    }
    //^
    public class ExpExpression : BinaryExpression
    {
        public ExpExpression(Expression left, Expression right) : base(left, right){}
        public override void GetScope(Scope actual)
        {
            left.GetScope(actual);
            right.GetScope(actual);
        }
        public override string Evaluate()
        {
            string result = "";
            try
            {
                result = Math.Pow(double.Parse(this.left.Evaluate()), double.Parse(this.right.Evaluate())).ToString();
            }
            catch (System.Exception)
            {
                Utils.Error = "! SEMANTIC ERROR: Invalid Operation";
                Application.ThrowError(Utils.Error);
            }
            return result;
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
                Utils.Error = "! SEMANTIC ERROR: You can't Operate " + a + " with " + b;
                Application.ThrowError(Utils.Error);
            }
            throw new();
        }
    }
    //%
    public class ModExpression : BinaryExpression
    {
        public ModExpression(Expression left, Expression right) : base(left, right){}
        public override void GetScope(Scope actual)
        {
            left.GetScope(actual);
            right.GetScope(actual);
        }
        public override string Evaluate()
        {
            string result = "";
            try
            {
                result = (double.Parse(this.left.Evaluate()) % double.Parse(this.right.Evaluate())).ToString();
            }
            catch (System.Exception)
            {
                Utils.Error = "! SEMANTIC ERROR: Invalid Operation";
                Application.ThrowError(Utils.Error);
            }
            return result;
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
                Utils.Error = "! SEMANTIC ERROR: You can't Operate " + a + " with " + b;
                Application.ThrowError(Utils.Error);
            }
            throw new();
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
            string result = "";
            try
            {
                if (Base_Arg.Count == 1)
                {
                    return result = Math.Log10(double.Parse(Base_Arg[0].Evaluate())).ToString();
                }
                double arg = double.Parse(Base_Arg[0].Evaluate());
                double newbase = double.Parse(Base_Arg[1].Evaluate());
                return result = Math.Log(arg, newbase).ToString();
            }
            catch (System.Exception)
            {
                Utils.Error = "! SEMANTIC ERROR: Invalid Argument for Logarithm";
                Application.ThrowError(Utils.Error);
            }
            return result;
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
            Utils.Error = "! SEMANTIC ERROR: Invalid Argument for Logarithm";
            Application.ThrowError(Utils.Error);
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
            Utils.Error = "! SEMANTIC ERROR: Invalid Argument for Logarithm";
            Application.ThrowError(Utils.Error);
            throw new();
        }
    }
    public class ConcatExpression : BinaryExpression
    {
        public ConcatExpression(Expression left, Expression right) : base(left, right){}

        public override string Evaluate()
        {
            return left.Evaluate() + right.Evaluate();
        }

        public override void GetScope(Scope actual)
        {
            left.GetScope(actual);
            right.GetScope(actual);
        }

        public override Scope.Declared Semantic_Walk()
        {
            var a = left.Semantic_Walk();
            var b = right.Semantic_Walk();
            if (a == Scope.Declared.String)
            {
                return a;
            }
            else
            {
                Utils.Error = "! SEMANTIC ERROR: Invalid Operation";
                Application.ThrowError(Utils.Error);
            }
            throw new();
        }
    }
}