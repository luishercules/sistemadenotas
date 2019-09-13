using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeNotas.BL
{
    public class NotasBL
    {
        Contexto _contexto;
        public List<Nota> ListadeNotas { get; set;}

        public NotasBL()
        {
            _contexto = new Contexto();
            ListadeNotas = new List<Nota>();
        }

        public List<Nota> ObtenerNotas()
        {
            ListadeNotas = _contexto.Notas
                .Include("Alumno") 
                .ToList();
            {
                ListadeNotas = _contexto.Notas
                 .Include("Asignatura")
                 .ToList();
            }
            return ListadeNotas;
        }

        public void GuardarNota(Nota nota)
        {
     nota.NotaFinal = (nota.PrimerParcial + nota.SegundoParcial + nota.TercerParcial);

            _contexto.Notas.Add(nota);

   nota.NotaFinal = (nota.PrimerParcial + nota.SegundoParcial + nota.TercerParcial)/3;

         

            _contexto.SaveChanges();
      
        }

        public void EliminarNota()
        {
            var nota = _contexto.Notas.Find();
            _contexto.Notas.Remove(nota);
            _contexto.SaveChanges();
        }

    }
    
}
