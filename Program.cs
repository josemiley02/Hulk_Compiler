namespace HULK_COMPILER
{
    public static class Program
    {
        public static Dictionary<Token, Expression>? RAM = new Dictionary<Token, Expression>();
        public static Dictionary<Token, Funtion> Statements = new Dictionary<Token, Funtion>();
        static void Main(string[] args)
        {
            Application.WelcomeMessege();
        }
    }
}