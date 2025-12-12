using System;
using Game;

namespace Combate
{
    public class MovimentarJogador
    {
        public static void MovimentaJogador()
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo tecla;
            bool movendo = true;

            while (movendo)
            {
                ImprimiMapa.DesenharMapa();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n[W/A/S/D] - Mover | [Q] - Sair");
                Console.WriteLine($"Posição: ({ArmazenadorDeMapa.pX}, {ArmazenadorDeMapa.pY})");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(
                    $"HP: {Program.jogadorAtual.Vida}/{Program.jogadorAtual.VidaMax} | " +
                    $"Recurso: {Program.jogadorAtual.Recurso}/{Program.jogadorAtual.RecursoMax}"
                );
                Console.ResetColor();

                tecla = Console.ReadKey(true);
                int dx = 0, dy = 0;

                switch (tecla.Key)
                {
                    case ConsoleKey.W: dy = -1; break;
                    case ConsoleKey.S: dy = 1; break;
                    case ConsoleKey.A: dx = -1; break;
                    case ConsoleKey.D: dx = 1; break;
                    case ConsoleKey.Q:
                        movendo = false;
                        break;
                }

                if (!movendo) break;

                int novoX = ArmazenadorDeMapa.pX + dx;
                int novoY = ArmazenadorDeMapa.pY + dy;

                char[][] mapaAtual =
                    ArmazenadorDeMapa.todosOsMapas[ArmazenadorDeMapa.mapaAtualIndex];

                if (novoX < 0 || novoX >= mapaAtual[0].Length ||
                    novoY < 0 || novoY >= mapaAtual.Length)
                    continue;

                char posicaoNova = mapaAtual[novoY][novoX];

                if (posicaoNova == '[' || posicaoNova == ']' || posicaoNova == '#')
                {
                    Console.Beep();
                    continue;
                }

                //Armadilha
                if (posicaoNova == '*')
                {
                    AplicarDanoArmadilha();

                    if (Program.jogadorAtual.Vida <= 0)
                    {
                        ExibirGameOver("Você foi morto por uma armadilha!");
                        break;
                    }

                    Console.Clear();
                    continue;
                }

                //Atualiza a posição
                ArmazenadorDeMapa.pX = novoX;
                ArmazenadorDeMapa.pY = novoY;

                //Regenera recurso qnd anda
                RegenerarRecurso(2);

                //Inimigo
                if (posicaoNova == 'C' || posicaoNova == 'X')
                {
                    bool venceu = IniciarCombateComInimigo(posicaoNova);

                    if (!venceu)
                    {
                        ExibirGameOver("Você foi derrotado em combate!");
                        break;
                    }

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Vitória! Inimigo derrotado!");
                    Console.ResetColor();
                    System.Threading.Thread.Sleep(1500);
                    
                    //Remove o inimigo ao ser derrotado 
                    mapaAtual[novoY][novoX] = ' ';
                    
                    //Ataliza a posição do player
                    ArmazenadorDeMapa.pX = novoX;
                    ArmazenadorDeMapa.pY = novoY;
                    
                    Console.Clear();
                }
                //Troca de mapa
                else if (posicaoNova == ')' || posicaoNova == '(')
                {
                    GerenciadorDeNivel.VerificarTrocaDeMapa();
                    ExibirCenaNarrativaParaNivel(ArmazenadorDeMapa.mapaAtualIndex);
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                }
            }

            Console.CursorVisible = true;
        }

        //Regenerando recurso
        private static void RegenerarRecurso(int valor)
        {
            var jogador = Program.jogadorAtual;

            jogador.Recurso += valor;
            if (jogador.Recurso > jogador.RecursoMax)
                jogador.Recurso = jogador.RecursoMax;
        }

        private static void AplicarDanoArmadilha()
        {
            int dano = 10;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nARMADILHA!");
            Console.ResetColor();

            Program.jogadorAtual.Vida -= dano;
            if (Program.jogadorAtual.Vida < 0)
                Program.jogadorAtual.Vida = 0;

            Console.WriteLine($"Dano recebido: {dano}");
            Console.WriteLine(
                $"Vida: {Program.jogadorAtual.Vida}/{Program.jogadorAtual.VidaMax}"
            );

            System.Threading.Thread.Sleep(1500);
        }

