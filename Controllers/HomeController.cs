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
        ViewBag.EstadoJuego = escape.GetEstadoJuego();
        return View(ViewBag.EstadoJuego);
    }
    public IActionResult Tutorial(){
        return View();
    }
    public IActionResult Habitacion(int sala, string clave)
    {
        int Salacorrecta = escape.GetEstadoJuego();
        if(sala -1 == escape.GetEstadoJuego())
        {
            if(escape.ResolverSala(sala, clave))
            {
                if(sala-1 == escape.ContarSalas()){
                    return View ("Victoria");
                }
                else{
                    return View ("Habitacion" + Salacorrecta+1);
                }
            }
            else{
                ViewBag.Error = clave;
                return View ("Habitacion" + Salacorrecta);
            }
        }
        else{
            return View ("Habitacion" + Salacorrecta);
        }
    }
}
