using System;

public class Program
{
    // Mapa do jogo
    static char[][] mapa = new char[][]
    {
        "[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]".ToCharArray(),
        "[]                                            []          []".ToCharArray(),
        "[] P          []                              [] *        []".ToCharArray(),
        "[]            []                              [][][][]    []".ToCharArray(),
        "[]            []                                          []".ToCharArray(),
        "[]        [][][]                                          []".ToCharArray(),
        "[]                                                        []".ToCharArray(),
        "[]                                                        []".ToCharArray(),
        "[]                                    [][][][][]          []".ToCharArray(),
        "[]    []                              []                  []".ToCharArray(),
        "[]    [][][]                          []                  []".ToCharArray(),
        "[]                                              [][][][]  []".ToCharArray(),
        "[]                                              []        []".ToCharArray(),
        "[]                                              [] *      []".ToCharArray(),
        "[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]".ToCharArray()
    };

    // Posição inicial do Jogador (P)
    static int pY = 2;
    static int pX = 3;

    static void Main(string[] args)
    {
        // Tenta esconder o cursor, mas ignora se der erro (alguns consoles não suportam)
        try { Console.CursorVisible = false; } catch { }
            DesenharMapa();
            
    }

    static void DesenharMapa()
    {
        // Tenta posicionar o cursor no 0,0 para não piscar a tela
        try 
        { 
            Console.SetCursorPosition(0, 0); 
        } 
        catch 
        { 
            // Se der erro (ex: terminal online), usa Clear()
            Console.Clear(); 
        }

        Console.WriteLine("========= Mapa C# =========");
        
        for (int i = 0; i < mapa.Length; i++)
        {
            Console.WriteLine(new string(mapa[i]));
        }
    }
}
