using SistemaDeNotas.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeNotas.WebAdmin.Controllers
{
    public class DetalleNotasController : Controller
    {
    
        NotasBL _notasBL;

        public DetalleNotasController()
        {
            _notasBL = new NotasBL();
          
        }

        // GET: DetalleNotas
        public ActionResult Index()
        {
            var nota = _notasBL.ObtenerNotas();

            
            return View(nota);
        }
    }
}