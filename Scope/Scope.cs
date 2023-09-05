namespace HULK_COMPILER
{
    public class Scope
    {
        public Scope Father;
        //public List<Scope> Childrens;
        public Dictionary<Token,Expression> Corpus_Values;
        public Dictionary<Token,string> Declared_Type;

        public Scope(Scope father, Dictionary<Token,Expression> corpus_values, Dictionary<Token,string> declared)
        {
            Father = father;
            //Childrens = childrens;
            Corpus_Values = corpus_values;
            Declared_Type = declared; 
        }
    }
}