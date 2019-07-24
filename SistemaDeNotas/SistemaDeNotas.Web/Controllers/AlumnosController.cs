﻿using SistemaDeNotas.BL;
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

            var alumnosBL = new AlumnosBL();
            var listadeAlumnos = alumnosBL.ObtenerAlumnos();

            return View(listadeAlumnos);
        }
    }
}