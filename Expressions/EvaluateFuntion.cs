namespace HULK_COMPILER
{
    public class EvaluateFuntion : Expression
    {
        public Funtion Funtion;
        public List<Expression> Args;

        public EvaluateFuntion(Funtion funtion, List<Expression> args)
        {
            Args = args;
            Funtion = funtion;
        }
        public override string Evaluate()
        {
            if (Funtion.Cant_Arg.Count == Args.Count)
            {
                for (int i = 0; i < Args.Count; i++)
                {
                    Program.RAM![Funtion.Cant_Arg[i]] = Args[i];
                }
                return this.Funtion.Body.Evaluate();
            }
            throw new NotImplementedException();
        }
    }
    public class PrintExpression : Expression
    {
        public PrintExpression(Expression toprint)
        {
            this.toprint = toprint;
        }
        public Expression toprint;
        public override string Evaluate()
        {
            return toprint.Evaluate();
        }
    }
}