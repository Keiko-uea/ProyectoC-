using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TraductorInglesEspanol
{
    class Traductor
    {
        private Dictionary<string, string> diccionario;

        public Traductor()
        {
            diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                {"time", "tiempo"},
                {"person", "persona"},
                {"year", "año"},
                {"way", "camino"},
                {"day", "día"},
                {"thing", "cosa"},
                {"man", "hombre"},
                {"world", "mundo"},
                {"life", "vida"},
                {"hand", "mano"},
                {"part", "parte"},
                {"child", "niño"},
                {"eye", "ojo"},
                {"woman", "mujer"},
                {"place", "lugar"},
                {"work", "trabajo"},
                {"week", "semana"},
                {"case", "caso"},
                {"point", "punto"},
                {"government", "gobierno"},
                {"company", "empresa"},
            };
        }

        // Método para agregar nueva palabra al diccionario
        public void AgregarPalabra(string ingles, string espanol)
        {
            if (diccionario.ContainsKey(ingles))
            {
                Console.WriteLine($"La palabra '{ingles}' ya existe en el diccionario con traducción '{diccionario[ingles]}'.");
            }
            else
            {
                diccionario[ingles] = espanol;
                Console.WriteLine($"Palabra '{ingles}' agregada con traducción '{espanol}'.");
            }
        }

        // Método para traducir frase palabra por palabra
        public string TraducirFrase(string frase)
        {
            // Mantener signos de puntuación y espacios usando Regex
            var tokens = Regex.Matches(frase, @"[\w']+|[.,!?;]|\s+"); 
            var resultado = "";

            foreach (Match token in tokens)
            {
                string palabra = token.Value;

                // Si es palabra (letras), traducir si está en diccionario
                if (Regex.IsMatch(palabra, @"^\w+$"))
                {
                    string palabraMinuscula = palabra.ToLower();

                    if (diccionario.TryGetValue(palabraMinuscula, out string traduccion))
                    {
                        // Mantener mayúscula inicial si la palabra original la tiene
                        if (char.IsUpper(palabra[0]))
                        {
                            traduccion = char.ToUpper(traduccion[0]) + traduccion.Substring(1);
                        }
                        resultado += traduccion;
                    }
                    else
                    {
                        resultado += palabra;
                    }
                }
                else
                {
                    // No es palabra, copiar directamente (espacios, puntuación)
                    resultado += palabra;
                }
            }
            return resultado;
        }
    }

    class Programa
    {
        static void Main(string[] args)
        {
            Traductor traductor = new Traductor();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n==================== MENÚ ====================");
                Console.WriteLine("1. Traducir una frase");
                Console.WriteLine("2. Agregar palabras al diccionario");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Ingrese la frase a traducir:");
                        string frase = Console.ReadLine();
                        string traduccion = traductor.TraducirFrase(frase);
                        Console.WriteLine("Traducción: " + traduccion);
                        break;

                    case "2":
                        Console.Write("Ingrese la palabra en inglés: ");
                        string palabraIng = Console.ReadLine().Trim();
                        Console.Write("Ingrese la traducción en español: ");
                        string palabraEsp = Console.ReadLine().Trim();
                        if (!string.IsNullOrEmpty(palabraIng) && !string.IsNullOrEmpty(palabraEsp))
                        {
                            traductor.AgregarPalabra(palabraIng, palabraEsp);
                        }
                        else
                        {
                            Console.WriteLine("Las palabras no pueden estar vacías.");
                        }
                        break;

                    case "0":
                        salir = true;
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}
