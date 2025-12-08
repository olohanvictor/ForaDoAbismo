/*
João Honório - 08:53
Guilherme - 10:17
*/
using System;
using System.Collections.Generic; // Necessário para criar Listas de inimigos
using System.Threading;

namespace ProjetoRPG
{
    // --- CLASSES BASE (O DNA dos personagens) ---
    
    // Classe "Pai" para qualquer ser vivo no jogo
    public class Unit 
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int AttackPower { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public bool IsDead => HP <= 0; // Propriedade atalho para checar morte

        public Unit(string name, int maxHp, int atk, int startX, int startY)  //
        {
            Name = name;
            MaxHP = maxHp;
            HP = maxHp;
            AttackPower = atk;
            X = startX;
            Y = startY;
        }
    }

    public class Player : Unit 
    {
        public Player(int x, int y) : base("Herói", 50, 8, x, y) { } // Instancia Herói com 50 HP e 8 ATK

        public void Move(int newX, int newY)
        {
            X = newX;
            Y = newY;
        }

        public void Heal()
        {
            int amount = 15;
            HP += amount;
            if (HP > MaxHP) HP = MaxHP;
            Console.WriteLine($"{Name} recuperou {amount} de vida!");
        }
    }

    public class Enemy : Unit
    {
        public Enemy(string name, int hp, int atk, int x, int y) : base(name, hp, atk, x, y) { }
    }

    // --- O MOTOR DO JOGO ---
    public class GameBoard
    {
        private int size;
        private char[,] mapMatrix;
        
        public Player player;
        public List<Enemy> enemies; // Lista dinâmica de inimigos

        public int TurnCount { get; private set; }

        public GameBoard(int boardSize)
        {
            size = boardSize;
            TurnCount = 1;
            enemies = new List<Enemy>();
            mapMatrix = new char[size, size];
            
            player = new Player(0, 0); // Cria o jogador

            InitializeMap();
        }

        /*Aqui podemos criar o mapa conforme queremos.*/
        private void InitializeMap()
        {
            // Preenche chão
            for (int y = 0; y < size; y++)
                for (int x = 0; x < size; x++)
                    mapMatrix[x, y] = '.';

            // Obstáculos
            mapMatrix[3, 3] = '#';
            mapMatrix[3, 4] = '#';
            mapMatrix[7, 2] = '#';

            // Adiciona Inimigos (Nome, HP, Atk, X, Y)
            enemies.Add(new Enemy("Goblin", 20, 4, 2, 2));
            enemies.Add(new Enemy("Orc", 40, 7, 6, 6));
            enemies.Add(new Enemy("Boss", 100, 12, 9, 9));
        }

        // Retorna o inimigo que está na posição X, Y (ou null se não tiver ninguém)
        private Enemy GetEnemyAt(int x, int y)
        {
            return enemies.Find(e => e.X == x && e.Y == y);
        }

        public void ProcessInput(string direction)
        {
            int nextX = player.X;
            int nextY = player.Y;

            switch (direction)
            {
                case "w": nextY--; break;
                case "s": nextY++; break;
                case "a": nextX--; break;
                case "d": nextX++; break;
                default: return; 
            }

            // 1. Checa Bordas e Paredes
            if (nextX < 0 || nextX >= size || nextY < 0 || nextY >= size) return;
            if (mapMatrix[nextX, nextY] == '#') 
            {
                Console.WriteLine("Parede!");
                Thread.Sleep(500);
                return;
            }

            // 2. Checa se tem Inimigo (COMBATE)
            Enemy target = GetEnemyAt(nextX, nextY);
            if (target != null)
            {
                StartCombat(target);
                // Se o inimigo morreu, removemos da lista e avançamos
                if (target.IsDead)
                {
                    enemies.Remove(target);
                    // Opcional: O jogador ocupa o lugar do inimigo morto?
                    // player.Move(nextX, nextY); 
                }
            }
            else
            {
                // 3. Movimento Livre
                player.Move(nextX, nextY);
                TurnCount++; // Só gasta turno de exploração se andar
            }
        }

