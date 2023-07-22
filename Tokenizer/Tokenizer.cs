namespace HULK_COMPILER
{
    //This class is very important, as it takes care of the tokenization process
    public static class Tokenizer
    {
        public static List<Token> GetTokens(string codeline)
        {
            List<Token> tokens = new List<Token>();
            string temp = "";
            for (int i = 0; i < codeline.Length; i++)
            {
                if (codeline[i] == ';')
                {
                    tokens.Add(new Token(Token.TokenTypes.EndLine, codeline[i].ToString()));
                    continue;
                }
                //If a blank space is found it is checked to see 
                //if information has already been saved in the timeline
                if (codeline[i] == ' ')
                {
                    if (temp == "") continue;
                    else
                    {
                        tokens.Add(GetToken(temp));
                        temp = "";
                        continue;
                    }
                }
                //If the special character that marks the start of a string type is found
                //The "GetString" method is invoked
                if (codeline[i] == '\"')
                {
                    (int, string) string_result = GetString(codeline, i + 1);
                    temp = string_result.Item2;
                    tokens.Add(new Token(Token.TokenTypes.Chain_Lietarls, temp));
                    i += string_result.Item1 - 1;
                    temp = "";
                    continue;
                }
                //This conditional is used to indicate whether one is in the presence of a numerical literal. 
                //The GetNumber method is invoked if necessary
                if (char.IsDigit(codeline[i]) && temp == "")
                {
                    (string, int) int_result = GetNumber(codeline, i);
                    temp = int_result.Item1;
                    tokens.Add(new Token(Token.TokenTypes.Number_Literals, temp));
                    i += int_result.Item2 - 1;
                    temp = "";
                    continue;
                }
                //If you talk about a special character, 
                //you know that it is an operator or a punctuation symbol. 
                if (!char.IsLetterOrDigit(codeline[i]))
                {
                    if (temp != "")
                    {
                        tokens.Add(GetToken(temp));
                        temp = "";
                    }
                    (bool, Token) token_of_two = OperatorToken(codeline, i, codeline[i]);
                    tokens.Add(token_of_two.Item2);
                    if (token_of_two.Item1)
                    {
                        i += 1;
                    }
                    continue;
                }
                temp += codeline[i];
            }
            return tokens;
        }
        //This method receives a sequence of characters and 
        //checks whether it is a valid token or an identifier.
        private static Token GetToken(string word)
        {
            try
            {
                return Token.HULK_Tokens[word];
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                return new Token(Token.TokenTypes.Identifiquer, word);
            }
        }
        //Tokenizes operators, the Boolean represents whether it is a one- or two-character operator
        private static (bool, Token) OperatorToken(string line, int index, char a)
        {
            string temp = "" + a;
            if (index < line.Length - 1)
            {
                if (Token.HULK_Tokens.ContainsKey(temp + line[index + 1]))
                {
                    return (true, Token.HULK_Tokens[temp + line[index + 1]]);
                }
            }
            return (false, GetToken(temp));
        }
        private static (int, string) GetString(string codeline, int index)
        {
            string result = "";
            int new_index = 0;
            while (codeline[index] != '\"')
            {
                result += codeline[index];
                index += 1;
                new_index += 1;
            }
            return (new_index, result);
        }
        private static (string, int) GetNumber(string codeline, int index)
        {
            string result = "";
            int new_index = 0;
            bool IsE = false;
            bool Is_Come = false;
            for (int i = index; i < codeline.Length; i++)
            {
                if ((codeline[i] == 'e' && IsE) || (codeline[i] == ',' && Is_Come))
                {
                    Code_Location locationerror = new Code_Location(1, i);
                    throw new Lexical_Error("!Invalid Token" + 
                    "(" + locationerror.line + locationerror.column +")");
                }
                if (codeline[i] == 'e') 
                {
                    IsE = true;
                    continue;
                }
                if (codeline[i] == ',') 
                {
                    Is_Come = true;
                    continue;
                }
                if(char.IsLetter(codeline[i]))
                {
                    Code_Location locationerror = new Code_Location(1, i);
                    throw new Lexical_Error("!Invalid Token" + 
                    "(" + locationerror.line + "," + locationerror.column +")");
                }
                if (!char.IsLetterOrDigit(codeline[i]))
                {
                    break;
                }
                result += codeline[i];
                new_index += 1;
            }
            return (result, new_index);
        }
    }
}