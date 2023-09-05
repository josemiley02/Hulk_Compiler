namespace HULK_COMPILER
{
    public static class Program
    {
        public static List<Funtion> Funtions = new List<Funtion>();
        static void Main(string[] args)
        {
            string a = "let x = 10 in let y = 20 + x in print(x * y);";
            var exp = Parser.L(Tokenizer.GetTokens(a), 0);
            Scope scope = new(null!, new(), new());
            exp.Item2.GetScope(scope);
            string temp = exp.Item2.Semantic_Walk();
            System.Console.WriteLine(exp.Item2.Evaluate());
            Application.WelcomeMessege();
        }
    }
}