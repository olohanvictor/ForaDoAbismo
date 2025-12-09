using System;
using System.Threading;

public abstract class Personagem
{
    protected int fortitude { get; set; }
    protected int agilidade { get; set; }
    protected int forca { get; set; }
    protected int sabedoria { get; set; }

    protected int hp { get; set; }
    protected int classearmadura { get; set; }

    public void Exibir()
    {
        Console.WriteLine($"HP: {hp}");
        Console.WriteLine($"Classe de Armadura: {classearmadura}");
        Console.WriteLine($"Sabedoria: {sabedoria}");
        Console.WriteLine($"Força: {forca}");
        Console.WriteLine($"Agilidade: {agilidade}");
        Console.WriteLine($"Fortitude: {fortitude}");
    }
}

public class Guerreiro : Personagem
{
    public Guerreiro()
    {
        fortitude = 15;
        agilidade = 11;
        sabedoria = 9;
        forca = 16;

        hp = 30 + fortitude;
        classearmadura = 15 + agilidade;
    }
}

public class Mago : Personagem
{
    public Mago()
    {
        fortitude = 10;
        agilidade = 8;
        sabedoria = 16;
        forca = 6;

        hp = 20 + fortitude;
        classearmadura = 12 + agilidade;
    }
}

public class Arqueiro : Personagem
{
    public Arqueiro()
    {
        fortitude = 8;
        agilidade = 16;
        sabedoria = 7;
        forca = 10;

        hp = 15 + fortitude;
        classearmadura = 20 + agilidade;
    }
}

public class Program
{
    static bool jogoRodando = true;

    public static void Main()
    {
        
        Personagem personagem = new Arqueiro(); 

        

        Thread comandoThread = new Thread(() =>
        {
            while (jogoRodando)
            {
                string input = Console.ReadLine().ToLower();

                if (input == "atributos")
                {
                    Console.WriteLine("\n========== ATRIBUTOS ==========");

                    if (personagem is Guerreiro)
                        Console.WriteLine("Classe: GUERREIRO");
                    else if (personagem is Mago)
                        Console.WriteLine("Classe: MAGO");
                    else if (personagem is Arqueiro)
                        Console.WriteLine("Classe: ARQUEIRO");

                    personagem.Exibir();

                    Console.WriteLine("================================\n");
                }
            }
        });

        comandoThread.Start();

       
    }
}
