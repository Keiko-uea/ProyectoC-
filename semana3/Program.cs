using System;

namespace RegistroEstudiante
{
    // Definición de la clase Estudiante
    public class Estudiante
    {
        // Propiedades básicas del estudiante
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }

        // Array para almacenar tres teléfonos
        public string[] Telefonos { get; set; }

        // Constructor para inicializar el estudiante con sus datos
        public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
        {
            Id = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;

            // Validar que el array de teléfonos tenga exactamente 3 números
            if (telefonos.Length == 3)
            {
                Telefonos = telefonos;
            }
            else
            {
                throw new ArgumentException("Se deben proporcionar exactamente tres números de teléfono.");
            }
        }

        // Método para mostrar la información del estudiante
        public void MostrarInformacion()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombres: {Nombres}");
            Console.WriteLine($"Apellidos: {Apellidos}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine("Teléfonos:");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine($"  Teléfono {i + 1}: {Telefonos[i]}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creación de un array con tres teléfonos
            string[] telefonosEstudiante = { "0994572012", "0987514610", "0975240112" };

            // Instanciación de un objeto Estudiante
            Estudiante estudiante1 = new Estudiante(1, "Keiko Domenica", "Yanacallo Oña", "Km. 134 Via Quito Lago Agrio", telefonosEstudiante);

            // Mostrar datos del estudiante
            estudiante1.MostrarInformacion();
        }
    }
}
