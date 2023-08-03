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

        public override double Evaluate()
        {
            if (this.If_Part.Evaluate() == 1)
            {
                return this.Then_Part.Evaluate();
            }
            return this.Else_Part.Evaluate();
        }
    }
}