        private static bool IniciarCombateComInimigo(char tipo)
        {
            var jogador = Program.jogadorAtual;
            var inimigo = CriarInimigoPeloTipo(tipo);

            var combate = new GerenciadorCombate(jogador, inimigo);
            return combate.IniciarCombate();
        }

        private static global::Personagem.Personagem CriarInimigoPeloTipo(char tipo)
        {
            if (tipo == 'C')
            {
                var inimigo = new global::Personagem.Mago { Nome = "Carcereiro Sombrio" };
                inimigo.Vida = inimigo.VidaMax;
                inimigo.Recurso = inimigo.RecursoMax;
                return inimigo;
            }

            if (tipo == 'X')
            {
                var boss = new global::Personagem.Guerreiro
                {
                    Nome = "Boss - Senhor do Abismo",
                    Forca = 25,
                    Fortitude = 20,
                    Agilidade = 15,
                    Sabedoria = 18
                };

                boss.VidaMax = 30 + boss.Fortitude;
                boss.Vida = boss.VidaMax;
                boss.ClasseArmadura = 15 + boss.Agilidade;
                boss.RecursoMax = 40;
                boss.Recurso = boss.RecursoMax;

                return boss;
            }

            var inimigoPadrao = new global::Personagem.Mago { Nome = "Inimigo Desconhecido" };
            inimigoPadrao.Vida = inimigoPadrao.VidaMax;
            inimigoPadrao.Recurso = inimigoPadrao.RecursoMax;
            return inimigoPadrao;
        }

        private static void ExibirCenaNarrativaParaNivel(int nivel)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            switch (nivel)
            {
                case 0:
                    Console.WriteLine("Você desperta em uma cela fria...");
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(@"
████████████████████████████████████████████████████████████████
    ⚔️  REVOADA DE DEMÔNIOS - APARIÇÃO  ⚔️
████████████████████████████████████████████████████████████████

Durante sua progressão através da caverna, um zumbido horrível ecoa
pelas passagens. Você ouve gritos inumanos e o som de batalha.

Um demônio passa voando rapidamente acima de você, seu corpo coberto
de chagas púrpuras que brilham com energia maligna. Você consegue ver
a silhueta colossal de mais criaturas nas sombras.

A influência de Demogorgon está crescendo...
Os demônios estão vindo para o Subterrâneo.

Você precisa ser cauteloso. Algo grande está acontecendo.");
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(@"
████████████████████████████████████████████████████████████████
    🔥 A REVOADA INTENSIFICA 🔥
████████████████████████████████████████████████████████████████

Os demônios parecem mais numerosos agora. O ar vibra com sua presença.
Você vê marcas de garras nas paredes e corpos mutilados de drows mortos.

As criaturas parecem estar se movendo em direção a um objetivo específico.
A corrupção que você viu em Grackstugh está se espalhando.

Os guardiões da caverna enfrentam uma ameaça muito maior.
E você está bem no meio disso.");
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(@"
████████████████████████████████████████████████████████████████
    ⚡ O PRÍNCIPE DEMÔNICO EMERGE ⚡
████████████████████████████████████████████████████████████████

O chão começa a tremer violentamente. Fungos que brilham subitamente
apagam-se. Uma névoa púrpura densa invade a caverna.

O zumbido é ensurdecedor agora. Não é mais um som distante.

De repente, você sente uma presença maligna que te perturba até a alma.
Demogorgon não está apenas influenciando o mundo através de servos e corrupção.

ELE ESTÁ VINDO.

O destino do Subterrâneo e talvez do mundo inteiro, agora depende
de você conseguir sair deste lugar antes que seja tarde demais.");
                    break;
                default:
                    Console.WriteLine("Uma nova área se revela.");
                    break;
            }

            Console.ResetColor();
            System.Threading.Thread.Sleep(3500);
        }

        private static void ExibirGameOver(string motivo)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nGAME OVER");
            Console.WriteLine(motivo);
            Console.ResetColor();
            System.Threading.Thread.Sleep(2000);
        }
    }
}
