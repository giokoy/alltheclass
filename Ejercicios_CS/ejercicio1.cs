using System;
using System.Globalization;

namespace Ejercicio1Operaciones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Usamos CultureInfo.InvariantCulture para permitir decimales con punto (.) o coma (,)
            CultureInfo cultura = CultureInfo.InvariantCulture;

            Console.WriteLine("========================================");
            Console.WriteLine("     CALCULADORA DE OPERACIONES BÁSICAS  ");
            Console.WriteLine("========================================\n");

            // Entrada del primer valor
            double valor1 = SolicitarNumero("Ingrese el primer valor: ", cultura);

            // Entrada del segundo valor
            double valor2 = SolicitarNumero("Ingrese el segundo valor: ", cultura);

            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("               RESULTADOS               ");
            Console.WriteLine("----------------------------------------");

            // Operaciones básicas
            double suma = valor1 + valor2;
            double resta = valor1 - valor2;
            double multiplicacion = valor1 * valor2;

            Console.WriteLine($"Suma ({valor1} + {valor2}): {suma:F2}");
            Console.WriteLine($"Resta ({valor1} - {valor2}): {resta:F2}");
            Console.WriteLine($"Multiplicación ({valor1} * {valor2}): {multiplicacion:F2}");

            // Validación de división entre cero
            if (valor2 != 0)
            {
                double division = valor1 / valor2;
                Console.WriteLine($"División ({valor1} / {valor2}): {division:F4}");
            }
            else
            {
                Console.WriteLine($"División ({valor1} / {valor2}): Error (no se puede dividir entre cero).");
            }

            // Raíz cuadrada del primer valor
            if (valor1 >= 0)
            {
                Console.WriteLine($"Raíz cuadrada de {valor1}: {Math.Sqrt(valor1):F4}");
            }
            else
            {
                Console.WriteLine($"Raíz cuadrada de {valor1}: No real (número negativo).");
            }

            // Raíz cuadrada del segundo valor
            if (valor2 >= 0)
            {
                Console.WriteLine($"Raíz cuadrada de {valor2}: {Math.Sqrt(valor2):F4}");
            }
            else
            {
                Console.WriteLine($"Raíz cuadrada de {valor2}: No real (número negativo).");
            }

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        // Método auxiliar para garantizar que el usuario ingrese un número válido
        static double SolicitarNumero(string mensaje, CultureInfo cultura)
        {
            double numero;
            while (true)
            {
                Console.Write(mensaje);
                string? entrada = Console.ReadLine();

                // Reemplazamos coma por punto para facilitar la lectura
                if (!string.IsNullOrWhiteSpace(entrada) && 
                    double.TryParse(entrada.Replace(',', '.'), NumberStyles.Any, cultura, out numero))
                {
                    return numero;
                }

                Console.WriteLine("Entrada no válida. Por favor, introduzca un número válido.");
            }
        }
    }
}