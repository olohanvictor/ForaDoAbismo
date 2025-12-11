using System;

namespace Combate
{
    public class Combate
    {
        private static readonly Random _random = new Random();

        public void Atacar(global::Personagem.Personagem jogador, global::Personagem.Personagem inimigo, global::Personagem.Personagem.Ataque ataque)
        {
            if (VerificarAtaque(jogador, inimigo, ataque))
            {
                if (TesteAtributo(jogador.Forca, inimigo.Agilidade))
                {
                    inimigo.Vida = LevarDano(inimigo.Vida, inimigo.VidaMax, ataque.Dano);
                    jogador.Recurso -= ataque.CustoRecurso;
                    Console.WriteLine("Ataque realizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("O ataque errou no teste de atributo.");
                    jogador.Recurso -= ataque.CustoRecurso;
                }
            }
            else
            {
                Console.WriteLine("Não foi possível atacar (Sem recurso ou fora de alcance).");
            }
        }

        public bool VerificarAtaque(global::Personagem.Personagem atacante, global::Personagem.Personagem defensor, global::Personagem.Personagem.Ataque ataque)
        {
            if (atacante.Recurso < ataque.CustoRecurso)
                return false;

            string distanciaAlvo = CalcularAlcance(atacante.X, atacante.Y, defensor.X, defensor.Y);

            if (ataque.Alcance == "longo") return true;
            if (ataque.Alcance == "medio" && (distanciaAlvo == "medio" || distanciaAlvo == "curto")) return true;
            if (ataque.Alcance == "curto" && distanciaAlvo == "curto") return true;

            return false;
        }

        public static string CalcularAlcance(int px, int py, int ex, int ey)
        {
            int distX = Math.Abs(px - ex);
            int distY = Math.Abs(py - ey);
            int distancia = distX + distY;

            if (distancia <= 2) return "curto";
            if (distancia <= 5) return "medio";
            return "longo";
        }

        static int LevarDano(int vidaAtual, int vidaMax, int danoTomado)
        {
            int novaVida = vidaAtual - danoTomado;

            if (novaVida < 0)
                novaVida = 0;

            if (novaVida > vidaMax)
                novaVida = vidaMax;

            return novaVida;
        }

        public static int Rolar(int numerofaces)
        {
            return _random.Next(1, numerofaces + 1);
        }

        public static bool TesteAtributo(int atribAtacante, int atribDefensor)
        {
            int d20_1 = Rolar(20);
            int d20_2 = Rolar(20);

            int resultadoAtacante = d20_1 + atribAtacante;
            int resultadoDefensor = d20_2 + atribDefensor;

            return resultadoAtacante >= resultadoDefensor;
        }
    }
}