using System;
using Combate;

namespace Game
{
    /// <summary>
    /// Gerenciador do Estado do Jogo
    /// Controla a progressão entre: Cela ? Exploração do Mapa ? Combate
    /// </summary>
    public static class GerenciadorDoJogo
    {
        // Estados do jogo
        public enum EstadoJogo
        {
            CelaDosEscravos,
            ExplorandomapasSubterrâneos,
            CombateEmAndamento,
            Vitoria,
            Derrota,
            FimDoJogo
        }

        private static EstadoJogo estadoAtual = EstadoJogo.CelaDosEscravos;

        public static void Iniciar()
        {
            Console.Clear();
            ExibirIntroducao();
            EstadoAtual = EstadoJogo.CelaDosEscravos;

            // Começa na Cela dos Escravos
            CelaDoEscravos.CenaInicial();

            // Após aceitar o plano de Jorlan e revoada acontecer
            EstadoAtual = EstadoJogo.ExplorandomapasSubterrâneos;
            Combate.MovimentarJogador.MovimentaJogador();

            // Após a exploração, o jogo continua
            EstadoAtual = EstadoJogo.FimDoJogo;
        }

        private static void ExibirIntroducao()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
??????????????????????????????????????????????????????????????????????????????
?                                                                            ?
?                         ???  FORA DO ABISMO ???                            ?
?                                                                            ?
?               Uma adaptação de ""Out of the Abyss"" para Console            ?
?                                                                            ?
?  Capturado pelos drows, você desperta em uma cela escura no Subterrâneo.  ?
?  Sua única chance: uma oportunidade de fuga que pode custar sua vida.     ?
?                                                                            ?
?  Prepare-se para encarar:                                                 ?
?  • Sacerdotisas e guerreiros drow                                         ?
?  • Prisioneiros com seus próprios segredos                                ?
?  • Demônios que corrompem o próprio mundo                                 ?
?  • O Príncipe dos Demônios: DEMOGORGON                                    ?
?                                                                            ?
??????????????????????????????????????????????????????????????????????????????
");
            Console.ResetColor();
            Console.WriteLine("\nPressione ENTER para começar sua aventura...");
            Console.ReadKey(true);
        }

        public static EstadoJogo EstadoAtual
        {
            get => estadoAtual;
            set => estadoAtual = value;
        }
    }
}
