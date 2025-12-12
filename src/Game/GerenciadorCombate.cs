using System;

namespace Game
{
   
    public class GerenciadorCombate
    {
        private global::Personagem.Personagem jogador;
        private global::Personagem.Personagem inimigo;
        private ControleDeTurno controleDeTurno;

        public GerenciadorCombate(global::Personagem.Personagem player, global::Personagem.Personagem enemy)
        {
            jogador = player;
            inimigo = enemy;
            controleDeTurno = new ControleDeTurno(jogador, inimigo);
        }

      
        /// <returns>true se jogador venceu, false se perdeu</returns>
        public bool IniciarCombate()
        {
            Console.WriteLine("\n??????????????????????????????????????????????????????????");
            Console.WriteLine("?            INICIANDO COMBATE                           ?");
            Console.WriteLine("??????????????????????????????????????????????????????????\n");

            ExibirFichasPersonagens();

            Console.WriteLine("\nPressione ENTER para começar...");
            Console.ReadLine();

            
            controleDeTurno.Iniciar();

            return inimigo.Vida <= 0;
        }

     
        private void ExibirFichasPersonagens()
        {
            Console.WriteLine("=== PERSONAGENS EM COMBATE ===\n");
            jogador.Exibir();
            inimigo.Exibir();
        }

        /// Retorna o personagem jogador
      
        public global::Personagem.Personagem GetJogador() => jogador;

        /// Retorna o personagem inimigo

        public global::Personagem.Personagem GetInimigo() => inimigo;

  
        /// Retorna true se jogador venceu
     
        public bool JogadorVenceu() => inimigo.Vida <= 0;

     
        /// Retorna true se inimigo venceu
    
        public bool InimigoVenceu() => jogador.Vida <= 0;
    }
}
