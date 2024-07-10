using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
        Console.WriteLine("entra principal");

        if (sala == escape.GetEstadoJuego())
        {
            Console.WriteLine("entra secudaria");
            if (escape.ResolverSala(sala, clave))
            {
                if (sala == escape.ContarSalas())
                {
                    return View("Victoria");
                }
                else
                {
                    Console.WriteLine("entra terciaria");
                    return RedirectToAction("Comenzar");
                }
            }
            else
            {
                ViewBag.Clave = "clave incorrecta";
                return View("Habitacion" + (escape.GetEstadoJuego() - 1));
            }
        }
        else if (escape.ResolverSala(sala, clave))
        {
            ViewBag.ErrorSala = "sala incorrecta";
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
        Console.WriteLine("entra binker1");
        List<string> Jugadores = new List<string> { "NAVAS", "CARVAJAL", "RAMOS","VARANE","MARCELO","CASEMIRO","KROOS","MODRIC","ISCO","BENZEMA","RONALDO"};
        string incognita;
        incognita = Jugador.ToUpper();
        int i = 0;
        bool encontrado = false; 
        ViewBag.Terminado = false;   
        int aciertos = 0;
        while (encontrado != true && Jugadores.Count > i)  
        {
            Console.WriteLine(Jugador);
            
            if (Jugadores[i] == incognita)
            {
                Jugadores.RemoveAt(i);
                ViewBag.Jugador = Jugador + " esta en este plantel";
                encontrado = true;
                aciertos ++;
            }
            else
            {
                i++;
                
            }
            
        }
        if(encontrado == false){
            ViewBag.Jugador = Jugador + " no esta en este plantel";
        }

        if (aciertos == 11)
        {
           ViewBag.Terminado = true;
        }
        return View("Habitacion0");
    }
}
