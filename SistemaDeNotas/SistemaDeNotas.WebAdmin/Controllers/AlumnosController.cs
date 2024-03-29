﻿using SistemaDeNotas.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeNotas.WebAdmin.Controllers
{
    public class AlumnosController : Controller
    {
        AlumnosBL _alumnosBL;
        CarrerasBL _carrerasBL;

        public AlumnosController()
        {
            _alumnosBL = new AlumnosBL();
            _carrerasBL = new CarrerasBL();
        }
        // GET: Alumnos
        public ActionResult Index()
        {
            var listadeAlumnos = _alumnosBL.ObtenerAlumnos();

            return View(listadeAlumnos);
        }

       public ActionResult Crear()
        {
            var nuevoAlumno = new Alumno();
            var Carreras = _carrerasBL.ObtenerCarreras();

            ViewBag.CarreraId = new SelectList(Carreras, "Id", "Descripcion");

             return View(nuevoAlumno);
        }

        [HttpPost]
        public ActionResult Crear (Alumno alumno, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (alumno.CarreraId == 0)
                   {
                    ModelState.AddModelError("CarreraId", "Seleccione una Carrera");
                    return View(alumno);
                }

                if(imagen != null)
                {
                    alumno.UrlImagen = GuardarImagen(imagen);
                }
                _alumnosBL.GuardarAlumno(alumno);

                return RedirectToAction("Index");
            }
            var Carreras = _carrerasBL.ObtenerCarreras();

            ViewBag.CarreraId = new SelectList(Carreras, "Id", "Descripcion");

            return View(alumno);  
        }

        public ActionResult Editar (int Id )
        {
           var alumno = _alumnosBL.ObtenerAlumnos(Id);
            var Carreras = _carrerasBL.ObtenerCarreras();

            ViewBag.CarreraId = new SelectList (Carreras, "Id", "Descripcion", alumno.CarreraId);
           return View(alumno);
        }

        [HttpPost]
        public ActionResult Editar(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                if (alumno.CarreraId == 0)
                {
                    ModelState.AddModelError("CarreraId", "Seleccione una Carrera");
                    return View(alumno);
                }
                _alumnosBL.GuardarAlumno(alumno);
                return RedirectToAction("Index");
            }
            var Carreras = _carrerasBL.ObtenerCarreras();

            ViewBag.CarreraId = new SelectList(Carreras, "Id", "Descripcion");

            return View(alumno);
        }

       
        public ActionResult Detalle (int Id)
        {
            var alumno = _alumnosBL.ObtenerAlumnos(Id);

             return View(alumno);
        }


        public ActionResult Eliminar(int Id)
        {
            var alumno = _alumnosBL.ObtenerAlumnos(Id);

            return View(alumno);
        }

        [HttpPost]
        public ActionResult Eliminar (Alumno alumno)
        {
            _alumnosBL.EliminarAlumno(alumno.Id);
            return RedirectToAction("Index");
        }


        private string GuardarImagen(HttpPostedFileBase imagen)
        {
            string path = Server.MapPath("~/Imagenes/" + imagen.FileName);
            imagen.SaveAs(path);

            return "/Imagenes/" + imagen.FileName;
        }
    }
}