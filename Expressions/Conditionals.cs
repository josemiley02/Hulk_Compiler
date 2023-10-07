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

        public override void GetScope(Scope actual)
        {
            If_Part.GetScope(actual);
            Then_Part.GetScope(actual);
            Else_Part.GetScope(actual);
        }

        public override Scope.Declared Semantic_Walk()
        {
            if (If_Part.Semantic_Walk() == Scope.Declared.Boolean)
            {
                var result_then = Then_Part.Semantic_Walk();
                var result_else = Else_Part.Semantic_Walk();
                return Scope.Declared.NoAsig;
            }
            Utils.Error = "! SEMANTIC ERROR: This is not Boolean Expression, in the \'if\'";
            Application.ThrowError(Utils.Error);
            throw new();
        }
    }
}