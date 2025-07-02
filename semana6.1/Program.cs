using System;

class Nodo
{
    public int Valor;
    public Nodo Siguiente;

    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

class ListaEnlazada
{
    public Nodo Primero;

    public ListaEnlazada()
    {
        Primero = null;
    }

    // Agrega un nodo al final de la lista
    public void Agregar(int valor)
    {
        Nodo nuevo = new Nodo(valor);
        if (Primero == null)
        {
            Primero = nuevo;
        }
        else
        {
            Nodo actual = Primero;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevo;
        }
    }

    // Elimina nodos cuyo valor esté fuera del rango [min, max]
    public void EliminarFueraDeRango(int min, int max)
    {
        Nodo actual = Primero;
        Nodo anterior = null;

        while (actual != null)
        {
            if (actual.Valor < min || actual.Valor > max)
            {
                if (anterior == null)
                {
                    // Eliminar el primer nodo
                    Primero = actual.Siguiente;
                    actual = Primero;
                }
                else
                {
                    anterior.Siguiente = actual.Siguiente;
                    actual = actual.Siguiente;
                }
            }
            else
            {
                anterior = actual;
                actual = actual.Siguiente;
            }
        }
    }

    // Imprime la lista
    public void Imprimir()
    {
        Nodo actual = Primero;
        while (actual != null)
        {
            Console.Write(actual.Valor + " ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }
}

class Programa
{
    static void Main()
    {
        ListaEnlazada lista = new ListaEnlazada();
        Random rnd = new Random();

        // Generar 50 números aleatorios entre 1 y 999
        for (int i = 0; i < 50; i++)
        {
            int num = rnd.Next(1, 1000);
            lista.Agregar(num);
        }

        Console.WriteLine("Lista original:");
        lista.Imprimir();

        Console.WriteLine("Ingrese el valor mínimo del rango:");
        int min = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el valor máximo del rango:");
        int max = int.Parse(Console.ReadLine());

        lista.EliminarFueraDeRango(min, max);

        Console.WriteLine("Lista después de eliminar nodos fuera del rango:");
        lista.Imprimir();
    }
}

