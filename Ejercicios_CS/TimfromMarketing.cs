using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string deptStr = (department ?? "OWNER").ToUpperInvariant();

        if (id.HasValue)
        {
            return $"[{id}] - {name} - {deptStr}";
        }

        return $"{name} - {deptStr}";
    }
}

class BadgeProgram
{
    static void Main(string[] args)
    {
        // 1. Empleado estándar con ID y departamento
        string badge1 = Badge.Print(734, "Ernest Johnny Walker", "Marketing");
        Console.WriteLine(badge1);

        // 2. Nuevo empleado sin ID asignado (id es null)
        string badge2 = Badge.Print(null, "Jane Doe", "Procurement");
        Console.WriteLine(badge2);

        // 3. Propietario con ID pero sin departamento (department es null -> OWNER)
        string badge3 = Badge.Print(254, "Charlotte Hale", null);
        Console.WriteLine(badge3);

        // 4. Propietario nuevo sin ID ni departamento (ambos null)
        string badge4 = Badge.Print(null, "Stephen Hawking", null);
        Console.WriteLine(badge4);
    }
}