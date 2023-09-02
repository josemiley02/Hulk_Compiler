namespace HULK_COMPILER
{
    public struct Code_Location
    {
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
    public class EndLine_Error : Exception
    {
        public EndLine_Error(string message) : base(message)
        {
            this.message = message;
        }
        public string message {get; set;}
    }
    public class Syntax_Error : Exception
    {
        public string message {get; set;}
        public Syntax_Error(string message) : base(message)
        {
            this.message = message;
        }
    }
    public class Semantic_Error : Exception
    {
        public string message {get; set;}
        public Semantic_Error(string message) : base(message)
        {
            this.message = message;
        }
    }
}