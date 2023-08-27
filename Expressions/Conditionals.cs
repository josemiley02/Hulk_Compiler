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
            string result_IF = this.If_Part.Evaluate();
            if(result_IF != "True" && result_IF != "False") throw new Exception();
            if (result_IF == "True")
            {
                return this.Then_Part.Evaluate();
            }
            return this.Else_Part.Evaluate();
        }
    }
}