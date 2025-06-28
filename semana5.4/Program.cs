using System;
using System.Collections.Generic;
using System.Linq;

class MuestraEstadistica
{
    private List<double> numeros = new List<double>();

    public void AgregarNumeros(string entrada)
    {
        string[] partes = entrada.Split(',')
                                 .Select(s => s.Trim())
                                 .Where(s => !string.IsNullOrWhiteSpace(s))
                                 .ToArray();

        foreach (var parte in partes)
        {
            if (double.TryParse(parte, out double num))
                numeros.Add(num);
        }
    }

    public double CalcularMedia()
    {
        if (numeros.Count == 0) return 0;
        return numeros.Average();
    }

    public double CalcularDesviacionTipica()
    {
        if (numeros.Count < 2) return 0; // Necesitamos al menos dos valores

        double media = CalcularMedia();
        double sumaCuadrados = numeros.Sum(n => Math.Pow(n - media, 2));
        return Math.Sqrt(sumaCuadrados / numeros.Count);
    }
}

class Program
{
    static void Main()
    {
        var estadistica = new MuestraEstadistica();

        Console.WriteLine("Introduce números separados por comas:");
        string entrada = Console.ReadLine();

        estadistica.AgregarNumeros(entrada);

        Console.WriteLine($"Media: {estadistica.CalcularMedia()}");
        Console.WriteLine($"Desviación típica: {estadistica.CalcularDesviacionTipica()}");
    }
}


