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
    public IActionResult Comenzar(){
        ViewBag.Sala =  escape.GetEstadoJuego();
        return View ("Habitacion" + ( escape.GetEstadoJuego()-1));
    }
    public IActionResult Tutorial(){
        return View();
    }
    public IActionResult Habitacion(int sala, string clave)
    {
        Console.WriteLine("entra principal");
       
        if(sala == escape.GetEstadoJuego())
        {
            Console.WriteLine("entra secudaria");
            if(escape.ResolverSala(sala, clave))
            {
                if(sala == escape.ContarSalas()){
                    return View ("Victoria");
                }
                else{
                    Console.WriteLine("entra terciaria");
                    return RedirectToAction("Comenzar");
                }
            }
            else{
                ViewBag.Error = "clave incorrecta";
                return RedirectToAction("Comenzar");
            }
        }
        else{
            return RedirectToAction("Comenzar");
        }
    }
}
