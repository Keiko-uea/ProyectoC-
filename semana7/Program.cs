/* Verificación de paréntesis balanceados en una expresión matemática. */

using System;
using System.Collections.Generic;

class BalanceoSimbolos
{
    /// <summary>
    /// Verifica si una expresión tiene paréntesis, llaves y corchetes balanceados.
    /// </summary>
    /// <param name="expresion">La expresión a verificar.</param>
    /// <returns>True si está balanceada, False en caso contrario.</returns>
    public static bool EstaBalanceada(string expresion)
    {
        Stack<char> pila = new Stack<char>();
        foreach (char c in expresion)
        {
            // Si es un símbolo de apertura, lo apilamos
            if (c == '(' || c == '{' || c == '[')
                pila.Push(c);
            // Si es un símbolo de cierre, verificamos si corresponde al tope de la pila
            else if (c == ')' || c == '}' || c == ']')
            {
                if (pila.Count == 0) return false;
                char tope = pila.Pop();
                if ((c == ')' && tope != '(') ||
                    (c == '}' && tope != '{') ||
                    (c == ']' && tope != '['))
                    return false;
            }
        }
        // La pila debe quedar vacía si todo está balanceado
        return pila.Count == 0;
    }

    static void Main()
    {
        Console.WriteLine("Ingrese la expresión a verificar:");
        string expresion = Console.ReadLine();
        if (EstaBalanceada(expresion))
            Console.WriteLine("Fórmula balanceada.");
        else
            Console.WriteLine("Fórmula desbalanceada.");
    }
}