        // --- SISTEMA DE COMBATE (RPG TURN-BASED) ---
        /*Eis o combate, por algum motivo. Ninguém mandou fazer,*/
        private void StartCombat(Enemy enemy)
        {
            bool inCombat = true;

            Console.Clear();
            Console.WriteLine($"!!! ENCONTROU UM {enemy.Name} !!!");
            Thread.Sleep(1000);

            while (inCombat)
            {
                // -- UI DE COMBATE --
                Console.Clear();
                Console.WriteLine("================ COMBATE ================");
                Console.WriteLine($"{player.Name} (HP: {player.HP}/{player.MaxHP})  VS  {enemy.Name} (HP: {enemy.HP}/{enemy.MaxHP})");
                Console.WriteLine("=========================================");
                Console.WriteLine("1. Atacar");
                Console.WriteLine("2. Curar");
                Console.WriteLine("=========================================");
                Console.Write("Escolha sua ação: ");

                string choice = Console.ReadLine();

                // -- TURNO DO JOGADOR --
                if (choice == "1") // Ataque
                {
                    int dmg = player.AttackPower; // Aqui você pode adicionar aleatoriedade depois
                    enemy.HP -= dmg;
                    Console.WriteLine($"\nVocê atacou o {enemy.Name} causando {dmg} de dano!");
                }
                else if (choice == "2") // Cura
                {
                    player.Heal();
                }
                else
                {
                    Console.WriteLine("\nAção inválida! Perdeu o turno.");
                }

                Thread.Sleep(1000);

                // -- VERIFICA MORTE DO INIMIGO --
                if (enemy.IsDead)
                {
                    Console.WriteLine($"\n>>> O {enemy.Name} foi derrotado! <<<");
                    Thread.Sleep(1500);
                    inCombat = false;
                    break;
                }

                // -- TURNO DO INIMIGO --
                Console.WriteLine($"\nO {enemy.Name} está atacando...");
                Thread.Sleep(800);
                int enemyDmg = enemy.AttackPower;
                player.HP -= enemyDmg;
                Console.WriteLine($"Você sofreu {enemyDmg} de dano!");
                
                Thread.Sleep(1500);

                // -- VERIFICA MORTE DO JOGADOR --
                if (player.IsDead)
                {
                    Console.Clear();
                    Console.WriteLine("GAMER OVER... Você morreu.");
                    Environment.Exit(0); // Fecha o jogo
                }
            }
        }

        public void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine($"Turno: {TurnCount} | HP Jogador: {player.HP}/{player.MaxHP}");
            Console.WriteLine("---------------------");

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    // Verifica se tem inimigo nesta posição
                    Enemy e = GetEnemyAt(x, y);

                    if (x == player.X && y == player.Y)
                        Console.Write("[P]");
                    else if (e != null)
                        Console.Write("[E]"); // E de Enemy
                    else if (mapMatrix[x, y] == '#')
                        Console.Write("[#]");
                    else
                        Console.Write("[ ]");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n[P]layer | [E]nemy | [#]bstacle");
            Console.WriteLine("W/A/S/D para mover. Encoste no inimigo para lutar.");
        }
    }

    /*Eis o homem*/
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard game = new GameBoard(10); // Instancia o jogo

            while (!game.player.IsDead) // Loop de Gameplay
            {
                game.DrawBoard();

                var key = Console.ReadKey(true).Key;
                string input = "";

                //Movimentação do personagem
                if (key == ConsoleKey.W || key == ConsoleKey.UpArrow) input = "w";
                if (key == ConsoleKey.S || key == ConsoleKey.DownArrow) input = "s";
                if (key == ConsoleKey.A || key == ConsoleKey.LeftArrow) input = "a";
                if (key == ConsoleKey.D || key == ConsoleKey.RightArrow) input = "d";

                if (input != "")
                {
                    game.ProcessInput(input);
                }
            }
        }
    }
}
