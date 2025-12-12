using System;
using Game;
using Combate;

public static class Program
{
    // Variável global para armazenar o personagem do jogador

    public static global::Personagem.Personagem jogadorAtual = null;

    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;

        // Inicia o sistema de menu que chamará o IniciarJogo
        Sistemas.Inicio();
        Sistemas.Menu();
    }

    public static void IniciarJogo()
    {
        // 1. ===== INSTRUÇÕES E CONTROLES =====
        Program.ExibirTelaInicial();

        // 2. ===== CRIAÇÃO DE PERSONAGEM =====
        Program.CriarPersonagemComQuiz();

        // 3. ===== HISTÓRIA - CELA DOS ESCRAVOS =====
       
        CelaDoEscravos.CenaInicial();

        // 4. ===== LOOP DO JOGO (EXPLORAÇÃO E COMBATE) =====

        if (jogadorAtual != null)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✨ Você conseguiu escapar da cela!");
            Console.WriteLine("Agora você deve sobreviver aos abismos...\n");
            Console.ResetColor();
            Console.WriteLine("Pressione ENTER para entrar na exploração...");
            Console.ReadKey(true);

            GerenciadorDeNivel.EncontrarEntradaDoJogador();
            MovimentarJogador.MovimentaJogador();
        }

        Console.Clear();
        Sistemas.GameOver();
    }

    public static void ExibirTelaInicial()
    {
        // --- PÁGINA 1: Título e Controles ---
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
╔════════════════════════════════════════════════════════╗
║                                                        ║
║          🎮 FORA DO ABISMO - TACTICAL RPG 🎮           ║
║                                                        ║
║             Uma jornada de fuga e combate              ║
║                                                        ║
╚════════════════════════════════════════════════════════╝
        ");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Controles de Movimentação:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("  [W] - Mover para cima");
        Console.WriteLine("  [S] - Mover para baixo");
        Console.WriteLine("  [A] - Mover para esquerda");
        Console.WriteLine("  [D] - Mover para direita");
        Console.WriteLine("  [Q] - Sair do jogo");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nPressione ENTER para ver as lendas do mapa...");
        Console.ReadKey(true);

        // --- PÁGINA 2: Lendas do Mapa ---
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=== LENDAS DO MAPA ===\n");
        Console.ResetColor();

        Console.Write("  ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("P");
        Console.ResetColor();
        Console.WriteLine("  - Você (Jogador)");

        Console.Write("  ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(")( ");
        Console.ResetColor();
        Console.WriteLine(" - Saída/Entrada para próximo nível");

        Console.Write("  ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("*");
        Console.ResetColor();
        Console.WriteLine("   - Perigo/Armadilha");

        Console.Write("  ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("C");
        Console.ResetColor();
        Console.WriteLine("   - Inimigo/Carcereiro");

        Console.Write("  ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("♣");
        Console.ResetColor();
        Console.WriteLine("   - Árvore/Fungo Gigante");

        Console.Write("  ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("≈");
        Console.ResetColor();
        Console.WriteLine("   - Água/Lago");

        Console.Write("  ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("[ ]");
        Console.ResetColor();
        Console.WriteLine(" - Parede");

        Console.WriteLine("\nPrepare-se para definir seu destino...");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Pressione ENTER para criar seu personagem.");
        Console.ReadKey(true);
    }

    public static void CriarPersonagemComQuiz()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(@"
╔════════════════════════════════════════════════════════╗
║                                                        ║
║           🎭 CRIAÇÃO DE PERSONAGEM 🎭                  ║
║                                                        ║
║        Descubra sua verdadeira natureza...             ║
║                                                        ║
╚════════════════════════════════════════════════════════╝
        ");
        Console.ResetColor();

        
        var personagemTemp = new global::Personagem.Guerreiro();


        personagemTemp.DefinirNome();

        personagemTemp.DefinirGenero();

    
        jogadorAtual = personagemTemp.Quiz();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n✨ {jogadorAtual.Nome}, o {jogadorAtual.GetType().Name}! ✨\n");
        Console.ResetColor();

        jogadorAtual.DistribuirAtributos();

        // 5. Exibe ficha final
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n╔════════════════════════════════════════════════════════╗");
        Console.WriteLine("║            SUA FICHA FINAL DE PERSONAGEM               ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════╝\n");
        Console.ResetColor();

        jogadorAtual.Exibir();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nPressione ENTER para entrar no Subterrâneo...");
        Console.ReadKey(true);
    }
}