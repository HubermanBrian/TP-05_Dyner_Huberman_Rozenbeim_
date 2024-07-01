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
        int Salacorrecta = escape.GetEstadoJuego();
        return View ("Habitacion" + (Salacorrecta));
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
                    return RedirectToAction("Comenzar");
                }
            }
            else{
                ViewBag.Error = "clave incorrecta";
                return View ("Habitacion" + (Salacorrecta-1));
            }
        }
        else{
            return View ("Habitacion" + (Salacorrecta-1));
        }
    }
}
