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
                ViewBag.Clave = "clave incorrecta";
                ViewBag.Terminado1 = true;
                ViewBag.ErrorJuego2 = "Difenente orden de los jugadores";
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

    public IActionResult Juego1(string Jugador)
    {
        string incognita = Jugador.ToUpper();
        ViewBag.Terminado = false;   
      
            Console.WriteLine(Jugador);
            
            if (jugadores.Jugadores.Contains(incognita))
            {
                jugadores.Jugadores.Remove(incognita);
                ViewBag.Jugador = Jugador + " esta en este plantel";
                jugadores.aciertos++;
            }
            else
            {
                ViewBag.Jugador = Jugador + " no esta en este plantel";
            }
            Console.WriteLine(jugadores.aciertos);
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

       public IActionResult Juego2(string Jugador)
    {
        string incognita = Jugador.ToUpper();
        ViewBag.Terminado = false;   
      
            Console.WriteLine(Jugador);
            
            if (jugadores.Jugadores.Contains(incognita))
            {
                adivinaJugador.Jugadores.Remove(incognita);
                ViewBag.Jugador = Jugador + " forma parte";
                adivinaJugador.aciertos++;
            }
            else
            {
                ViewBag.Jugador = Jugador + " no forma parte";
            }
            ViewBag.aciertos = jugadores.aciertos;
            Console.WriteLine(jugadores.aciertos);
            if (jugadores.aciertos == 3)
            {
                ViewBag.Terminado1 = true;  
            }
            return View("Habitacion1");
    }
}
