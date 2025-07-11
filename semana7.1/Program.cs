/* Resolución del problema de las Torres de Hanoi. */

class Torre
{
    public Stack<int> Discos { get; private set; }
    public string Nombre { get; private set; }

    // Constructor que inicializa la pila de discos y asigna un nombre a la torre
    public Torre(string nombre)
    {
        Nombre = nombre;
        Discos = new Stack<int>();
    }
}

class TorresDeHanoi
{
    /// <summary>
    /// Método recursivo que resuelve el problema de las Torres de Hanoi.
    /// Mueve 'n' discos desde la torre 'origen' hacia la torre 'destino' usando 'auxiliar' como soporte.
    /// </summary>
    /// <param name="n">Número de discos a mover.</param>
    /// <param name="origen">Torre de origen (pila de discos).</param>
    /// <param name="destino">Torre destino (pila de discos).</param>
    /// <param name="auxiliar">Torre auxiliar para movimientos intermedios.</param>
    public static void Resolver(int n, Torre origen, Torre destino, Torre auxiliar)
    {
        if (n > 0)
        {
            // Mover n-1 discos desde origen a auxiliar, usando destino como soporte
            Resolver(n - 1, origen, auxiliar, destino);

            // Mover el disco restante (el más grande) de origen a destino
            int disco = origen.Discos.Pop();
            destino.Discos.Push(disco);
            Console.WriteLine($"Mover disco {disco} de {origen.Nombre} a {destino.Nombre}");

            // Mover los n-1 discos desde auxiliar a destino, usando origen como soporte
            Resolver(n - 1, auxiliar, destino, origen);
        }
    }

    static void Main()
    {
        Console.WriteLine("Ingrese el número de discos:");
        int n = int.Parse(Console.ReadLine());

        // Inicialización de las tres torres con sus nombres
        Torre origen = new Torre("Origen");
        Torre destino = new Torre("Destino");
        Torre auxiliar = new Torre("Auxiliar");

        // Apilar los discos en la torre origen, del disco más grande (n) al más pequeño (1)
        for (int i = n; i >= 1; i--)
            origen.Discos.Push(i);

        // Iniciar la resolución del problema mostrando cada movimiento
        Resolver(n, origen, destino, auxiliar);
    }
}
