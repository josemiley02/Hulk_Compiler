namespace HULK_COMPILER
{
    public class Scope
    {
        public Scope Father;
        public Dictionary<Token, string> Corpus_Values;
        public Dictionary<Token, Declared> Declared_Type;

        public Scope(Scope father, Dictionary<Token, string> corpus_values, Dictionary<Token, Declared> declared)
        {
            Father = father;
            Corpus_Values = corpus_values;
            Declared_Type = declared;
        }
        public enum Declared
        {
            Double, String, Boolean, True, False, NoAsig
        }
    }
}