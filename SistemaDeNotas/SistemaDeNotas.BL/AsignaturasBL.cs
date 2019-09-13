using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeNotas.BL
{
   public class AsignaturasBL
    {
        Contexto _contexto;

        public List<Asignatura> ListadeAsignaturas { get; set; }


        public AsignaturasBL()
        {
            _contexto = new Contexto();
            ListadeAsignaturas = new List<Asignatura>();
        }


        public List<Asignatura> ObtenerAsignatura()
        {
            ListadeAsignaturas = _contexto.Asignaturas
                .ToList();
            return ListadeAsignaturas;
        }

        public void GuardarAsignatura(Asignatura asignatura)
        {
            if (asignatura.Id == 0)
            {
                _contexto.Asignaturas.Add(asignatura);
            }
            else
            {
                var asignaturaMatriculada = _contexto.Asignaturas.Find(asignatura.Id);
                asignaturaMatriculada.Id = asignatura.Id;
                asignaturaMatriculada.Hora = asignatura.Hora;
                asignaturaMatriculada.Catedratico = asignatura.Catedratico;
                asignaturaMatriculada.Aula = asignatura.Aula;
            }
            _contexto.SaveChanges();
        }

        public Asignatura ObtenerAsignatura(int Id)
        {
            var asignatura = _contexto.Asignaturas.Find(Id);    
            return asignatura;
        }

        public void EliminarAsignatura(int Id)
        {
            var asignatura = _contexto.Asignaturas.Find(Id);
            _contexto.Asignaturas.Remove(asignatura);
            _contexto.SaveChanges();
        }
    }
}
