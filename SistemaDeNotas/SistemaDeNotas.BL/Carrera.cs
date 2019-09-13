using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeNotas.BL
{
    public class Carrera
    {
        public int Id { get; set; }

       [Required(ErrorMessage ="Ingrese la Carrera")]
        public string Descripcion { get; set; }
    
    }
}
