using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeNotas.BL
{
    public class AlumnosBL
    {
        Contexto _contexto;

        public List<Alumno> ListadeAlumnos { get; set; }

        public AlumnosBL()

        {
            _contexto = new Contexto();
            ListadeAlumnos = new List<Alumno>();

        }


        public List<Alumno> ObtenerAlumnos()
        {
            ListadeAlumnos = _contexto.Alumnos.ToList();
            return _contexto.Alumnos.ToList(); ;
        }
    }
}
