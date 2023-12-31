namespace HULK_COMPILER
{
    //This class parses the token list and constructs the AST (which is an expression composed of expressions)
    //Consult file "Test.txt where the grammar is written along with the produtions"
    public static class Parser
    {
        public static bool IsFuntion;
        public static (int, Expression) L(List<Token> codeline, int ImHere)
        {
            try
            {
                (int, Expression) result_M = M(codeline, ImHere);
                if (result_M.Item1 == codeline.Count - 1 && codeline[result_M.Item1].Types == Token.TokenTypes.EndLine)
                {
                    return result_M;
                }
            }
            catch (System.Exception)
            {
                var x = "! LEXYCAL ERROR: Where is ; ???";
                Application.ThrowError(x);
            }
            Application.ThrowError("! "); //Escribir Parsin Error...
            return (0, null)!;
        }
        private static (int, Expression) M(List<Token> codeline, int ImHere, Expression last = null!)
        {
            if (codeline[ImHere].Types == Token.TokenTypes.Print)
            {
                (int, Expression) result_M = M(codeline, ImHere + 1, last);
                Expression print = new PrintExpression(result_M.Item2);
                if (!Utils.Declarate_Funtion) IsFuntion = true;
                return (result_M.Item1, print);
            }
            if (codeline[ImHere].Types == Token.TokenTypes.Token_If)
            {
                (int, Expression) if_expression = M(codeline, ImHere + 1, last);
                (int, Expression) then_expression = M(codeline, if_expression.Item1, if_expression.Item2);
                if (codeline[then_expression.Item1].Types == Token.TokenTypes.Token_Else)
                {
                    (int, Expression) else_expression = M(codeline, then_expression.Item1 + 1, then_expression.Item2);
                    Expression condition = new Conditionals(if_expression.Item2, then_expression.Item2, else_expression.Item2);
                    return (else_expression.Item1, condition);
                }
                Utils.Error = "! SYNTAX ERROR: The Conditional needs a \"else\" part";
                Application.ThrowError(Utils.Error);
            }
            if (codeline[ImHere].Types == Token.TokenTypes.Token_Let)
            {
                if (codeline[ImHere + 1].Types == Token.TokenTypes.Identifiquer)
                {
                    Token ID = codeline[ImHere + 1];
                    if (codeline[ImHere + 2].Types == Token.TokenTypes.Token_Equal)
                    {
                        (int, Expression) result_M = M(codeline, ImHere + 3, last);
                        Expression asig = new AsigExpression(ID, result_M.Item2);
                        ImHere = result_M.Item1;
                        last = asig;
                        return H(codeline, ImHere, last);
                    }
                    Utils.Error = "! SYNTAX ERROR: Invalid Token \"" + codeline[ImHere + 2].Value + "\"";
                    Application.ThrowError(Utils.Error);
                }
                Utils.Error = "! SYNTAX ERROR: Invalid Token \"" + codeline[ImHere + 1].Value + "\"";
                Application.ThrowError(Utils.Error);
            }
            if (codeline[ImHere].Types == Token.TokenTypes.Token_Funtion && ImHere == 0)
            {
                if (codeline[ImHere + 1].Types == Token.TokenTypes.Identifiquer)
                {
                    Token token = codeline[ImHere + 1];
                    if (codeline[ImHere + 2].Types == Token.TokenTypes.Open_Paren)
                    {
                        (int, List<Token>) result_Q = Q(codeline, ImHere + 3, new());
                        ImHere = result_Q.Item1;
                        if (codeline[ImHere].Types == Token.TokenTypes.Token_LINQ)
                        {
                            Utils.Declarate_Funtion = true;
                            Funtion func = new Funtion(token.Value, result_Q.Item2, null!);
                            Utils.Funtions.Add(func);
                            (int, Expression) result_M = M(codeline, ImHere + 1);
                            func.Body = result_M.Item2;
                            return (result_M.Item1, func);
                        }
                        Utils.Error = "! SYNTAX ERROR: It was expected \"=>\"";
                        Application.ThrowError(Utils.Error);
                    }
                    Utils.Error = "! SYNTAX ERROR: Missing \"(\" in the Expression";
                    Application.ThrowError(Utils.Error);
                }
                Utils.Error = "! SYNTAX ERROR: Invalid Token \"" + codeline[ImHere + 1].Value + "\"";
                Application.ThrowError(Utils.Error);
            }
            return A(codeline, ImHere, last);
        }
        private static (int, Expression) H(List<Token> codeline, int ImHere, Expression last)
        {
            if (codeline[ImHere].Types == Token.TokenTypes.Token_In){}
            
            else if (codeline[ImHere].Types == Token.TokenTypes.Token_SpaceLine)
            {
                codeline.Insert(ImHere + 1, new Token(Token.TokenTypes.Token_Let, "let"));
            }
            else
            {
                Utils.Error = "! SYUNTAX ERROR: Invalid Token \"" + codeline[ImHere].Value + "\" in the Expression";
                return (ImHere, last);
            }
            (int, Expression) result_M = M(codeline, ImHere + 1, last);
            Expression let_in = new LetInExpression(last, result_M.Item2);
            return (result_M.Item1, let_in);
        }
        private static (int, List<Token>) Q(List<Token> codeline, int ImHere, List<Token> cant)
        {
            if (codeline[ImHere].Types == Token.TokenTypes.Identifiquer)
            {
                cant.Add(codeline[ImHere]);
                ImHere += 1;
                if (codeline[ImHere].Types == Token.TokenTypes.Token_SpaceLine)
                {
                    return Q(codeline, ImHere + 1, cant);
                }
            }
            if (codeline[ImHere].Types == Token.TokenTypes.Close_Paren && codeline[ImHere - 1].Types != Token.TokenTypes.Token_SpaceLine)
            {
                return (ImHere + 1, cant);
            }
            Utils.Error = "!SYNTAX ERROR: Invalid Token " + codeline[ImHere].Value;
            Application.ThrowError(Utils.Error);
            return (0, null)!;
        }
        private static (int, List<Expression>) K(List<Token> codeline, int ImHere, List<Expression> expressions)
        {
            for (int i = ImHere; i < codeline.Count; i++)
            {
                var exp = M(codeline, i);
                expressions.Add(exp.Item2);
                if (codeline[exp.Item1].Types == Token.TokenTypes.Token_SpaceLine)
                {
                    i = exp.Item1;
                    continue;
                }
                if (codeline[exp.Item1].Types == Token.TokenTypes.Close_Paren)
                {
                    return (exp.Item1, expressions);
                }
                break;
            }
            Utils.Error = "! SYNTAX ERROR: Invalid Expression";
            Application.ThrowError(Utils.Error);
            return (0, null)!;
        }
        private static (int, Expression) A(List<Token> codeline, int ImHere, Expression last = null!)
        {
            (int, Expression) result_Z;
            if (codeline[ImHere].Types == Token.TokenTypes.Token_Not)
            {
                (int, Expression) result_B = B(codeline, ImHere + 1, last);
                Expression root = new NotExpression(result_B.Item2);
                result_Z = Z(codeline, result_B.Item1, root);
            }
            else
            {
                (int, Expression) result_B = B(codeline, ImHere, last);
                result_Z = Z(codeline, result_B.Item1, result_B.Item2);
            }
            return result_Z;
        }
        private static (int, Expression) B(List<Token> codeline, int ImHere, Expression last)
        {
            (int, Expression) result_E = E(codeline, ImHere, last);
            (int, Expression) result_W = W(codeline, result_E.Item1, result_E.Item2);
            return result_W;
        }
        private static (int, Expression) Z(List<Token> codeline, int ImHere, Expression last)
        {
            (int, Expression) result_A;
            switch (codeline[ImHere].Types)
            {
                case (Token.TokenTypes.Token_And):
                    result_A = A(codeline, ImHere + 1, last);
                    Expression and = new AndExpression(last, result_A.Item2);
                    return (result_A.Item1, and);

                case (Token.TokenTypes.Token_Or):
                    result_A = A(codeline, ImHere + 1, last);
                    Expression Or = new OrExpression(last, result_A.Item2);
                    return (result_A.Item1, Or);
                default: return (ImHere, last);
            }
        }
        private static (int, Expression) E(List<Token> codeline, int ImHere, Expression last)
        {
            (int, Expression) result_F = F(codeline, ImHere, last);
            (int, Expression) result_X = X(codeline, result_F.Item1, result_F.Item2);
            return result_X;
        }
        private static (int, Expression) W(List<Token> codeline, int ImHere, Expression last)
        {
            (int, Expression) result_E;
            switch (codeline[ImHere].Types)
            {
                case (Token.TokenTypes.Token_More):
                    result_E = E(codeline, ImHere + 1, last);
                    Expression More = new MoreExpression(last, result_E.Item2);
                    return (result_E.Item1, More);

                case (Token.TokenTypes.Token_MoreOrEqual):
                    result_E = E(codeline, ImHere + 1, last);
                    Expression MoreEqual = new MoreEqualExpression(last, result_E.Item2);
                    return (result_E.Item1, MoreEqual);

                case (Token.TokenTypes.Token_Less):
                    result_E = E(codeline, ImHere + 1, last);
                    Expression Less = new LessExpression(last, result_E.Item2);
                    return (result_E.Item1, Less);

                case (Token.TokenTypes.Token_LessOrEqual):
                    result_E = E(codeline, ImHere + 1, last);
                    Expression LessOrEqual = new LessEqualExpression(last, result_E.Item2);
                    return (result_E.Item1, LessOrEqual);

                case (Token.TokenTypes.Token_DoubleEqual):
                    result_E = E(codeline, ImHere + 1, last);
                    Expression Equal = new DoubleEqualExpression(last, result_E.Item2);
                    return (result_E.Item1, Equal);

                case (Token.TokenTypes.Token_NoEqual):
                    result_E = E(codeline, ImHere + 1, last);
                    Expression NotEqual = new NotEqualExpression(last, result_E.Item2);
                    return (result_E.Item1, NotEqual);

                default: return (ImHere, last);
            }
        }
        private static (int, Expression) X(List<Token> codeline, int ImHere, Expression last)
        {
            (int, Expression) result_E;
            if (codeline[ImHere].Types == Token.TokenTypes.Token_Sum)
            {
                // resultF = F(....);
                // resultX = X(..., last: new SumExpression(last, resultF));
                result_E = E(codeline, ImHere + 1, last);
                Expression sum = new SumExpression(last, result_E.Item2);
                return (result_E.Item1, sum);
            }
            if (codeline[ImHere].Types == Token.TokenTypes.Token_Dif)
            {
                result_E = E(codeline, ImHere + 1, last);
                Expression rest = new RestExpression(last, result_E.Item2);
                return (result_E.Item1, rest);
            }
            if (codeline[ImHere].Types == Token.TokenTypes.Token_Concat)
            {
                result_E = E(codeline, ImHere + 1, last);
                Expression concat = new ConcatExpression(last, result_E.Item2);
                return (result_E.Item1, concat);
            }
            return (ImHere, last);
        }
        private static (int, Expression) F(List<Token> codeline, int ImHere, Expression last)
        {
            (int, Expression) result_T = T(codeline, ImHere, last);
            (int, Expression) result_Y = Y(codeline, result_T.Item1, result_T.Item2);
            return result_Y;
        }
        private static (int, Expression) Y(List<Token> codeline, int ImHere, Expression last)
        {
            (int, Expression) result_F;
            if (codeline[ImHere].Types == Token.TokenTypes.Token_Mult)
            {
                result_F = F(codeline, ImHere + 1, last);
                Expression mult = new MultExpression(last, result_F.Item2);
                return (result_F.Item1, mult);
            }
            if (codeline[ImHere].Types == Token.TokenTypes.Token_Div)
            {
                result_F = F(codeline, ImHere + 1, last);
                Expression div = new DivExpression(last, result_F.Item2);
                return (result_F.Item1, div);
            }
            if (codeline[ImHere].Types == Token.TokenTypes.Token_Mod)
            {
                result_F = F(codeline, ImHere + 1, last);
                Expression mod = new ModExpression(last, result_F.Item2);
                return (result_F.Item1, mod);
            }
            if (codeline[ImHere].Types == Token.TokenTypes.Token_Exp)
            {
                result_F = F(codeline, ImHere + 1, last);
                Expression exp = new ExpExpression(last, result_F.Item2);
                return (result_F.Item1, exp);
            }
            return (ImHere, last);
        }
        private static (int, Expression) T(List<Token> codeline, int ImHere, Expression last)
        {
            if (codeline[ImHere].Types == Token.TokenTypes.Token_Log)
            {
                if (codeline[ImHere + 1].Types == Token.TokenTypes.Open_Paren)
                {
                    (int, List<Expression>) result_K = K(codeline, ImHere + 2, new());
                    return (result_K.Item1 + 1, new LogExpression(result_K.Item2));
                }
                Utils.Error = "! SYNTAX ERROR: Missing \"(\" in the expression";
                Application.ThrowError(Utils.Error);
            }
            if (codeline[ImHere].Types == Token.TokenTypes.Token_Sen)
            {
                (int, Expression) result_E = E(codeline, ImHere + 1, last);
                return (result_E.Item1, new SenExpression(result_E.Item2));
            }
            if (codeline[ImHere].Types == Token.TokenTypes.Token_Cos)
            {
                (int, Expression) result_E = E(codeline, ImHere + 1, last);
                return (result_E.Item1, new CosExpression(result_E.Item2));
            }
            if (codeline[ImHere].Types == Token.TokenTypes.Token_Tan)
            {
                (int, Expression) result_E = E(codeline, ImHere + 1, last);
                return (result_E.Item1, new TanExpression(result_E.Item2));
            }
            if (codeline[ImHere].Types == Token.TokenTypes.Token_Sqrt)
            {
                (int, Expression) result_E = E(codeline, ImHere + 1, last);
                return (result_E.Item1, new RootExpression(result_E.Item2));
            }
            if (codeline[ImHere].Types == Token.TokenTypes.Chain_Lietarls)
            {
                return (ImHere + 1, new ChainExpression(codeline[ImHere].Value));
            }
            if (codeline[ImHere].Types == Token.TokenTypes.Token_PI)
            {
                return (ImHere + 1, new NumberExpression(Math.PI));
            }
            if (codeline[ImHere].Types == Token.TokenTypes.Number_Literals)
            {
                return (ImHere + 1, new NumberExpression(double.Parse(codeline[ImHere].Value)));
            }
            if (codeline[ImHere].Types == Token.TokenTypes.Token_True)
            {
                return (ImHere + 1, new TrueOrFalseExpression(true));
            }
            if (codeline[ImHere].Types == Token.TokenTypes.Token_False)
            {
                return (ImHere + 1, new TrueOrFalseExpression(false));
            }
            if (codeline[ImHere].Types == Token.TokenTypes.Identifiquer)
            {
                foreach (var item in Utils.Funtions)
                {
                    if (item.Name == codeline[ImHere].Value)
                    {
                        if (codeline[ImHere + 1].Types == Token.TokenTypes.Open_Paren)
                        {
                            Token func = codeline[ImHere];

                            (int, List<Expression>) result_K = K(codeline, ImHere + 2, new());

                            Expression funtion = new FunCallExpression(item, result_K.Item2);

                            if (!Utils.Declarate_Funtion) IsFuntion = true;

                            return (result_K.Item1 + 1, funtion);
                        }
                        break;
                    }
                }
                return (ImHere + 1, new IdenExpression(codeline[ImHere], null!));
            }
            if (codeline[ImHere].Types == Token.TokenTypes.Open_Paren)
            {
                (int, Expression) result_M = M(codeline, ImHere + 1, last);
                if (result_M.Item1 < codeline.Count)
                {
                    if (codeline[result_M.Item1].Types == Token.TokenTypes.Close_Paren)
                    {
                        return (result_M.Item1 + 1, result_M.Item2);
                    }
                    if (codeline[result_M.Item1].Types == Token.TokenTypes.Token_SpaceLine)
                    {
                        return (result_M.Item1, result_M.Item2);
                    }
                    Utils.Error = "! SYNTAX ERROR: Missing closing parenthesis after " + codeline[result_M.Item1 - 1].Value;
                    Application.ThrowError(Utils.Error);
                }
                Utils.Error = "! SYNTAX ERROR: Missing opening parenthesis after " + codeline[result_M.Item1 - 1].Value;
                Application.ThrowError(Utils.Error);
            }
            Utils.Error = $"! SYNTAX ERROR: Invalid token \"" + codeline[ImHere].Value + "\" in the expression";
            Application.ThrowError(Utils.Error);
            return (0, null)!;
        }
    }
}