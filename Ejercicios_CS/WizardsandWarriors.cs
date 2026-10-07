using System;

abstract class Character
{
    private readonly string _characterType;

    protected Character(string characterType)
    {
        _characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        return $"Character is a {_characterType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        return target.Vulnerable() ? 10 : 6;
    }
}

class Wizard : Character
{
    private bool _hasPreparedSpell = false;

    public Wizard() : base("Wizard")
    {
    }

    public void PrepareSpell()
    {
        _hasPreparedSpell = true;
    }

    public override bool Vulnerable()
    {
        return !_hasPreparedSpell;
    }

    public override int DamagePoints(Character target)
    {
        return _hasPreparedSpell ? 12 : 3;
    }
}

class WizardsAndWarriorsProgram
{
    static void Main(string[] args)
    {
        var warrior = new Warrior();
        var wizard = new Wizard();

        // 1. Mostrar tipos de personaje (ToString)
        Console.WriteLine(warrior);
        Console.WriteLine(wizard);

        // 2. Estado inicial de vulnerabilidad
        Console.WriteLine($"\n¿Guerrero vulnerable?: {warrior.Vulnerable()}"); // false
        Console.WriteLine($"¿Mago vulnerable sin hechizo?: {wizard.Vulnerable()}"); // true

        // 3. Daño antes de preparar hechizo
        Console.WriteLine($"\nDaño de Guerrero contra Mago vulnerable: {warrior.DamagePoints(wizard)}"); // 10
        Console.WriteLine($"Daño de Mago sin preparar contra Guerrero: {wizard.DamagePoints(warrior)}"); // 3

        // 4. Preparar hechizo
        wizard.PrepareSpell();
        Console.WriteLine("\n--- El mago prepara su hechizo ---");
        Console.WriteLine($"¿Mago vulnerable tras preparar hechizo?: {wizard.Vulnerable()}"); // false

        // 5. Daño después de preparar hechizo
        Console.WriteLine($"Daño de Guerrero contra Mago preparado: {warrior.DamagePoints(wizard)}"); // 6
        Console.WriteLine($"Daño de Mago preparado contra Guerrero: {wizard.DamagePoints(warrior)}"); // 12
    }
}