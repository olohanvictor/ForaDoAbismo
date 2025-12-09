using System; // Importa a biblioteca principal do C# para entrada/saída (Console)
using System.Threading; // Importa a biblioteca para trabalhar com Threads (execução paralela)

public abstract class Personagem
{
    // Atributos básicos de qualquer personagem
    protected int fortitude { get; set; } // Define resistência física
    protected int agilidade { get; set; } // Define rapidez e reflexos
    protected int forca { get; set; } // Define força física
    protected int sabedoria { get; set; } // Define inteligência ou percepção

    protected int hp { get; set; } // Pontos de vida
    protected int classearmadura { get; set; } // Define a defesa do personagem

    // Método para exibir os atributos do personagem
    public void Exibir()
    {
        Console.WriteLine($"HP: {hp}"); // Mostra os pontos de vida
        Console.WriteLine($"Classe de Armadura: {classearmadura}"); // Mostra a defesa
        Console.WriteLine($"Sabedoria: {sabedoria}"); // Mostra sabedoria
        Console.WriteLine($"Força: {forca}"); // Mostra força
        Console.WriteLine($"Agilidade: {agilidade}"); // Mostra agilidade
        Console.WriteLine($"Fortitude: {fortitude}"); // Mostra fortitude
    }
}

// Classe derivada de Personagem representando um Guerreiro
public class Guerreiro : Personagem
{
    public Guerreiro()
    {
        // Define os atributos específicos do Guerreiro
        fortitude = 15;
        agilidade = 11;
        sabedoria = 9;
        forca = 16;

        // Calcula HP e classe de armadura baseados nos atributos
        hp = 30 + fortitude;
        classearmadura = 15 + agilidade;
    }
}

// Classe derivada de Personagem representando um Mago
public class Mago : Personagem
{
    public Mago()
    {
        // Define atributos do Mago
        fortitude = 10;
        agilidade = 8;
        sabedoria = 16;
        forca = 6;

        // Calcula HP e classe de armadura
        hp = 20 + fortitude;
        classearmadura = 12 + agilidade;
    }
}

// Classe derivada de Personagem representando um Arqueiro
public class Arqueiro : Personagem
{
    public Arqueiro()
    {
        // Define atributos do Arqueiro
        fortitude = 8;
        agilidade = 16;
        sabedoria = 7;
        forca = 10;

        // Calcula HP e classe de armadura
        hp = 15 + fortitude;
        classearmadura = 20 + agilidade;
    }
}

// Classe principal que roda o programa
public class Program
{
    static bool jogoRodando = true; //  para controlar o loop do jogo

    public static void Main()
    {
        Personagem personagem = new Arqueiro(); // Cria um personagem do tipo Arqueiro, pd ser guerreiro ou mago

        // Cria uma thread para receber comandos do usuário de forma paralela
        Thread comandoThread = new Thread(() =>
        {
            while (jogoRodando) // Loop que mantém a thread rodando enquanto o jogo está ativo
            {
                string input = Console.ReadLine().ToLower(); // Lê o comando do usuário e transforma em minúsculo

                if (input == "atributos") // Se o comando for "atributos", ele vai escrever os atributos de acordo com a classe
                {
                    Console.WriteLine("\n========== ATRIBUTOS ==========");

                    // Identifica a classe do personagem
                    if (personagem is Guerreiro)
                        Console.WriteLine("Classe: GUERREIRO");
                    else if (personagem is Mago)
                        Console.WriteLine("Classe: MAGO");
                    else if (personagem is Arqueiro)
                        Console.WriteLine("Classe: ARQUEIRO");

                    // Exibe os atributos do personagem
                    personagem.Exibir();

                    Console.WriteLine("================================\n");
                }
            }
        });

        comandoThread.Start(); // Inicia a thread que ficará esperando os comandos do usuário
    }
}
