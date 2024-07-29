using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using tp05_Huberman_Rozenbeim_Dyner.Models;

namespace tp05_Huberman_Rozenbeim_Dyner.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Comenzar()
    {
        ViewBag.Sala = escape.GetEstadoJuego();
        return View("Habitacion" + (escape.GetEstadoJuego() - 1));
    }
    public IActionResult Tutorial()
    {
        return View();
    }
    public IActionResult Creditos()
    {
        return View();
    }
    public IActionResult Habitacion(int sala, string clave)
    {

        if (sala == escape.GetEstadoJuego())
        {
            if (escape.ResolverSala(sala, clave))
            {
                if (sala == escape.ContarSalas())
                {
                    return View("Victoria");
                }
                else
                {
                    return RedirectToAction("Comenzar");
                }
            }
            else
            {
                if(sala == escape.ContarSalas()){
                    return View("Index");
                }
                ViewBag.Clave = "clave incorrecta";
                ViewBag.Terminado1 = true;
                ViewBag.ErrorJuego1 = "Diferente orden de los jugadores";
                jugadores.aciertos = 0;
                jugadores.Jugadores = new List<string> {"NAVAS", "CARVAJAL", "RAMOS","VARANE","MARCELO","CASEMIRO","KROOS","MODRIC","ISCO","BENZEMA","RONALDO"};
                return View("Habitacion" + (escape.GetEstadoJuego() - 1));
            }
        }
        else if (escape.ResolverSala(sala, clave))
        {
            ViewBag.Clave = "clave correcta";
            return View("Habitacion" + (escape.GetEstadoJuego() - 1));
        }
        else
        {
            return View("Habitacion" + (escape.GetEstadoJuego() - 1));
        }
    }

    public IActionResult Juego0(string Jugador)
    {
        string incognita = Jugador.ToUpper();
        ViewBag.Terminado = false;   
      
            Console.WriteLine(Jugador);
            
            if (jugadores.Jugadores.Contains(incognita))
            {
                jugadores.Jugadores.Remove(incognita);
                ViewBag.Jugador = incognita + " está en este plantel";
                jugadores.aciertos++;
            }
            else
            {
                ViewBag.Jugador = incognita + " no está en este plantel";
            }
            Console.WriteLine(jugadores.aciertos);
            ViewBag.aciertos = jugadores.aciertos;
        switch (jugadores.aciertos)
        {
            case 2:
                ViewBag.Respuesta = "R";
                break;
            case 3:
                ViewBag.Respuesta = "R";
                break;
            case 4:
                ViewBag.Respuesta = "RM";
                break;
            case 5:
                ViewBag.Respuesta = "RM";
                break;
            case 6:
                ViewBag.Respuesta = "RM1";
                break;
            case 7:
                ViewBag.Respuesta = "RM1";
                break;
            case 8:
                ViewBag.Respuesta = "RM15";
                break;
            case 9:
                ViewBag.Respuesta = "RM15";
                break;
            case 10:
                ViewBag.Respuesta = "RM152";
                break;
            case 11:
                ViewBag.Terminado = true;
                ViewBag.Respuesta = "RM1524";
                break;
            default:
                ViewBag.Respuesta = "";
                break;
        }
        return View("Habitacion0");
    }

       public IActionResult Juego1(string adivinar)
    {
        string incognita = adivinar.ToUpper();
        ViewBag.Terminado1 = false;   
      
            Console.WriteLine(adivinar);
            
            if (adivinaJugador.Jugadores.Contains(incognita))
            {
                adivinaJugador.Jugadores.Remove(incognita);
                ViewBag.Jugador = incognita + " forma parte";
                adivinaJugador.aciertos++;
            }
            else
            {
                ViewBag.Jugador = incognita + " no forma parte";
            }
            ViewBag.aciertos = adivinaJugador.aciertos;
            Console.WriteLine(adivinaJugador.aciertos);
            if (adivinaJugador.aciertos == 3)
            {
                ViewBag.Terminado1 = true;  
                ViewBag.Nombre = "Matheus";
            }
            return View("Habitacion1");
    }
        public IActionResult Juego2(string adivinar1, string adivinar2, string adivinar3)
    {
        string incognita1 = adivinar1.ToUpper();
        string incognita2 = adivinar2.ToUpper();
        string incognita3 = adivinar3.ToUpper();
        ViewBag.Resultado1 = false;   
        ViewBag.Resultado2 = false;
        ViewBag.Resultado3 = false;
        ViewBag.Terminado2 = false;  
      
            Console.WriteLine(adivinar1);
            Console.WriteLine(adivinar2);
            Console.WriteLine(adivinar3);
            
            if (incognita1 == "KAKA")
            {
                ViewBag.Jugador1 = adivinar1 + " es el primer jugador";
                ViewBag.Resultado1 = true;
            }
            else
            {
                ViewBag.Jugador1 = adivinar1 + " no es el primer jugador";
            }
            if (incognita2 == "NAZARIO")
            {
                ViewBag.Jugador2 = adivinar2 + " es el segundo jugador";
                ViewBag.Resultado2 = true;
            }
            else
            {
                ViewBag.Jugador2 = adivinar2 + " no es el segundo jugador";
            }
            if (incognita3 == "JAMES")
            {
                ViewBag.Jugador3 = adivinar3 + " es el tercer jugador";
                ViewBag.Resultado3 = true;
            }
            else
            {
                ViewBag.Jugador3 = adivinar3 + " no es el tercer jugador";
            }
            if (ViewBag.Resultado1 & ViewBag.Resultado2 & ViewBag.Resultado3)
            {
                ViewBag.Terminado2 = true;  
                ViewBag.Nombre = "Da Silva";
            }
            return View("Habitacion2");
    }

     public IActionResult Juego3(string respuesta1, string respuesta2, string respuesta3, string respuesta4, string respuesta5, string respuesta6)
    {
        string incognita1 = respuesta1.ToUpper();
        string incognita2 = respuesta2.ToUpper();
        string incognita3 = respuesta3.ToUpper();
        string incognita4 = respuesta4.ToUpper();
        string incognita5 = respuesta5.ToUpper();
        string incognita6 = respuesta6.ToUpper();
        ViewBag.Resultado1 = false;   
        ViewBag.Resultado2 = false;
        ViewBag.Resultado3 = false;
        ViewBag.Resultado4 = false;   
        ViewBag.Resultado5 = false;
        ViewBag.Resultado6 = false; 

        ViewBag.Terminado3 = false;  
      
            
            if (incognita1 == "SANTIAGO BERNABEU")
            {
                ViewBag.correcto1 = "Pregunta 1 correcta";
                ViewBag.Resultado1 = true;
            }
            else
            {
                ViewBag.correcto1 = "Pregunta 1 incorrecta";
            }
            if (incognita2 == "CRISTIANO RONALDO")
            {
                ViewBag.correcto2 = "Pregunta 2 correcta";
                ViewBag.Resultado2 = true;
            }
            else
            {
                ViewBag.correcto2 = "Pregunta 2 incorrecta";
            }
            if (incognita3 == "MADRID")
            {
                ViewBag.correcto3 = "Pregunta 3 correcta";
                ViewBag.Resultado3 = true;
            }
            else
            {
                ViewBag.correcto3 = "Pregunta 3 incorrecta";
            }
            if (incognita4 == "15")
            {
                ViewBag.correcto4 = "Pregunta 4 correcta";
                ViewBag.Resultado4 = true;
            }
            else
            {
                ViewBag.correcto4 = "Pregunta 4 incorrecta";
            }
            if (incognita5 == "RAUL")
            {
                ViewBag.correcto5 = "Pregunta 5 correcta";
                ViewBag.Resultado5 = true;
            }
            else
            {
                ViewBag.correcto5 = "Pregunta 5 incorrecta";
            }
            if (incognita6 == "36")
            {
                ViewBag.correcto6 = "Pregunta 6 correcta";
                ViewBag.Resultado6 = true;
            }
            else
            {
                ViewBag.correcto6 = "Pregunta 6 incorrecta";
            }
    
            if (ViewBag.Resultado1 & ViewBag.Resultado2 & ViewBag.Resultado3 & ViewBag.Resultado4 & ViewBag.Resultado5 & ViewBag.Resultado6)
            {
                ViewBag.Terminado3 = true;  
                ViewBag.Nombre = "Riveiro Jr";
            }
            return View("Habitacion3");
    }
}
