namespace HULK_COMPILER
{
    public class Conditionals : Expression
    {
        public Expression If_Part;
        public Expression Then_Part;
        public Expression Else_Part;

        public Conditionals(Expression if_Part, Expression then_Part, Expression else_Part)
        {
            If_Part = if_Part;
            Then_Part = then_Part;
            Else_Part = else_Part;
        }
        public override string Evaluate()
        {
            if (this.If_Part.Evaluate() == "True")
            {
                return this.Then_Part.Evaluate();
            }
            return this.Else_Part.Evaluate();
        }

        public override Scope GetScope(Scope actual)
        {
            actual.Childrens.Add(If_Part.GetScope(actual));
            actual.Childrens.Add(Then_Part.GetScope(actual));
            actual.Childrens.Add(Else_Part.GetScope(actual));
            return actual;
        }

        public override string Semantic_Walk()
        {
            if (If_Part.Semantic_Walk() == "Boolean")
            {
                try
                {
                    string result_then = Then_Part.Semantic_Walk();
                    string result_else = Else_Part.Semantic_Walk();
                    return "Conditional";
                }
                catch (HULK_COMPILER.Semantic_Error)
                {
                    throw;
                }
            }
            throw new Semantic_Error("This is not Boolean Expression");
        }
    }
}