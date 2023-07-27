namespace HULK_COMPILER
{
    public struct Code_Location
    {
        public Code_Location(int line, int column, string codification = "")
        {
            this.line = line;
            this.column = column;
            this.codification = "!Invalid Token" + 
            "(" + this.line + this.column +")";
        }

        public int line {get; set;}
        public int column {get; set;}
        public string codification{get; set;}
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