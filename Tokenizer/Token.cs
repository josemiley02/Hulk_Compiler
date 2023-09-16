namespace HULK_COMPILER
{
    public class Token
    {
        /*
        Tipos de Tokens
        1- Keyoword: let, in, if, while, then, else, funtion
        2- Identifiquer: The name of any variable, class, funtion
        3- Operators
        3.1-- Math (+, =, -, *, /, %)
        3.2-- Relationship (<, >, <=, >=, !=, ==)
        3.3-- Logic (&&, ||, !)
        3.4-- Increment (++, --)
        4- Separators: whitespace, \t, \n, signers(. , ; () {} [])
        5- Lietarls
        5.1-- Enetero: 5,4,3,-1,0
        5.2-- Flotante: 34.2, 10e23, -90.8
        5.3-- Cadena: "Hola",'H'
        */
        public enum TokenTypes
        {
            //With this enum, you can see, the diffrent tokens types defined for a Compiler
            Token_Let, Token_Else, Token_Funtion, Token_If, Token_In, Token_Then, Token_While, Token_After,
            Token_Sum, Token_Dif, Token_Mult, Token_Div, Token_Equal, Token_Mod, Token_Exp,
            Token_Less, Token_More, Token_LessOrEqual, Token_MoreOrEqual, Token_DoubleEqual, Token_NoEqual,
            Token_Not, Token_And, Token_Or,
            WhiteSpace, Open_Paren, Close_Paren, Open_Block, Close_Block, Open_Key, Close_Key, EndLine,
            Identifiquer, Chain_Lietarls, Number_Literals, Print, Token_True, Token_False,
            Token_Log, Token_Sen, Token_Cos, Token_Tan, Token_Cot, Token_Sqrt, Token_PI,
            Token_SpaceLine, Token_LINQ,
        }
        public TokenTypes Types;
        public string Value;

        public Token(TokenTypes types, string value)
        {
            Types = types;
            Value = value;
        }
        //This is a Languaje for HULK
        public static Dictionary<string, Token> HULK_Tokens = new()
        {
            {"let", new Token(TokenTypes.Token_Let, "let")},
            {"in", new Token(TokenTypes.Token_In,"in")},
            {"if", new Token(TokenTypes.Token_If,"if")},
            {"while", new Token(TokenTypes.Token_While,"while")},
            {"after", new Token(TokenTypes.Token_After, "after")},
            {"else",new Token(TokenTypes.Token_Else,"else")},
            {"then",new Token(TokenTypes.Token_Then,"then")},
            {"function",new Token(TokenTypes.Token_Funtion,"function")},
            {"=>", new Token(TokenTypes.Token_LINQ, "=>")},
            {"+", new Token(TokenTypes.Token_Sum, "+")},
            {"-", new Token(TokenTypes.Token_Dif, "-")},
            {"*", new Token(TokenTypes.Token_Mult, "*")},
            {"/", new Token(TokenTypes.Token_Div, "/")},
            {"=", new Token(TokenTypes.Token_Equal, "=")},
            {"^",new Token(TokenTypes.Token_Exp,"^")},
            {"%", new Token(TokenTypes.Token_Mod, "%")},
            {"<", new Token(TokenTypes.Token_Less,"<")},
            {">", new Token(TokenTypes.Token_More,">")},
            {"<=", new Token(TokenTypes.Token_LessOrEqual,"<=")},
            {">=", new Token(TokenTypes.Token_MoreOrEqual,">=")},
            {"==", new Token(TokenTypes.Token_DoubleEqual,"==")},
            {"!=", new Token(TokenTypes.Token_NoEqual,"!=")},
            {"!", new Token(TokenTypes.Token_Not,"!")},
            {"&&", new Token(TokenTypes.Token_And,"&&")},
            {"||", new Token(TokenTypes.Token_Or,"||")},
            {" ", new Token(TokenTypes.WhiteSpace," ")},
            {"(", new Token(TokenTypes.Open_Paren,"(")},
            {")", new Token(TokenTypes.Close_Paren,")")},
            {"[", new Token(TokenTypes.Open_Block,"[")},
            {"]", new Token(TokenTypes.Close_Block,"]")},
            {"{", new Token(TokenTypes.Open_Key,"{")},
            {"}",new Token(TokenTypes.Close_Key,"}")},
            {";",new Token(TokenTypes.EndLine,";")},
            {"log",new Token(TokenTypes.Token_Log,"log")},
            {"sen", new Token(TokenTypes.Token_Sen,"sen")},
            {"cos", new Token(TokenTypes.Token_Cos,"cos")},
            {"tan", new Token(TokenTypes.Token_Tan,"tan")},
            {"cot", new Token(TokenTypes.Token_Cot,"cot")},
            {"sqrt", new Token(TokenTypes.Token_Sqrt,"sqrt")},
            {"print", new Token(TokenTypes.Print,"print")},
            {"true", new Token(TokenTypes.Token_True, "true")},
            {"false", new Token(TokenTypes.Token_False, "false")},
            {"PI", new Token(TokenTypes.Token_PI, "PI")},
            {",", new Token(TokenTypes.Token_SpaceLine, ",")}
        };
    }
}