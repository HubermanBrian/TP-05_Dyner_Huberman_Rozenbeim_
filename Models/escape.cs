static class escape{

private static string [] incognitasSalas{get;set;}

private static int estadoJuego = 1;

private static void InicializarJuego()
{
    incognitasSalas = new string [5];
    incognitasSalas [0] = "RM1524";
    incognitasSalas [1] = "VRR";
    incognitasSalas [2] = "KJN";
    incognitasSalas [3] = "Matheus Da Silva Riveiro Jr";
}

public static int GetEstadoJuego()
{
    return estadoJuego;
}
public static bool ResolverSala(int Sala, string Incognita)
{
    InicializarJuego();
    if(Sala == estadoJuego){
        if(Incognita == incognitasSalas[Sala-1]){
            estadoJuego++;
        return true;
        }
        else
        {
            return false;
        }
        }
        else{
        return false;
}
    
}
public static int ContarSalas()
{
    int cantidadSalas = incognitasSalas.Length;
    return cantidadSalas;
}

}