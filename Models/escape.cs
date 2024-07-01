static class escape{

private static string [] incognitasSalas{get;set;}

private static int estadoJuego = 1;

private static void InicializarJuego()
{
    incognitasSalas = new string [5];
    incognitasSalas [0] = " ";
    incognitasSalas [1] = " ";
    incognitasSalas [2] = " ";
    incognitasSalas [3] = " ";
    incognitasSalas [4] = " ";
}

public static int GetEstadoJuego()
{
    return estadoJuego;
}
public static bool ResolverSala(int Sala, string Incognita){
    if(incognitasSalas.Length > 0){
        if(Sala-1 == estadoJuego){
            if(Incognita == incognitasSalas[Sala-1]){
                estadoJuego++;
            return true;
            }
            else{
                return false;
            }
        }
        else{
        return false;
        }
    }else{
        InicializarJuego();
        return false;
    }
    
}
public static int ContarSalas()
{
    int cantidadSalas = incognitasSalas.Length;
    return cantidadSalas;
}

}