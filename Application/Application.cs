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
                Scope scope = Program.Global;
                exp.Item2.GetScope(scope);
                if (!Parser.Declarate_Funtion)
                {
                    try
                    {
                        exp.Item2.Semantic_Walk();
                    }
                    catch (HULK_COMPILER.Semantic_Error)
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
                Parser.Declarate_Funtion = false;
                SelectKey();
            }
            if (key == ConsoleKey.Escape)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Environment.Exit(0);
            }
        }
    }
}