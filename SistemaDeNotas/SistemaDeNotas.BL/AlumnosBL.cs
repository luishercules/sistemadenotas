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
            ListadeAlumnos = _contexto.Alumnos
                .Include("Categoria")
                .ToList();  
            return ListadeAlumnos;
        }

        public void  GuardarAlumno(Alumno alumno)
        {
            if (alumno.Id ==0) 
            { _contexto.Alumnos.Add(alumno);
            } else
            {
                var alumnoMatriculado = _contexto.Alumnos.Find(alumno.Id);
                alumnoMatriculado.Nombre = alumno.Nombre;
                alumnoMatriculado.Notas = alumno.Notas;
                alumnoMatriculado.UrlImagen = alumno.UrlImagen;
            }
            _contexto.SaveChanges();
        }

        public Alumno ObtenerAlumnos(int Id)
        {
            var alumno = _contexto.Alumnos
                  .Include("Categoria").FirstOrDefault(p => p.Id == Id);
                return alumno;
        }

        public void EliminarAlumno(int Id)
        {
            var alumno = _contexto.Alumnos.Find(Id);
            _contexto.Alumnos.Remove(alumno);
            _contexto.SaveChanges();
        }

    }
}
