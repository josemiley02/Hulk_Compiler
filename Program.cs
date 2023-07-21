namespace HULK_COMPILER
{
    public static class Program
    {
        static void Main(string[] args)
        {
            string test = "if(a<=(10 + 3) - 5)";
            System.Console.WriteLine(test);
            List<Token> tokens = Tokenizer.GetTokens(test);
            foreach (var item in tokens)
            {
                System.Console.WriteLine(item.Types + "," + item.Value);
            }
        }
    }
}