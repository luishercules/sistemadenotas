using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeNotas.BL
{
    public class AlumnosBL
    {
        public List<Alumno> ObtenerAlumnos()
        {
            var alumno1 = new Alumno();
            alumno1.Id = 1;
            alumno1.Nombre = "Luis Hercules ";
            alumno1.Notas = 90;

            var alumno2 = new Alumno();
            alumno2.Id = 2;
            alumno2.Nombre = "Danny Nuñez ";
            alumno2.Notas = 95;

            var alumno3 = new Alumno();
            alumno3.Id = 3;
            alumno3.Nombre = "Cristian ";
            alumno3.Notas = 100;

            var listadeAlumnos = new List<Alumno>();
            listadeAlumnos.Add(alumno1);
            listadeAlumnos.Add(alumno2);
            listadeAlumnos.Add(alumno3);
            return listadeAlumnos;
        }
    }
}
