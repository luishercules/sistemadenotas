using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeNotas.BL
{
    public class Alumno
    {
        public Alumno()
        {
            Activo = true;

        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese la descripcion")]
        [MinLength(3, ErrorMessage = "Ingrese minimo 3 caracteres")]
        [MaxLength(20, ErrorMessage = "Ingrese maximo 20 caracteres")]

        public string Nombre { get; set; }
        public int CategoriaId { get; set; }
        public string Descripcion { get; set; }//Pertenece a Categorías
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "Ingrese la Nota")]
        [Range(0, 100, ErrorMessage = "Ingrese una nota entre 0 a 100")]
        public double Notas { get; set; }

        [Display(Name ="Imagen")]
        public string UrlImagen { get; set; }

        public bool Activo { get; set; }
    }
}
    