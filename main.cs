using System;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== TESTE DO SISTEMA DE COMBATE FSM ===\n");
        ControleDeTurno controleDeTurno = new ControleDeTurno();
        controleDeTurno.Iniciar();
        Console.WriteLine("\n=== FIM DO TESTE ===");
    }
}
