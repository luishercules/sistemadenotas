using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeNotas.BL
{
   public class Nota
    {
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public Alumno Alumno { get; set; }
        public int AsignaturaId { get; set; }
        public Asignatura Asignatura { get; set; }
        public double Total { get; set; }
        public bool Activo { get; set; }



        public double PrimerParcial { get; set; }
        public double SegundoParcial { get; set; }
        public double TercerParcial { get; set; }
        public string Observacion { get; set; }
        public double NotaFinal { get; set; }

        public List<DetalleNota> ListadeDetalleNota { get; set; }

        public Nota()
        {
            Activo = true;
            
        }
    }


    public class DetalleNota
    {
        public int Id { get; set; }
        public int NotaId { get; set; }
        public Nota Nota { get; set; }

        //public int AlumnoId { get; set; }
        //public Alumno Alumno { get; set; }

        //public int AsignaturaId { get; set; }
        //public Asignatura Asignatura { get; set; }

        public int PrimerParcial { get; set; }
        public int SegundoParcial { get; set; }
        public int TercerParcial { get; set; }
        public double NotaFinal { get; set; }
    }
}
