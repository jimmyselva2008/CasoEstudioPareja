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

            // Lista de libros
            List<Libro> libros = new List<Libro>
            {
                new Libro("El Quijote", "Cervantes", 1605, "Una aventura épica de un caballero andante."),
                new Libro("1984", "Orwell", 1949, "Una distopía sobre vigilancia y control."),
                new Libro("Cien años de soledad", "García Márquez", 1967, "Historia de la familia Buendía."),
                new Libro("Donde los árboles cantan", "Delibes", 1986, "Novela sobre la naturaleza y la guerra."),
                new Libro("La sombra del viento", "Zafón", 2001, "Misterio en la Barcelona de posguerra.")
            };

            // Lista ordenada de autores para búsqueda binaria
            List<string> autoresOrdenados = libros.Select(l => l.Autor).OrderBy(a => a).ToList();

            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("\n--- Biblioteca Digital Estudiantil ---");
                Console.WriteLine("1. Búsqueda lineal por título");
                Console.WriteLine("2. Búsqueda binaria por autor");
                Console.WriteLine("3. Encontrar libro más reciente");
                Console.WriteLine("4. Encontrar libro más antiguo");
                Console.WriteLine("5. Búsqueda de coincidencias en descripciones");
                Console.WriteLine("6. Salir");
                Console.Write("Elige una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingresa el título a buscar: ");
                        string tituloBuscar = Console.ReadLine();
                        var libroEncontrado = BusquedaLineal(libros, tituloBuscar);
                        Console.WriteLine(libroEncontrado != null ? $"Encontrado: {libroEncontrado}" : "Libro no encontrado.");
                        break;

                    case "2":
                        Console.Write("Ingresa el autor a buscar: ");
                        string autorBuscar = Console.ReadLine();
                        bool encontrado = BusquedaBinaria(autoresOrdenados, autorBuscar);
                        Console.WriteLine(encontrado ? $"Autor '{autorBuscar}' encontrado." : "Autor no encontrado.");
                        break;
                    case "3":
                        var masReciente = libros.OrderByDescending(l => l.Año).First();
                        Console.WriteLine($"Libro más reciente: {masReciente}");
                        break;
                    case "4":
                        var masAntiguo = libros.OrderBy(l => l.Año).First();
                        Console.WriteLine($"Libro más antiguo: {masAntiguo}");
                        break;

                    case "5":
                        Console.Write("Ingresa la palabra clave para buscar en descripciones: ");
                        string palabraClave = Console.ReadLine();
                        var coincidencias = BusquedaCoincidencias(libros, palabraClave);
                        if (coincidencias.Any())
                        {
                            Console.WriteLine("Libros con coincidencias:");
                            foreach (var libro in coincidencias)
                            {
                                Console.WriteLine(libro);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encontraron coincidencias.");
                        }
                        break;
                    case "6":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                    }
                }
            }

        // Búsqueda lineal: Recorre la lista hasta encontrar el título
        static Libro BusquedaLineal(List<Libro> libros, string titulo)
        {
            foreach (var libro in libros)
            {
                if (libro.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
                {
                    return libro;
                }
            }
            return null;
        }

        // Búsqueda binaria: En lista ordenada de autores
        static bool BusquedaBinaria(List<string> autores, string autor)
        {
            int izquierda = 0, derecha = autores.Count - 1;

            while (izquierda <= derecha)
            {
                int medio = (izquierda + derecha) / 2;
                int comparacion = string.Compare(autores[medio], autor, StringComparison.OrdinalIgnoreCase);
                if (comparacion == 0)
                {
                    return true;
                }
                else if (comparacion < 0)
                {
                    izquierda = medio + 1;
                }
                else
                {
                    derecha = medio - 1;
                }
            }
            return false;
        }

        // Búsqueda de coincidencias en descripciones
        static List<Libro> BusquedaCoincidencias(List<Libro> libros, string palabraClave)
        {
            return libros.Where(l => l.Descripcion.IndexOf(palabraClave, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

    }
}
