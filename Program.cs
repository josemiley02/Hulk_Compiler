namespace HULK_COMPILER
{
    public static class Program
    {
        static void Main(string[] args)
        {
            string test = "let a = 5 in print(a);";
            System.Console.WriteLine(test);
            List<Token> tokens = Tokenizer.GetTokens(test);
            foreach (var item in tokens)
            {
                System.Console.WriteLine(item.Types + "," + item.Value);
            }
        }
    }
}