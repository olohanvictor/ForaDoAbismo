using System;

// --- CLASSE 1: ARMAZENAMENTO DE DADOS ---
// Repositório de dados e estado do jogo.
public class ArmazenadorDeMapa
{
    public static int mapaAtualIndex = 0;
    public static int pY = 2;
    public static int pX = 3;

    public static char[][][] todosOsMapas = new char[][][]
    {
        // --- MAPA 1: Prisão (Índice 0) ---
        new char[][]
        {
            "[][][][][][][][][][][][][][][][][][][][][][][][][]" .ToCharArray(),
            "[]      []     *           []   []   []   []    []" .ToCharArray(),
            "[] P     }   []  C         []   []   []   []    []" .ToCharArray(),
            "[][][][][]   []            []_[][]_[][]_[][]    []" .ToCharArray(),
            "[]      []   []                        C        []" .ToCharArray(),
            "[]       }   []               *                 []" .ToCharArray(),
            "[][][][][]   [][][]     [][][][][][][][][][][][][]" .ToCharArray(),
            "[]      []                                      []" .ToCharArray(),
            "[]       }      *  []                 []        []" .ToCharArray(),
            "[][][][][]   C     []  C       []  *  []        []" .ToCharArray(),
            "[]                 []          []     []        []" .ToCharArray(),
            "[]         []              *   []     [][][][][][]" .ToCharArray(),
            "[]         [][][][][][][]      []    C          []" .ToCharArray(),
            "[]                             []                )" .ToCharArray(),
            "[][][][][][][][][][][][][][][][][][][][][][][][][]" .ToCharArray(),
        },

        // --- MAPA 2: Corredor (Índice 1) ---
        new char[][]
        {
            "[][][][][][][][][][][][][][][][][][][][][][][][][]" .ToCharArray(), 
            "[]         []           [] *              []    []" .ToCharArray(),
            "[]   [][][][] C [][][][][]    []   [][][][][]    (" .ToCharArray(),
            "[]       []             []   [] C         []    []" .ToCharArray(),
            "[]   []      [][][][]   []   [][][][][]   [] *  []" .ToCharArray(),
            "[]   [][][][][]    []   []           []   []    []" .ToCharArray(),
            "[]    C      []         []      C    []         []" .ToCharArray(),
            "[]   [][][][][]   [][][][][][]    [][][][][][][][]" .ToCharArray(),
            "[]   []       []            []                  []" .ToCharArray(),
            "[]   [] [][][][][][][][] C  [][][][][][]   *    []" .ToCharArray(),
            "[]   []   *   []  C   []         []      [][][] []" .ToCharArray(),
            "[]   [][][]   []  []  [][][][]   []  [][][]  [] []" .ToCharArray(),
            " ) P              []        []           []     []" .ToCharArray(),
            "[][][][][][][][][][][][][][][][][][][][][][][][][]" .ToCharArray(),
        },
    
        // --- MAPA 3: LAGO (Índice 2) ---
        new char[][]
        {
            "[][][][][][][][][][][][][][][][][][][][][][][][][][][]" .ToCharArray(),
            "[]                      ♣                            (" .ToCharArray(),
            "[]  ♣                                    ≈≈≈≈≈≈≈≈≈≈≈[]" .ToCharArray(),
            "[]            ♣                       ≈≈≈≈≈≈≈≈≈≈≈≈≈≈[]" .ToCharArray(),
            "[]                                ≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈[]" .ToCharArray(),
            "[]       ♣                     ≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈[]" .ToCharArray(),
            "[]                            ≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈[]" .ToCharArray(),
            "[]                ♣           ≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈[]" .ToCharArray(),
            "[]                            ≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈[]" .ToCharArray(),
            "[]  ♣                         ≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈[]" .ToCharArray(),
            "[]          ♣                  ≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈[]" .ToCharArray(),
            "[]                              ≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈[]" .ToCharArray(),
            ") P                 ♣            ≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈[]" .ToCharArray(),
            "[]      ♣                           ≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈[]" .ToCharArray(),
            "[][][][][][][][][][][][][][][][][][][][][][][][][][][]" .ToCharArray(),
        },

        // --- MAPA 4: Cidade Costeira (Índice 3) ---
        new char[][]
        {
            "[][][][][][][][][][][][][][][][][][][][]" .ToCharArray(),
            "[]    ♣                               []" .ToCharArray(),
            ") P  ♣    П         ♣        П        []" .ToCharArray(),
            "[]    ♣                           ♣   []" .ToCharArray(),
            "[]                  П                 []" .ToCharArray(),
            "[]              ♣          П          []" .ToCharArray(),
            "[]   П                        ♣     П []" .ToCharArray(),
            "[]              П                     []" .ToCharArray(),
            "[]                 ♣            П     []" .ToCharArray(),
            "[]         ♣          П               []" .ToCharArray(),
            "[]       П                             (" .ToCharArray(),
            "[]           ≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈[]" .ToCharArray(),
            "[]≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈[]" .ToCharArray(),
            "[]≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈≈[]" .ToCharArray(),
            "[][][][][][][][][][][][][][][][][][][][]" .ToCharArray()
        },

        // --- MAPA 5: FLORESTA DO BOSS (Índice 4) ---
        new char[][]
        {
            "[][][][][][][][][][][][][][][][][][][][]" .ToCharArray(),
            "[]        ♣                           []" .ToCharArray(),
            "[]      ♣        ♣            ♣       []" .ToCharArray(),
            "[]   P     ♣           ♣          ♣   []" .ToCharArray(),
            "[]       ♣        ♣           ♣       []" .ToCharArray(),
            "[]         ♣           ♣          ♣   []" .ToCharArray(),
            "[]      ♣       ♣     ♣      ♣        []" .ToCharArray(),
            "[]        ♣            ♣         ♣   X[]" .ToCharArray(),
            "[]      ♣         ♣         ♣         []" .ToCharArray(),
            "[]         ♣           ♣          ♣   []" .ToCharArray(),
            "[]      ♣       ♣           ♣         []" .ToCharArray(),
            "[]         ♣           ♣              []" .ToCharArray(),
            "[]      ♣         ♣           ♣       []" .ToCharArray(),
            "[]                                    []" .ToCharArray(),
            "[][][][][][][][][][][][][][][][][][][][]" .ToCharArray(),
        },
    };
}

