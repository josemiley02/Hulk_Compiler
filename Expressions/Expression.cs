namespace HULK_COMPILER
{
    public abstract class Expression
    {
        public abstract void GetScope(Scope actual);
        public abstract Scope.Declared Semantic_Walk();
        public abstract string Evaluate();
    }
}