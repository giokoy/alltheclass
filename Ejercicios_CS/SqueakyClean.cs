using System;
using System.Text;

namespace LimpiadorIdentificadores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("   PRUEBAS DEL LIMPIADOR DE VARIABLES    ");
            Console.WriteLine("=========================================\n");

            // Arreglo con casos de prueba para verificar las reglas del método Clean
            string[] casosDePrueba = 
            {
                "mi identificador",      // Espacios se convierten en '_'
                "kebab-case-variable",   // Guiones capitalizan la siguiente letra
                "hola\0mundo",           // Caracteres de control se convierten en 'CTRL'
                "alfaαbetaβ",            // Letras griegas minúsculas se omiten
                "var_123!@#",            // Números y símbolos se descartan (excepto '_')
                "   ---"                 // Casos extremos
            };

            // Ejecutar y mostrar cada prueba
            foreach (string prueba in casosDePrueba)
            {
                // Reemplazamos los caracteres de control visibles en consola para que se vea claro el original
                string originalVisible = prueba.Replace("\0", "\\0"); 
                
                Console.WriteLine($"Original: {originalVisible}");
                Console.WriteLine($"Limpio:   {Identifier.Clean(prueba)}");
                Console.WriteLine("-----------------------------------------");
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }

    // Tu clase original intacta
    public static class Identifier
    {
        public static string Clean(string identifier)
        {
            var sb = new StringBuilder();
            bool capitalizeNext = false;

            for (int i = 0; i < identifier.Length; i++)
            {
                char c = identifier[i];

                if (c == ' ')
                {
                    sb.Append('_');
                }
                else if (char.IsControl(c))
                {
                    sb.Append("CTRL");
                }
                else if (c == '-')
                {
                    capitalizeNext = true;
                }
                else if (c >= 'α' && c <= 'ω')
                {
                    // Omite letras griegas en minúsculas
                    continue;
                }
                else if (char.IsLetter(c))
                {
                    if (capitalizeNext)
                    {
                        sb.Append(char.ToUpperInvariant(c));
                        capitalizeNext = false;
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
                else if (c == '_')
                {
                    sb.Append(c);
                }
                // Cualquier otro carácter (números, símbolos, etc.) se descarta automáticamente
            }

            return sb.ToString();
        }
    }
}