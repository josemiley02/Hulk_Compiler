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
            ConsoleKey key = Console.ReadKey(true).Key;;
            if (key == ConsoleKey.Enter)
            {
                List<Token> alfa = Tokenizer.GetTokens(line);
                (int,Expression) alftexp = Parser.L(alfa,0);
                if (!Parser.Declarate_Funtion)
                {
                    DoIt(alftexp.Item2);
                    Program.RAM = new();
                }
                Parser.Declarate_Funtion = false;
                SelectKey();
            }
            if (key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }
        public static void DoIt(Expression expression)
        {
            System.Console.WriteLine(expression.Evaluate());
        }
    }
}