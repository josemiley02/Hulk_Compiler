namespace HULK_COMPILER
{
    public class Funtion
    {
        public string Name;
        public List<Token> Cant_Arg;
        public Expression Body;

        public Funtion(string name, List<Token> cant_Arg, Expression body)
        {
            Name = name;
            Cant_Arg = cant_Arg;
            Body = body;
        }
    }
}
