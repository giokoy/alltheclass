using System;

static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        if (balance < 0m)
        {
            return 3.213f;
        }
        else if (balance < 1000m)
        {
            return 0.5f;
        }
        else if (balance < 5000m)
        {
            return 1.621f;
        }
        else
        {
            return 2.475f;
        }
    }

    public static decimal Interest(decimal balance)
    {
        return balance * ((decimal)InterestRate(balance) / 100m);
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance + Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int years = 0;
        while (balance < targetBalance)
        {
            balance = AnnualBalanceUpdate(balance);
            years++;
        }
        return years;
    }
}

class SavingsAccountProgram
{
    static void Main(string[] args)
    {
        decimal initialBalance = 200.75m;
        decimal targetBalance = 214.88m;

        // 1. Tasa de interés correspondiente al saldo
        float rate = SavingsAccount.InterestRate(initialBalance);
        Console.WriteLine($"Saldo inicial: {initialBalance:C}");
        Console.WriteLine($"Tasa de interés aplicada: {rate}%");

        // 2. Interés generado en un año
        decimal interestEarned = SavingsAccount.Interest(initialBalance);
        Console.WriteLine($"Interés anual generado: {interestEarned:C}");

        // 3. Saldo acumulado tras el primer año
        decimal updatedBalance = SavingsAccount.AnnualBalanceUpdate(initialBalance);
        Console.WriteLine($"Saldo actualizado (año 1): {updatedBalance:C}");

        // 4. Años necesarios para alcanzar la meta deseada
        int years = SavingsAccount.YearsBeforeDesiredBalance(initialBalance, targetBalance);
        Console.WriteLine($"\nAños para alcanzar {targetBalance:C}: {years} años");

        // 5. Caso con saldo negativo (penalización / tasa especial)
        decimal negativeBalance = -0.123m;
        Console.WriteLine($"\nTasa para saldo negativo ({negativeBalance:C}): {SavingsAccount.InterestRate(negativeBalance)}%");
    }
}