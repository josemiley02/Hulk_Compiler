namespace HULK_COMPILER
{
    public abstract class Expression
    {
        public abstract string Evaluate();
        public abstract void GetScope(Scope actual);
        public abstract string Semantic_Walk();
    }
}