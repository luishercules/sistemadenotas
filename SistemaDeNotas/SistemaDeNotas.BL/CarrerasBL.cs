using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeNotas.BL
{
    public class CarrerasBL

    {
        Contexto _contexto;

        public List<Carrera> ListadeCarreras { get; set; }


        public CarrerasBL()
        {
            _contexto = new Contexto();
            ListadeCarreras = new List<Carrera>();
        }


        public List<Carrera> ObtenerCarreras()
        {
            ListadeCarreras = _contexto.Carreras.ToList();
            return _contexto.Carreras.ToList();
        }

        public void GuardarCarrera(Carrera carreras)
        {
            if (carreras.Id == 0)
            {
                _contexto.Carreras.Add(carreras);
            }
            else
            {
                var carreraAgregada = _contexto.Carreras.Find(carreras.Id);
                carreraAgregada.Id = carreras.Id;
                carreraAgregada.Descripcion = carreras.Descripcion;
            }
            _contexto.SaveChanges();
        }

        public Carrera ObtenerCarreras(int Id)
        {
            var carrera = _contexto.Carreras.Find(Id);
            return carrera;
        }

        public void EliminarCarrera(int Id)
        {
            var carrera = _contexto.Carreras.Find(Id);
            _contexto.Carreras.Remove(carrera);
            _contexto.SaveChanges();
        }
        
    }

}