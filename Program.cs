namespace HULK_COMPILER
{
    public static class Program
    {
        public static Dictionary<Token, Expression>? RAM = new Dictionary<Token, Expression>();
        public static List<Funtion> Funtions = new List<Funtion>();
        static void Main(string[] args)
        {
            Application.WelcomeMessege();
        }
    }
}