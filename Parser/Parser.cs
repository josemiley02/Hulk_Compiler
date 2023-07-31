namespace HULK_COMPILER
{
    public static class Parser
    {
        /*L = A;
        A = BZ | !BZ
        Z = and A | or A | e
        B = EW
        W = < E | > E | ==E | != E | e
        E = FX
        X = + E | - E | e
        F = TY
        Y = * F | / F | e
        T = int | (A) | true | false */
        public static (int,Expression) L(List<Token> codeline, int ImHere)
        {
            (int, Expression) result_A = A(codeline, ImHere);
            if (codeline[result_A.Item1].Types == Token.TokenTypes.EndLine && result_A.Item1 == codeline.Count - 1)
            {
                return result_A;
            }
            return (0, null)!;
        }
        public static (int, Expression) A(List<Token> codeline, int ImHere, Expression last = null!)
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
        public static (int, Expression) B(List<Token> codeline, int ImHere, Expression last)
        {
            (int, Expression) result_E = E(codeline, ImHere, last);
            (int, Expression) result_W = W(codeline, result_E.Item1, result_E.Item2);
            return result_W;
        }
        public static (int, Expression) Z(List<Token> codeline, int ImHere, Expression last)
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
        public static (int, Expression) E(List<Token> codeline, int ImHere, Expression last)
        {
            (int, Expression) result_F = F(codeline, ImHere, last);
            (int, Expression) result_X = X(codeline, result_F.Item1, result_F.Item2);
            return result_X;
        }
        public static (int, Expression) W(List<Token> codeline, int ImHere, Expression last)
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
                    Expression Equal = new EqualExpression(last, result_E.Item2);
                    return (result_E.Item1, Equal);

                case (Token.TokenTypes.Token_NoEqual):
                    result_E = E(codeline, ImHere + 1, last);
                    Expression NotEqual = new NotEqualExpression(last, result_E.Item2);
                    return (result_E.Item1, NotEqual);

                default: return (ImHere, last);
            }
        }
        public static (int, Expression) X(List<Token> codeline, int ImHere, Expression last)
        {
            (int, Expression) result_E;
            if (codeline[ImHere].Types == Token.TokenTypes.Token_Sum)
            {
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
            return (ImHere, last);
        }
        public static (int, Expression) F(List<Token> codeline, int ImHere, Expression last)
        {
            (int, Expression) result_T = T(codeline, ImHere, last);
            (int, Expression) result_Y = Y(codeline, result_T.Item1, result_T.Item2);
            return result_Y;
        }
        public static (int, Expression) Y(List<Token> codeline, int ImHere, Expression last)
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
            return (ImHere, last);
        }
        public static (int, Expression) T(List<Token> codeline, int ImHere, Expression last)
        {
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
            if (codeline[ImHere].Types == Token.TokenTypes.Open_Paren)
            {
                (int, Expression) result_A = A(codeline, ImHere + 1, last);
                if (result_A.Item1 < codeline.Count)
                {
                    if (codeline[result_A.Item1].Types == Token.TokenTypes.Close_Paren)
                    {
                        return (result_A.Item1 + 1, result_A.Item2);
                    }
                    //Throw Error
                }
                //Throw Error
            }
            //Throw Error
            return (0, null)!;
        }
    }
}