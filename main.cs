using System;
using Game;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("╔════════════════════════════════════════════════════════╗");
        Console.WriteLine("║     SISTEMA DE COMBATE - FORA DO ABISMO              ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════╝\n");

        // Exemplo test de combate 
        var jogador = new global::Personagem.Guerreiro();
        jogador.Nome = "Herói";
        jogador.X = 0;
        jogador.Y = 0;

        var inimigo = new global::Personagem.Mago();
        inimigo.Nome = "Mago Sombrio";
        inimigo.X = 5;
        inimigo.Y = 5;

       
        var gerenciadorCombate = new GerenciadorCombate(jogador, inimigo);
        bool jogadorVenceu = gerenciadorCombate.IniciarCombate();

        // Exibir resultado
        Console.WriteLine("\n╔════════════════════════════════════════════════════════╗");
        if (jogadorVenceu)
        {
            Console.WriteLine("║             VITÓRIA DO JOGADOR!                   ║");
        }
        else
        {
            Console.WriteLine("║             DERROTA DO JOGADOR                   ║");
        }
        Console.WriteLine("╚════════════════════════════════════════════════════════╝\n");

        // Exibir status final
        Console.WriteLine("=== STATUS FINAL ===\n");
        gerenciadorCombate.GetJogador().Exibir();
        gerenciadorCombate.GetInimigo().Exibir();

        Console.WriteLine("Pressione ENTER para sair...");
        Console.ReadLine();
    }
}
