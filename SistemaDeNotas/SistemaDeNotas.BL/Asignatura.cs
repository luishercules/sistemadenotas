using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeNotas.BL
{
   public  class Asignatura
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

 // public double Nota { get; set; }  creamos el atributo Nota por si lo utilizamos después

        public int Hora { get; set; }
        public string Catedratico { get; set; }
        public int Aula { get; set; }

        [Required(ErrorMessage = "Ingrese la Asignatura")]
        public string Descripcion { get; set; }
    }
}
