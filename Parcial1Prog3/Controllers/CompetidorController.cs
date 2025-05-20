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
                if (!ModelState.IsValid) 
                {
                    ViewBag.Disciplina = _BD.ListarDisciplina();
                    return View(competidor); 
                }

                ViewBag.Error = _BD.CrearCompetidor(competidor);

                if(ViewBag.Error != "") 
                {
                    ViewBag.Disciplina = _BD.ListarDisciplina();
                    return View(competidor); 
                }
                else 
                { 
                    return RedirectToAction("Index");
                }

            }
            catch 
            {
                ViewBag.Disciplina = _BD.ListarDisciplina();
                return View(competidor); 
            }
        }
    }
}
