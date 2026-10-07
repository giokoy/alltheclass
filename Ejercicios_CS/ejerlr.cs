using System;
using System.Collections.Generic;

namespace Ejercicio2Calificaciones
{
    // Clase para representar a cada estudiante y encapsular su lógica
    class Estudiante
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
        public double Nota3 { get; set; }
        public double Nota4 { get; set; }

        // Propiedad calculada para el promedio
        public double Promedio => (Nota1 + Nota2 + Nota3 + Nota4) / 4.0;

        // Propiedad calculada para el literal basado en las reglas requeridas
        public string Literal
        {
            get
            {
                if (Promedio >= 90) return "A";
                if (Promedio >= 80) return "B";
                if (Promedio >= 70) return "C";
                return "D"; // Incluye promedios < 70
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Estudiante> listaEstudiantes = new List<Estudiante>();
            bool ingresarMas = true;

            Console.WriteLine("==========================================================");
            Console.WriteLine("      SISTEMA DE CALIFICACIONES - COLEGIO DIOS ES BUENO   ");
            Console.WriteLine("==========================================================\n");

            // Bucle para ingresar datos de forma continua
            while (ingresarMas)
            {
                Estudiante nuevoEstudiante = new Estudiante();

                Console.Write("Ingrese el Nombre del estudiante: ");
                nuevoEstudiante.Nombre = Console.ReadLine() ?? "Sin Nombre";

                Console.Write("Ingrese el Apellido del estudiante: ");
                nuevoEstudiante.Apellido = Console.ReadLine() ?? "Sin Apellido";

                nuevoEstudiante.Nota1 = SolicitarNota("Nota 1");
                nuevoEstudiante.Nota2 = SolicitarNota("Nota 2");
                nuevoEstudiante.Nota3 = SolicitarNota("Nota 3");
                nuevoEstudiante.Nota4 = SolicitarNota("Nota 4");

                listaEstudiantes.Add(nuevoEstudiante);

                Console.Write("\n¿Desea ingresar otro estudiante? (s/n): ");
                string? respuesta = Console.ReadLine();
                if (respuesta?.Trim().ToLower() != "s")
                {
                    ingresarMas = false;
                }
                Console.WriteLine();
            }

            // Impresión del reporte final
            Console.Clear();
            Console.WriteLine("Colegio Dios es bueno. Calificaciones del cuatrimestre");
            Console.WriteLine("==========================================================================================");
            // Uso de formato de interpolación con alineación (ej. ,-12 alinea a la izquierda ocupando 12 espacios)
            Console.WriteLine($"{"Nombre",-12} {"Apellido",-12} {"Nota1",-7} {"Nota2",-7} {"Nota3",-7} {"Nota4",-7} {"Promedio",-10} {"Literal",-7}");
            Console.WriteLine("==========================================================================================");

            foreach (var est in listaEstudiantes)
            {
                Console.WriteLine($"{est.Nombre,-12} {est.Apellido,-12} {est.Nota1,-7:F0} {est.Nota2,-7:F0} {est.Nota3,-7:F0} {est.Nota4,-7:F0} {est.Promedio,-10:F2} {est.Literal,-7}");
            }
            
            Console.WriteLine("==========================================================================================");
            Console.WriteLine("\nPresione cualquier tecla para finalizar...");
            Console.ReadKey();
        }

        // Método auxiliar para validar que la nota sea un número correcto (0-100)
        static double SolicitarNota(string nombreNota)
        {
            double nota;
            while (true)
            {
                Console.Write($"Ingrese {nombreNota} (0-100): ");
                if (double.TryParse(Console.ReadLine(), out nota) && nota >= 0 && nota <= 100)
                {
                    return nota;
                }
                Console.WriteLine("Error: Ingrese un valor numérico válido entre 0 y 100.");
            }
        }
    }
}