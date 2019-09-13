using SistemaDeNotas.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeNotas.WebAdmin.Controllers
{
    public class CarrerasController : Controller
    {

        CarrerasBL _carrerasBL;

        public CarrerasController()
        {
            _carrerasBL = new CarrerasBL();
            }
 
        // GET: Carreras
        public ActionResult Index()
        {
            var ListadeCarreras = _carrerasBL.ObtenerCarreras();

            return View(ListadeCarreras);
        }

        public ActionResult Crear()
        {
            var nuevaCarrera = new Carrera();
            return View(nuevaCarrera);
        }

        [HttpPost]
        public ActionResult Crear(Carrera carrera)
        {

            if (ModelState.IsValid)
            {   
                 if(carrera.Descripcion != carrera.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion","No debe contener espacios antes ni después");
                    return View(carrera);
                }
                _carrerasBL.GuardarCarrera(carrera);
                return RedirectToAction("Index");
            }

            return View(carrera);
              
        }
        
        public ActionResult Editar(int Id)
        {
            var Carrera = _carrerasBL.ObtenerCarreras(Id);
            return View();
        }

        [HttpPost]
        public ActionResult Editar(Carrera carrera)
        {
            if (ModelState.IsValid)
            {
                if (carrera.Descripcion != carrera.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "No debe contener espacios antes ni después");
                    return View(carrera);
                }
                _carrerasBL.GuardarCarrera(carrera);
                return RedirectToAction("Index");
            }

            return View(carrera);
        }


        public ActionResult Detalle(int Id)
        {
            var Carrera = _carrerasBL.ObtenerCarreras(Id);
            return View(Carrera);
        }


        public ActionResult Eliminar(int Id)
        {
            var Carrera = _carrerasBL.ObtenerCarreras(Id);
            return View(Carrera);
        }

        [HttpPost]
        public ActionResult Eliminar(Carrera carrera)
        {
            _carrerasBL.EliminarCarrera(carrera.Id);
            return RedirectToAction("Index");
        }


    }
}