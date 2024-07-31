static class escape
{

    private static string [] incognitasSalas{get;set;}

    private static int estadoJuego = 1;

    public static int intentos = 1;

    private static void InicializarJuego()
    {
        incognitasSalas = new string [4];
        incognitasSalas [0] = "RM1524";
        incognitasSalas [1] = "VRR";
        incognitasSalas [2] = "KNR";
        incognitasSalas [3] = "MATHEUS DA SILVA RIVEIRO JR";
    }

    public static int GetEstadoJuego()
    {
        return estadoJuego;
    }
    public static bool ResolverSala(int Sala, string Incognita)
    {
        InicializarJuego();
        if(Sala == estadoJuego){
            if(Incognita.ToUpper() == incognitasSalas[Sala-1]){
                estadoJuego++;
            return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
        
    }
    public static int ContarSalas()
    {
        int cantidadSalas = incognitasSalas.Length;
        return cantidadSalas;
    }
    public static void ReiniciarEstadoJuego()
    {
        estadoJuego = 1;
    }

}