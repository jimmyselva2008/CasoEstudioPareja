using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoEstudioPareja
{

    // Clase para representar un libro
    internal class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Año { get; set; }
        public string Descripcion { get; set; }
        public Libro(string titulo, string autor, int ano, string descripcion)
        {
            Titulo = titulo;
            Autor = autor;
            Año = ano;
            Descripcion = descripcion;
        }
        public override string ToString()
        {
            return $"Título: {Titulo}, Autor: {Autor}, Año: {Año}, Descripción: {Descripcion}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
