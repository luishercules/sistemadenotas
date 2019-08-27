﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeNotas.BL
{
    public class CategoriasBL

    {
        Contexto _contexto;

        public List<Categoria> ListadeCategorias { get; set; }


        public CategoriasBL()
        {
            _contexto = new Contexto();
            ListadeCategorias = new List<Categoria>();
        }


        public List<Categoria> ObtenerCategorias()
        {
            ListadeCategorias = _contexto.Categorias.ToList();
            return _contexto.Categorias.ToList();
        }

        public void GuardarCategoria(Categoria categoria)
        {
            if (categoria.Id == 0)
            {
                _contexto.Categorias.Add(categoria);
            }
            else
            {
                var categoriaAgregada = _contexto.Categorias.Find(categoria.Id);
                categoriaAgregada.Id = categoria.Id;
                categoriaAgregada.Descripcion = categoria.Descripcion;
            }
            _contexto.SaveChanges();
        }

        public Categoria ObtenerCategorias(int Id)
        {
            var categoria = _contexto.Categorias.Find(Id);
            return categoria;
        }

        public void EliminarCategoria(int Id)
        {
            var categoria = _contexto.Categorias.Find(Id);
            _contexto.Categorias.Remove(categoria);
            _contexto.SaveChanges();
        }
    }

}