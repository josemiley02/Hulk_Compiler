namespace HULK_COMPILER
{
    public abstract class Expression
    {
        //Obtain the Scope of a diffrent expression types (functions, conditional)
        public abstract void GetScope(Scope actual);
        //Semantic Analize
        public abstract Scope.Declared Semantic_Walk();
        //EVALUATE THE EXPRESSION
        public abstract string Evaluate();
    }
}