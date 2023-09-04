namespace HULK_COMPILER
{
    public abstract class Expression
    {
        public abstract string Semantic_Walk();
        public abstract string Evaluate();
        public abstract Scope GetScope(Scope actual);
    }
}