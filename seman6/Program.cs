using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        LinkedList<int> lista1 = new LinkedList<int>();
        LinkedList<int> lista2 = new LinkedList<int>();

        // Carga de la primera lista
        Console.Write("¿Cuántos elementos desea ingresar en la primera lista? ");
        int n1 = LeerEnteroPositivo();

        for (int i = 0; i < n1; i++)
        {
            Console.Write($"Ingrese el elemento #{i + 1} para la primera lista: ");
            int valor = LeerEntero();
            lista1.AddFirst(valor);  // Inserción al inicio
        }

        // Carga de la segunda lista
        Console.Write("¿Cuántos elementos desea ingresar en la segunda lista? ");
        int n2 = LeerEnteroPositivo();

        for (int i = 0; i < n2; i++)
        {
            Console.Write($"Ingrese el elemento #{i + 1} para la segunda lista: ");
            int valor = LeerEntero();
            lista2.AddFirst(valor);  // Inserción al inicio
        }

        // Comparación de las listas
        bool mismoTamaño = (lista1.Count == lista2.Count);
        bool mismoContenido = false;

        if (mismoTamaño)
        {
            // Comparamos elemento por elemento en orden
            var nodo1 = lista1.First;
            var nodo2 = lista2.First;
            mismoContenido = true;

            while (nodo1 != null && nodo2 != null)
            {
                if (nodo1.Value != nodo2.Value)
                {
                    mismoContenido = false;
                    break;
                }
                nodo1 = nodo1.Next;
                nodo2 = nodo2.Next;
            }
        }

        // Mostrar resultados
        if (mismoTamaño && mismoContenido)
        {
            Console.WriteLine("a. Las listas son iguales en tamaño y en contenido.");
        }
        else if (mismoTamaño && !mismoContenido)
        {
            Console.WriteLine("b. Las listas son iguales en tamaño pero no en contenido.");
        }
        else
        {
            Console.WriteLine("c. No tienen el mismo tamaño ni contenido.");
        }
    }

    // Método auxiliar para leer un entero positivo válido
    static int LeerEnteroPositivo()
    {
        int valor;
        while (!int.TryParse(Console.ReadLine(), out valor) || valor < 0)
        {
            Console.Write("Entrada inválida. Ingrese un número entero positivo: ");
        }
        return valor;
    }

    // Método auxiliar para leer un entero válido
    static int LeerEntero()
    {
        int valor;
        while (!int.TryParse(Console.ReadLine(), out valor))
        {
            Console.Write("Entrada inválida. Ingrese un número entero: ");
        }
        return valor;
    }
}

