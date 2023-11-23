namespace HULK_COMPILER
{
    public static class Application
    {
        //This class is a  "Visual App" for HULK. Is just a Console Application
        //but with some colors.
        public static void WelcomeMessege()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("Welcome To Hulk!!!");
            System.Console.WriteLine("Write your code...");
            SelectKey();
        }
        //Application is Run
        private static void SelectKey()
        {
            System.Console.Write(">>>");
            string line = Console.ReadLine()!;
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Enter)
            {
                //Tokenize and parse the user input
                var exp = Parser.L(Tokenizer.GetTokens(line), 0);
                //Analize the AST 
                //My AST is a "Big Expression" with expression
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
                //Now you ca write again
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