namespace HULK_COMPILER
{
    public struct Code_Location
    {
        public Code_Location(int line, int column)
        {
            this.line = line;
            this.column = column;
        }

        public int line {get; set;}
        public int column {get; set;}
    }
    public class Lexical_Error : Exception
    {
        public string message {get; set;}
        public Lexical_Error(string message) : base(message)
        {
            this.message = message;
        }
    }
}