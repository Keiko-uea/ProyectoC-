using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Ciudadano
{
    public string Nombre { get; set; }
    public string Vacuna { get; set; } // "Pfizer", "AstraZeneca", o null
    public int Dosis { get; set; } // 0 = no vacunado, 1 = primera dosis, 2 = segunda dosis
}

class Program
{
    static void Main()
    {
        // Crear los 500 ciudadanos
        List<Ciudadano> ciudadanos = new List<Ciudadano>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add(new Ciudadano { Nombre = "Ciudadano " + i, Vacuna = null, Dosis = 0 });
        }

        // Vacunar 75 con Pfizer (divididos en dosis 1 y 2)
        var pfizerIds = Enumerable.Range(1, 75).ToList();
        foreach (var id in pfizerIds)
        {
            ciudadanos[id - 1].Vacuna = "Pfizer";
            ciudadanos[id - 1].Dosis = (id <= 40) ? 2 : 1; // 40 tienen dosis 2, 35 solo dosis 1
        }

        // Vacunar 75 con AstraZeneca (divididos en dosis 1 y 2)
        var astraZenecaIds = Enumerable.Range(76, 75).ToList();
        foreach (var id in astraZenecaIds)
        {
            ciudadanos[id - 1].Vacuna = "AstraZeneca";
            ciudadanos[id - 1].Dosis = (id <= 110) ? 2 : 1; // 35 tienen dosis 2, 40 solo dosis 1
        }

        // Listas por operación de conjuntos usando HashSet con nombres de ciudadanos
        HashSet<string> todos = ciudadanos.Select(c => c.Nombre).ToHashSet();

        HashSet<string> vacunadosPfizer = ciudadanos.Where(c => c.Vacuna == "Pfizer").Select(c => c.Nombre).ToHashSet();
        HashSet<string> vacunadosAstra = ciudadanos.Where(c => c.Vacuna == "AstraZeneca").Select(c => c.Nombre).ToHashSet();

        HashSet<string> dosis2 = ciudadanos.Where(c => c.Dosis == 2).Select(c => c.Nombre).ToHashSet();

        // No vacunados
        HashSet<string> noVacunados = new HashSet<string>(todos);
        noVacunados.ExceptWith(vacunadosPfizer);
        noVacunados.ExceptWith(vacunadosAstra);

        // Han recibido ambas dosis (de la misma vacuna)
        HashSet<string> ambasDosisPfizer = vacunadosPfizer.Intersect(dosis2).ToHashSet();
        HashSet<string> ambasDosisAstra = vacunadosAstra.Intersect(dosis2).ToHashSet();
        
        HashSet<string> ambasDosis = new HashSet<string>(ambasDosisPfizer);
        ambasDosis.UnionWith(ambasDosisAstra);

        // Solo han recibido Pfizer (cualquier dosis)
        HashSet<string> soloPfizer = new HashSet<string>(vacunadosPfizer);
        soloPfizer.ExceptWith(vacunadosAstra);

        // Solo han recibido AstraZeneca (cualquier dosis)
        HashSet<string> soloAstra = new HashSet<string>(vacunadosAstra);
        soloAstra.ExceptWith(vacunadosPfizer);

        // Generar reporte
        string reporte = $"Reporte de vacunación COVID-19 - {DateTime.Now}\n\n" +
            $"Total ciudadanos: {todos.Count}\n" +
            $"No vacunados: {noVacunados.Count}\n" +
            $"Han recibido ambas dosis (Pfizer o AstraZeneca): {ambasDosis.Count}\n" +
            $"Han recibido solo Pfizer (cualquier dosis): {soloPfizer.Count}\n" +
            $"Han recibido solo AstraZeneca (cualquier dosis): {soloAstra.Count}\n\n" +
            $"Listado No vacunados:\n{string.Join(", ", noVacunados.OrderBy(n => n))}\n\n" +
            $"Listado ambas dosis:\n{string.Join(", ", ambasDosis.OrderBy(n => n))}\n\n" +
            $"Listado solo Pfizer:\n{string.Join(", ", soloPfizer.OrderBy(n => n))}\n\n" +
            $"Listado solo AstraZeneca:\n{string.Join(", ", soloAstra.OrderBy(n => n))}";

        // Guardar en archivo de texto
        File.WriteAllText("ReporteVacunacion.txt", reporte);

        Console.WriteLine("Reporte generado: ReporteVacunacion.txt\n");
        Console.WriteLine("Contenido del reporte:\n");
        Console.WriteLine(reporte);
    }
}
