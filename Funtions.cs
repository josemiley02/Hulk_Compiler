namespace HULK_COMPILER
{
    public abstract class Funtion
    {
        public abstract void DoIt();
    }
    public class Print : Funtion
    {
        public Expression expression;

        public Print(Expression expression)
        {
            this.expression = expression;
        }

        public override void DoIt()
        {
            System.Console.WriteLine(this.expression.Evaluate());
        }
    }
}