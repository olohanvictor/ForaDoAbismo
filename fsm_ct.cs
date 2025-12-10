using System;

public class ControleDeTurno
{
    private IEstado estadoAtual;

    public ControleDeTurno()
    {
        estadoAtual = new EstadoPreparacao();
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
            EstadoPreparacao => new EstadoCombate(),
            EstadoCombate => estadoAtual, // Continua no combate
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
            return ResultadoTurno.Continuar;
        }
    }

    public class EstadoCombate : IEstado
    {
        // Aqui que vamos usar os metodos de combater  eu fez com  switch case ,mas pode ser if e else
        private int inimigoHP = 10;

        public ResultadoTurno ExecutarAcao()
        {
            Console.WriteLine("\n=== COMBATE ===");
            Console.WriteLine($"HP do Inimigo: {inimigoHP}");
            Console.WriteLine("Ação: 1 - Atacar | 2 - Defender | 3 - Fugir");

            var escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    int dano = 5 // exemplo
                    Console.WriteLine($"Você atacou e causou {dano} de dano!");
                    inimigoHP -= dano;

                    if (inimigoHP <= 0)
                        return ResultadoTurno.Vitoria;

                    break;

                case "2":
                    Console.WriteLine("Você se defende e recebe menos dano!");
                    break;

                case "3":
                    Console.WriteLine("Você fugiu da batalha!");
                    return ResultadoTurno.Derrota;

                default:
                    Console.WriteLine("Comando inválido!");
                    break;
            }

            // Ataque do inimigo
            int danoInimigo = 5 // exemplo
            Console.WriteLine($"O inimigo ataca e causa {danoInimigo} de dano!");

            // No futuro  colocamos  HP do jogador aqui.
           

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
