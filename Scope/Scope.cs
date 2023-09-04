namespace HULK_COMPILER
{
    public class Scope
    {
        public Scope Father;
        public List<Scope> Childrens;
        public Dictionary<Token,Expression> Corpus_Values;

        public Scope(Scope father, List<Scope> childrens, Dictionary<Token,Expression> corpus_values)
        {
            Father = father;
            Childrens = childrens;
            Corpus_Values = corpus_values;
        }
    }
}