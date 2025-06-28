/* 2.	Escribir un programa que pregunte al usuario los números 
ganadores de la lotería primitiva, los almacene en una lista y los muestre por pantalla
 ordenados de menor a mayor.*/
 
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numeros = new List<int>();
        Console.WriteLine("Introduce 6 números ganadores (1-49):");

        while (numeros.Count < 6)
        {
            if (int.TryParse(Console.ReadLine(), out int n) && n >= 1 && n <= 49)
                numeros.Add(n);
            else
                Console.WriteLine("Número inválido. Inténtalo de nuevo.");
        }

        numeros.Sort();
        Console.WriteLine("\nNúmeros ordenados: " + string.Join(", ", numeros));
    }
}

