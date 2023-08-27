namespace HULK_COMPILER
{
    public static class Program
    {
        public static Dictionary<Token, Expression>? RAM = new Dictionary<Token, Expression>();
        public static Dictionary<Token, Funtion> Statements = new Dictionary<Token, Funtion>();
        static void Main(string[] args)
        {
            string a = "funtion main(a,b) => (a * a) / (b * b);";
            string b = "main(2,4);";
            List<Token> tokens1 = Tokenizer.GetTokens(a);
            List<Token> tokens2 = Tokenizer.GetTokens(b);
            (int,Expression) exp1 = Parser.L(tokens1,0);
            (int,Expression) exp2 = Parser.L(tokens2,0);
            Funtion.DoIt(exp2.Item2);
            Application.WelcomeMessege();
        }
    }
}