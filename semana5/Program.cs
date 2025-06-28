/* 1.	Escribir un programa que almacene las asignaturas de un curso (por ejemplo Matemáticas, Física, Química, Historia y Lengua) en una lista, pregunte al usuario la nota que ha sacado en cada asignatura, y después las muestre por pantalla con el mensaje En <asignatura> has sacado <nota> donde <asignatura> es cada una des las asignaturas de la lista y <nota> cada una de las correspondientes notas introducidas por el usuario.*/
using System;
using System.Collections.Generic;
using System.Text;

namespace Semana5
{
    public class Asignatura
    {
        public string Nombre { get; set; }
        public double Nota { get; set; }

        public Asignatura(string nombre) => Nombre = nombre;

        public void MostrarResultado() =>
            Console.WriteLine($"En {Nombre} has sacado {Nota}");
    }

    public class Program
    {
        static void Main()
        {
            List<Asignatura> asignaturas = new List<Asignatura>
            {
                new Asignatura("Matemáticas"),
                new Asignatura("Física"),
                new Asignatura("Química"),
                new Asignatura("Historia"),
                new Asignatura("Lengua")
            };

            foreach (var asignatura in asignaturas)
            {
                Console.Write($"Nota de {asignatura.Nombre}: ");
                asignatura.Nota = Convert.ToDouble(Console.ReadLine());
            }

            foreach (var asignatura in asignaturas)
                asignatura.MostrarResultado();
        }
    }
}
