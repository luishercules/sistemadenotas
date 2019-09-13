using SistemaDeNotas.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeNotas.WebAdmin.Controllers
{
    public class NotasController : Controller
    {
        NotasBL _notasBL;
        AlumnosBL _alumnosBL;
        AsignaturasBL _asignaturasBL;

        public NotasController() //Constructor de la clase
        {
            _notasBL = new NotasBL();
            _alumnosBL = new AlumnosBL();
            _asignaturasBL = new AsignaturasBL();


        }

        // GET: Notas
        public ActionResult Index()
        {
            var ListadeNotas = _notasBL.ObtenerNotas();

            return View(ListadeNotas);
        }

        public ActionResult Crear()
        {
            var nuevaNota = new Nota();

            var alumnos = _alumnosBL.ObtenerAlumnos();
            var asignaturas = _asignaturasBL.ObtenerAsignatura();

            ViewBag.AlumnoId = new SelectList(alumnos, "Id", "Nombre");
            ViewBag.AsignaturaId = new SelectList(asignaturas, "Id", "Nombre");

            return View(nuevaNota);
        }

        [HttpPost]
        public ActionResult Crear(Nota nota)
        {
            if (ModelState.IsValid)
            {
                if (nota.AsignaturaId == 0)
                {
                    ModelState.AddModelError("Asignatura", "Seleccione una Asignatura");
                    return View(nota);
                }
                if (nota.AlumnoId == 0)
                {
                    ModelState.AddModelError("Alumno", "Seleccione un Alumno");
                    return View(nota);
                }

                _notasBL.GuardarNota(nota);
                return RedirectToAction("Index");
            }

            var alumnos = _alumnosBL.ObtenerAlumnos();
            ViewBag.AlumnoId = new SelectList(alumnos, "Id", "Nombre");

            var asignaturas = _asignaturasBL.ObtenerAsignatura();
            ViewBag.AsignaturaId = new SelectList(asignaturas, "Id", "Nombre");

            return View(nota);
        }



        public ActionResult Eliminar()
        {
            var nota = _notasBL.ObtenerNotas();
            return View(nota);
        }

        [HttpPost]
        public ActionResult Eliminar(Nota nota)
        {
            _notasBL.EliminarNota();
            return RedirectToAction("Index");
        }
    }

}
