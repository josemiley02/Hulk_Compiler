namespace HULK_COMPILER
{
    public static class Utils
    {
        public static List<Funtion> Funtions = new List<Funtion>(); //Guardar todas las funciones que se de claren durante una interaccion con el Hulk
        public static Scope Global = new Scope(null!, new(), new()); //El Scope correspondiente a cada linea
        public static bool Declarate_Funtion; //Saber si una linea fue una declaracion de funcion
        public static string Error = ""; //Mensaje para los Errores
    }
}