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
        fortitude = 7;
        agilidade = 10;
        sabedoria = 18;
        forca = 5;

        hp = 15 + fortitude;
        classearmadura = 10 + agilidade;
    }
}


public class Program
{
    static bool jogoRodando = true;

    public static void Main()
    {
        
        Personagem personagem = new Guerreiro();
        // ou: Personagem personagem = new Mago();

       

        // THREAD QUE SEMPRE ESCUTA "atributos"
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

                    personagem.Exibir();

                    Console.WriteLine("================================\n");
                }
            }
        });

        comandoThread.Start();

        
    }
}
