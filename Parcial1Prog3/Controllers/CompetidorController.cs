using Microsoft.AspNetCore.Mvc;
using Parcial1Prog3.Datos;
using Parcial1Prog3.Models;

namespace Parcial1Prog3.Controllers
{
    public class CompetidorController : Controller
    {
        CompetidorDatos _BD = new CompetidorDatos();

        public IActionResult Index()
        {
            return View(_BD.ListarCompetidores());
        }

        public IActionResult Create()
        {
            ViewBag.Disciplina = _BD.ListarDisciplina();
            return View(new Competidor());
        }
        [HttpPost]
        public IActionResult Create(Competidor competidor)
        {
            try
            {
                if (!ModelState.IsValid) { return View(); }

                ViewBag.Error = _BD.CrearCompetidor(competidor);

                if(ViewBag.Error != "") 
                { 
                    return View(); 
                }
                else 
                { 
                    return RedirectToAction("Index");
                }

            }
            catch { return View(); }
        }
    }
}
