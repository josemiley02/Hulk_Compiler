namespace HULK_COMPILER
{
    public static class Program
    {
        public static List<Funtion> Funtions = new List<Funtion>();
        public static Scope Global = new Scope(null!, new(), new());
        
        static void Main(string[] args)
        {
            Application.WelcomeMessege();
        }
    }
}