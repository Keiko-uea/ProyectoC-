/* 	Escribir un programa que almacene en una lista los números del 1 al 10 y los muestre por pantalla en orden inverso 
separados por comas.*/

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numeros = Enumerable.Range(1, 15).ToList();
        numeros.Reverse();
        Console.WriteLine("Números invertidos: " + string.Join(", ", numeros));
    }
}

