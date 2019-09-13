using SistemaDeNotas.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeNotas.WebAdmin.Controllers
{
    public class AsignaturasController : Controller
    {
        AsignaturasBL _asignaturasBL;

        public AsignaturasController()
        {
            _asignaturasBL = new AsignaturasBL();

        }
        // GET: Asignaturas
        public ActionResult Index()
        {
        var ListadeAsignaturas = _asignaturasBL.ObtenerAsignatura();

        return View(ListadeAsignaturas);
       
        }

        public ActionResult Crear()
        {
            var nuevaAsignatura = new Asignatura();
            return View(nuevaAsignatura);
        }

        [HttpPost]
        public ActionResult Crear(Asignatura asignatura)
        {

            if (ModelState.IsValid)
            {
                if (asignatura.Descripcion != asignatura.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "No debe contener espacios antes ni después");
                    return View(asignatura);
                }
                _asignaturasBL.GuardarAsignatura(asignatura);
                return RedirectToAction("Index");
            }

            return View(asignatura);

        }

        public ActionResult Editar(int Id)
        {
            var Asignatura = _asignaturasBL.ObtenerAsignatura(Id);
            return View();
        }

        [HttpPost]
        public ActionResult Editar(Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                if (asignatura.Descripcion != asignatura.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "No debe contener espacios antes ni después");
                    return View(asignatura);
                }
                _asignaturasBL.GuardarAsignatura(asignatura);
                return RedirectToAction("Index");
            }

            return View(asignatura);
        }


        public ActionResult Detalle(int Id)
        {
            var Asignatura = _asignaturasBL.ObtenerAsignatura(Id);
            return View(Asignatura);
        }


        public ActionResult Eliminar(int Id)
        {
            var Asignatura = _asignaturasBL.ObtenerAsignatura(Id);
            return View(Asignatura);
        }

        [HttpPost]
        public ActionResult Eliminar(Asignatura asignatura)
        {
            _asignaturasBL.EliminarAsignatura(asignatura.Id);
            return RedirectToAction("Index");
        }
    }
}
