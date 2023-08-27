namespace HULK_COMPILER
{
    public static class Program
    {
        public static Dictionary<Token, Expression>? RAM = new Dictionary<Token, Expression>();
        public static Dictionary<Token, Funtion> Statements = new Dictionary<Token, Funtion>();
        static void Main(string[] args)
        {
            List<Token> tokens = Tokenizer.GetTokens("print((1 == 0) || (2 == 2));");
            (int, Expression) exp = Parser.L(tokens, 0);
            Funtion.DoIt(exp.Item2);
            Application.WelcomeMessege();
        }
    }
}