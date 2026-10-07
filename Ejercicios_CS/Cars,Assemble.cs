using System;

static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        if (speed == 0) return 0.0;
        if (speed <= 4) return 1.0;
        if (speed <= 8) return 0.9;
        if (speed == 9) return 0.8;
        return 0.77;
    }

    public static double ProductionRatePerHour(int speed)
    {
        return speed * 221 * SuccessRate(speed);
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        return (int)(ProductionRatePerHour(speed) / 60);
    }
}

class AssemblyLineProgram
{
    static void Main(string[] args)
    {
        int[] speeds = { 0, 1, 4, 7, 9, 10 };

        Console.WriteLine($"{"Velocidad",-10} {"Tasa de éxito",-16} {"Producción/Hora",-18} {"Ítems/Minuto",-15}");
        Console.WriteLine(new string('-', 60));

        foreach (int speed in speeds)
        {
            double successRate = AssemblyLine.SuccessRate(speed);
            double ratePerHour = AssemblyLine.ProductionRatePerHour(speed);
            int itemsPerMinute = AssemblyLine.WorkingItemsPerMinute(speed);

            Console.WriteLine($"{speed,-10} {successRate,-16:P0} {ratePerHour,-18:F1} {itemsPerMinute,-15}");
        }
    }
}