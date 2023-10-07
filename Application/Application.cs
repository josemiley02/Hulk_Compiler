namespace HULK_COMPILER
{
    public static class Application
    {
        public static void WelcomeMessege()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("Welcome To Hulk!!!");
            System.Console.WriteLine("Write your code...");
            SelectKey();
        }
        public static void SelectKey()
        {
            System.Console.Write(">>>");
            string line = Console.ReadLine()!;
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Enter)
            {
                var exp = Parser.L(Tokenizer.GetTokens(line), 0);
                exp.Item2.GetScope(Utils.Global);
                if (!Utils.Declarate_Funtion)
                {
                    try
                    {
                        exp.Item2.Semantic_Walk();
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                    try
                    {
                        System.Console.WriteLine(exp.Item2.Evaluate());
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                }
                Utils.Declarate_Funtion = false;
                Utils.Global = new(null!, new(), new());
                SelectKey();
            }
            if (key == ConsoleKey.Escape)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Environment.Exit(0);
            }
        }
        public static void ThrowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Green;
            SelectKey();
        }
    }
}