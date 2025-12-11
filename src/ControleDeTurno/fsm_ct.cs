using System;
using Combate;

public class ControleDeTurno
{
    private IEstado estadoAtual;
    private global::Combate.Combate combate;

    public ControleDeTurno()
    {
        estadoAtual = new EstadoPreparacao();
        combate = new global::Combate.Combate();
    }

    public void Iniciar()
    {
        while (true)
        {
            var resultado = estadoAtual.ExecutarAcao();

            // Decide o próximo estado
            estadoAtual = resultado switch
            {
                ResultadoTurno.Continuar => ProximoEstado(),
                ResultadoTurno.Vitoria   => new EstadoVitoria(),
                ResultadoTurno.Derrota   => new EstadoDerrota(),
                _ => estadoAtual
            };

            // Fim do jogo
            if (estadoAtual is EstadoVitoria || estadoAtual is EstadoDerrota)
            {
                estadoAtual.ExecutarAcao();
                break;
            }
        }
    }

    private IEstado ProximoEstado()
    {
        return estadoAtual switch
        {
            EstadoPreparacao => new EstadoCombate(combate),
            EstadoCombate => estadoAtual,
            _ => estadoAtual
        };
    }

    // ------------------------------
    // INTERFACES E ENUMS
    // ------------------------------

    public interface IEstado
    {
        ResultadoTurno ExecutarAcao();
    }

    public enum ResultadoTurno
    {
        Continuar,
        Vitoria,
        Derrota
    }

    // ------------------------------
    // ESTADOS
    // ------------------------------

    public class EstadoPreparacao : IEstado
    {
        public ResultadoTurno ExecutarAcao()
        {
            Console.WriteLine("=== PREPARAÇÃO ===");
            Console.WriteLine("Prepare-se para o combate!");
            System.Threading.Thread.Sleep(1000);
            return ResultadoTurno.Continuar;
        }
    }

    public class EstadoCombate : IEstado
    {
        private global::Combate.Combate combate;
        private int inimigoHP = 10;
        private int jogadorHP = 20;
        private int turno = 0;

        public EstadoCombate(global::Combate.Combate combateInstance)
        {
            combate = combateInstance;
        }

        public ResultadoTurno ExecutarAcao()
        {
            turno++;
            Console.WriteLine("\n=== COMBATE - TURNO " + turno + " ===");
            Console.WriteLine($"HP do Jogador: {jogadorHP}");
            Console.WriteLine($"HP do Inimigo: {inimigoHP}");
            
            // Simulação automática de combate para teste
            int dano = global::Combate.Combate.Rolar(6) + 2;
            Console.WriteLine($"\n[TURNO DO JOGADOR]");
            Console.WriteLine($"Você atacou e causou {dano} de dano!");
            inimigoHP -= dano;

            if (inimigoHP <= 0)
            {
                Console.WriteLine($"Inimigo derrotado!");
                return ResultadoTurno.Vitoria;
            }

            // Ataque do inimigo
            System.Threading.Thread.Sleep(500);
            int danoInimigo = global::Combate.Combate.Rolar(4) + 1;
            Console.WriteLine($"\n[TURNO DO INIMIGO]");
            Console.WriteLine($"O inimigo ataca e causa {danoInimigo} de dano!");
            jogadorHP -= danoInimigo;

            if (jogadorHP <= 0)
            {
                Console.WriteLine($"Você foi derrotado!");
                return ResultadoTurno.Derrota;
            }

            System.Threading.Thread.Sleep(1000);
            return ResultadoTurno.Continuar;
        }
    }
    
    public class EstadoVitoria : IEstado
    {
        public ResultadoTurno ExecutarAcao()
        {
            Console.WriteLine("\n=== VITÓRIA ===");
            Console.WriteLine("Você derrotou o inimigo!");
            return ResultadoTurno.Vitoria;
        }
    }

    public class EstadoDerrota : IEstado
    {
        public ResultadoTurno ExecutarAcao()
        {
            Console.WriteLine("\n=== DERROTA ===");
            Console.WriteLine("Você foi derrotado!");
            return ResultadoTurno.Derrota;
        }
    }
}