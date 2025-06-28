/*	Escribir un programa que almacene las asignaturas de un curso 
(por ejemplo Matemáticas, Física, Química, Historia y Lengua) en una lista, pregunte al usuario la nota que ha sacado en cada asignatura y elimine de la lista las asignaturas aprobadas.
 Al final el programa debe mostrar por pantalla las asignaturas que el usuario tiene que
  repetir.*/
  
using System;
using System.Collections.Generic;
using System.Linq;

// Definición de la clase Asignatura
class Asignatura
{
    public string Nombre { get; set; }
    public double Nota { get; set; }

    public Asignatura(string nombre)
    {
        Nombre = nombre;
    }
}

class Program
{
    static void Main()
    {
        List<Asignatura> asignaturas = new List<Asignatura>
        {
            new Asignatura("Matemáticas"),
            // Asignaturas:
            new Asignatura("Lengua"),
            new Asignatura("Historia")
        };

        foreach (var a in asignaturas)
        {
            Console.Write($"Nota de {a.Nombre}: ");
            a.Nota = Convert.ToDouble(Console.ReadLine());
        }

        var repetir = asignaturas.Where(a => a.Nota < 5).ToList();
        Console.WriteLine("\nAsignaturas a repetir: " + 
                         string.Join(", ", repetir.Select(a => a.Nombre)));
    }
}


