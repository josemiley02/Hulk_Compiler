namespace HULK_COMPILER
{
    public static class Program
    {
        public static List<Funtion> Funtions = new List<Funtion>();
        public static Scope Global = new Scope(null!, new(), new());
        
        static void Main(string[] args)
        {
            {// string a = "funtion fib(n) => if(n == 0) 1 else n * fib(n - 1);";
            // string b = "fib(5);";
            // var exp = Parser.L(Tokenizer.GetTokens(a), 0);
            // var exp1 = Parser.L(Tokenizer.GetTokens(b), 0);
            // // Scope scope = new(null!, new(), new());
            // exp.Item2.GetScope(Program.Global);
            // exp1.Item2.GetScope(Program.Global);
            // string temp = exp1.Item2.Semantic_Walk();
            // System.Console.WriteLine(exp1.Item2.Evaluate());
            }
            Application.WelcomeMessege();
        }
    }
}