// --- CLASSE 2: GERENCIADOR DE NÍVEL ---
// Lógica para trocar de fase e reposicionar o jogador.
public class GerenciadorDeNivel
{
    public static void VerificarTrocaDeMapa()
    {
        char[][] mapaAtual = ArmazenadorDeMapa.todosOsMapas[ArmazenadorDeMapa.mapaAtualIndex];
        
        // Valida se posição está dentro dos limites
        if (ArmazenadorDeMapa.pY < 0 || ArmazenadorDeMapa.pY >= mapaAtual.Length ||
            ArmazenadorDeMapa.pX < 0 || ArmazenadorDeMapa.pX >= mapaAtual[ArmazenadorDeMapa.pY].Length)
        {
            return;
        }

        char pisoAtual = mapaAtual[ArmazenadorDeMapa.pY][ArmazenadorDeMapa.pX];

        // Se pisou na saída ')' ou '(', vai para o próximo nível
        if (pisoAtual == ')' || pisoAtual == '(')
        {
            CarregarProximoNivel();
        }
    }

    private static void CarregarProximoNivel()
    {
        ArmazenadorDeMapa.mapaAtualIndex++;

        // Verifica se acabaram os mapas
        if (ArmazenadorDeMapa.mapaAtualIndex >= ArmazenadorDeMapa.todosOsMapas.Length)
        {
            Console.Clear();
            Console.WriteLine("\n╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║         FIM DE JOGO - PARABÉNS!                       ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝\n");
            System.Threading.Thread.Sleep(2000);
            Environment.Exit(0);
        }

        // Procura onde o jogador deve nascer no novo mapa
        EncontrarEntradaDoJogador();
        
        Console.Clear();
        Console.WriteLine($"\n✨ Avançou para o Nível {ArmazenadorDeMapa.mapaAtualIndex + 1}!\n");
        System.Threading.Thread.Sleep(2000);
    }

    public static void EncontrarEntradaDoJogador()
    {
        char[][] mapa = ArmazenadorDeMapa.todosOsMapas[ArmazenadorDeMapa.mapaAtualIndex];
        
        for (int y = 0; y < mapa.Length; y++)
        {
            for (int x = 0; x < mapa[y].Length; x++)
            {
                if (mapa[y][x] == 'P')
                {
                    ArmazenadorDeMapa.pX = x;
                    ArmazenadorDeMapa.pY = y;
                    return; 
                }
            }
        }
    }
}

// --- CLASSE 3: LÓGICA DE IMPRESSÃO ---
// Utiliza CoresDoMapa para desenhar cada caractere.
public class ImprimiMapa 
{
    public static void DesenharMapa()
    {
        char[][] mapaAtual = ArmazenadorDeMapa.todosOsMapas[ArmazenadorDeMapa.mapaAtualIndex];
        ConsoleColor corOriginal = Console.ForegroundColor;

        try
        {
            Console.SetCursorPosition(0, 0);
        }
        catch
        {
            Console.Clear();
        }

        Console.WriteLine($"========= Nível {ArmazenadorDeMapa.mapaAtualIndex + 1} =========\n");
        
        for (int i = 0; i < mapaAtual.Length; i++)
        {
            for (int j = 0; j < mapaAtual[i].Length; j++)
            {
                char caractere = mapaAtual[i][j];
                
                // Se é a posição do jogador, desenha ele
                if (i == ArmazenadorDeMapa.pY && j == ArmazenadorDeMapa.pX)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write('P');
                }
                else
                {
                    Console.ForegroundColor = CoresDoMapa.ObterCorDoCaractere(caractere);
                    Console.Write(caractere);
                }
            }
            
            Console.WriteLine();
        }
        
        Console.ForegroundColor = corOriginal;
    }
}

// --- CLASSE 4: LÓGICA DE CORES ---
// Define a cor para cada tipo de caractere no mapa.
public static class CoresDoMapa
{
    public static ConsoleColor ObterCorDoCaractere(char c)
    {
        return c switch
        {
            '[' or ']' or '}' or '_' => ConsoleColor.Gray,
            'P' => ConsoleColor.Yellow,
            'C' => ConsoleColor.Cyan,
            '*' => ConsoleColor.Red,
            ')' or '(' => ConsoleColor.Green,
            '♣' => ConsoleColor.Green,
            '≈' => ConsoleColor.Blue,
            'X' => ConsoleColor.Magenta,
            'П' => ConsoleColor.Gray,
            '|' => ConsoleColor.DarkGray,
            _ => ConsoleColor.DarkGray
        };
    }
}
