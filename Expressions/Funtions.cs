namespace HULK_COMPILER
{
    public class Funtion : Expression
    {
        public string Name; //Function's name
        public List<Token> Cant_Arg; //Params
        public Expression Body; //Body
        public Scope? scope_funtion = new(Utils.Global, new(), new()); //Scope

        public Funtion(string name, List<Token> cant_Arg, Expression body)
        {
            Name = name;
            Cant_Arg = cant_Arg;
            Body = body;
        }

        public override string Evaluate()
        {
            throw new NotImplementedException();
        }

        public override void GetScope(Scope actual)
        {
            foreach (var item in Cant_Arg)
            {
                actual.Declared_Type.Add(item, Scope.Declared.NoAsig);
            }
            Scope next = new Scope(actual, new(), new());
            Body.GetScope(next);
            scope_funtion = actual;
        }

        public override Scope.Declared Semantic_Walk()
        {
            return Scope.Declared.NoAsig;
        }
    }
    public class FunCallExpression : Expression
    {
        Funtion funtion;
        List<Expression> expressions; //Args for the function
        public FunCallExpression(Funtion funtion, List<Expression> expressions)
        {
            this.expressions = expressions;
            this.funtion = funtion;
        }

        public override string Evaluate()
        {
            Dictionary<Token, string> temp = funtion.scope_funtion!.Corpus_Values;
            Dictionary<Token, string> ParamsFuntion = new();
            int index = 0;
            foreach (var item in expressions)
            {
                ParamsFuntion.Add(funtion.Cant_Arg[index], item.Evaluate());
                index += 1;
            }
            funtion.scope_funtion.Corpus_Values = ParamsFuntion;
            string final = funtion.Body.Evaluate();
            funtion.scope_funtion.Corpus_Values = temp;
            return final;
        }

        public override void GetScope(Scope actual)
        {
            foreach (var item in expressions)
            {
                item.GetScope(actual);
            }
            return;
        }

        public override Scope.Declared Semantic_Walk()
        {
            // foreach (var item in Utils.Funtions)
            // {
            //     if(item.Name == funtion.Name)
            //     {
            //         funtion = item;
            //     }
            // }
            if (funtion.Cant_Arg.Count == expressions.Count)
            {
                foreach (var item in expressions)
                {
                    item.Semantic_Walk();
                }
                return Scope.Declared.NoAsig;
            }
            Utils.Error = "! SEMANTIC ERROR: Invalid arguments count";
            Application.ThrowError(Utils.Error);
            throw new();
        }
    }
    public class PrintExpression : Expression
    {
        public PrintExpression(Expression toprint)
        {
            this.toprint = toprint;
        }
        public Expression toprint;
        public override string Evaluate()
        {
            return toprint.Evaluate();
        }

        public override Scope.Declared Semantic_Walk()
        {
            return toprint.Semantic_Walk();
        }

        public override void GetScope(Scope actual)
        {
            toprint.GetScope(actual);
        }
    }
}
