using System;
using System.Collections.Generic;

public static class Languages
{
    public static List<string> NewList()
    {
        return new List<string>();
    }

    public static List<string> GetExistingLanguages()
    {
        return new List<string> { "C#", "Clojure", "Elm" };
    }

    public static List<string> AddLanguage(List<string> languages, string language)
    {
        languages.Add(language);
        return languages;
    }

    public static int CountLanguages(List<string> languages)
    {
        return languages.Count;
    }

    public static bool HasLanguage(List<string> languages, string language)
    {
        return languages.Contains(language);
    }

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
    }

    public static bool IsExciting(List<string> languages)
    {
        if (languages.Count == 0)
        {
            return false;
        }

        if (languages[0] == "C#")
        {
            return true;
        }

        if (languages.Count >= 2 && languages.Count <= 3 && languages[1] == "C#")
        {
            return true;
        }

        return false;
    }

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);
        return languages;
    }

    public static bool IsUnique(List<string> languages)
    {
        var uniqueLanguages = new HashSet<string>(languages);
        return uniqueLanguages.Count == languages.Count;
    }
}

class LanguagesProgram
{
    static void Main(string[] args)
    {
        // 1. Obtener lista inicial
        List<string> myLanguages = Languages.GetExistingLanguages();
        Console.WriteLine("Lista inicial: " + string.Join(", ", myLanguages));

        // 2. Agregar un nuevo lenguaje
        Languages.AddLanguage(myLanguages, "F#");
        Console.WriteLine("Tras agregar F#: " + string.Join(", ", myLanguages));

        // 3. Contar elementos
        int total = Languages.CountLanguages(myLanguages);
        Console.WriteLine($"Total de lenguajes: {total}");

        // 4. Verificar existencia
        bool hasPython = Languages.HasLanguage(myLanguages, "Python");
        bool hasCSharp = Languages.HasLanguage(myLanguages, "C#");
        Console.WriteLine($"¿Tiene Python?: {hasPython}");
        Console.WriteLine($"¿Tiene C#?: {hasCSharp}");

        // 5. Evaluar si la lista es emocionante (IsExciting)
        bool exciting = Languages.IsExciting(myLanguages);
        Console.WriteLine($"¿Es emocionante?: {exciting}");

        // 6. Invertir la lista
        Languages.ReverseList(myLanguages);
        Console.WriteLine("Lista invertida: " + string.Join(", ", myLanguages));

        // 7. Eliminar un elemento
        Languages.RemoveLanguage(myLanguages, "Elm");
        Console.WriteLine("Tras eliminar Elm: " + string.Join(", ", myLanguages));

        // 8. Verificar unicidad de elementos
        bool unique = Languages.IsUnique(myLanguages);
        Console.WriteLine($"¿Todos los elementos son únicos?: {unique}");

        // 9. Probar duplicados con IsUnique
        Languages.AddLanguage(myLanguages, "C#");
        Console.WriteLine("Tras duplicar C#: " + string.Join(", ", myLanguages));
        Console.WriteLine($"¿Siguen siendo únicos?: {Languages.IsUnique(myLanguages)}");
    }
}