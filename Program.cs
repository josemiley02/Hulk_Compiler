namespace HULK_COMPILER
{
    public static class Program
    {
        public static Dictionary<Token, Expression>? RAM = new Dictionary<Token, Expression>();
        public static List<Funtion> Funtions = new List<Funtion>();
        static void Main(string[] args)
        {
            string a = "let x = 10 in let y = x + 15 in print(x * y);";
            List<Token> tokens = Tokenizer.GetTokens(a);
            var exp = Parser.L(tokens, 0);
            Application.WelcomeMessege();
        }
    }
}