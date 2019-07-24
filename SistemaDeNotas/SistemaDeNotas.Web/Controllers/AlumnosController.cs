using SistemaDeNotas.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeNotas.Web.Controllers
{
    public class AlumnosController : Controller
    {
        // GET: Alumnos
        public ActionResult Index()
        {
            var alumno1 = new AlumnoModel();
            alumno1.Id = 1;
            alumno1.Nombre = "Luis Hercules";

            var alumno2 = new AlumnoModel();
            alumno2.Id = 2;
            alumno2.Nombre = "Danny Nuñez";

            var alumno3 = new AlumnoModel();
            alumno3.Id = 3;
            alumno3.Nombre = "Cristian ";

            var listadeAlumnos = new List<AlumnoModel>();
            listadeAlumnos.Add(alumno1);
            listadeAlumnos.Add(alumno2);
            listadeAlumnos.Add(alumno3);
            return View(listadeAlumnos);
        }
    }
}