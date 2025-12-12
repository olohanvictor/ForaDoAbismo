using System;
using Combate;

public class ControleDeTurno
{
    private IEstado estadoAtual;
    private global::Combate.Combate combate;
    private global::Personagem.Personagem jogador;
    private global::Personagem.Personagem inimigo;

    public ControleDeTurno(global::Personagem.Personagem playerPersonagem, global::Personagem.Personagem enemyPersonagem)
    {
        jogador = playerPersonagem;
        inimigo = enemyPersonagem;
        estadoAtual = new EstadoPreparacao();
        combate = new global::Combate.Combate();
    }

    public void Iniciar()
    {
        while (true)
        {
            var resultado = estadoAtual.ExecutarAcao();

            estadoAtual = resultado switch
            {
                ResultadoTurno.Continuar => ProximoEstado(),
                ResultadoTurno.Vitoria   => new EstadoVitoria(),
                ResultadoTurno.Derrota   => new EstadoDerrota(),
                _ => estadoAtual
            };

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
            EstadoPreparacao => new EstadoCombate(combate, jogador, inimigo),
            EstadoCombate => estadoAtual,
            _ => estadoAtual
        };
    }

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
        private global::Personagem.Personagem jogador;
        private global::Personagem.Personagem inimigo;
        private int turno = 0;
        private const int CUSTO_APROXIMAR = 2;

        public EstadoCombate(global::Combate.Combate combateInstance, global::Personagem.Personagem player, global::Personagem.Personagem enemy)
        {
            combate = combateInstance;
            jogador = player;
            inimigo = enemy;
        }

        public ResultadoTurno ExecutarAcao()
        {
            turno++;
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine($"TURNO {turno}");
            Console.WriteLine(new string('=', 50));
            
            ExibirStatus();

            // Turno do Jogador
            Console.WriteLine($"\n[{jogador.Nome}] escolha sua ação:");
            ResultadoTurno resultadoJogador = ExecutarTurnoJogador();

            if (resultadoJogador != ResultadoTurno.Continuar)
                return resultadoJogador;

            System.Threading.Thread.Sleep(1000);

            // Turno do Inimigo
            Console.WriteLine($"\n[{inimigo.Nome}] está atacando...");
            ResultadoTurno resultadoInimigo = ExecutarTurnoInimigo();

            if (resultadoInimigo != ResultadoTurno.Continuar)
                return resultadoInimigo;

            System.Threading.Thread.Sleep(1000);
            return ResultadoTurno.Continuar;
        }

        private void ExibirStatus()
        {
            string distancia = global::Combate.Combate.CalcularAlcance(jogador.X, jogador.Y, inimigo.X, inimigo.Y);
            int distanciaNum = Math.Abs(jogador.X - inimigo.X) + Math.Abs(jogador.Y - inimigo.Y);

            Console.WriteLine($"\n{jogador.Nome} ({jogador.GetType().Name})");
            Console.WriteLine($"  HP: {jogador.Vida}/{jogador.VidaMax}");
            Console.WriteLine($"  Recurso: {jogador.Recurso}");
            Console.WriteLine($"  Posição: ({jogador.X}, {jogador.Y})");

            Console.WriteLine($"\n{inimigo.Nome} ({inimigo.GetType().Name})");
            Console.WriteLine($"  HP: {inimigo.Vida}/{inimigo.VidaMax}");
            Console.WriteLine($"  Recurso: {inimigo.Recurso}");
            Console.WriteLine($"  Posição: ({inimigo.X}, {inimigo.Y})");

            Console.WriteLine($"\n📏 Distância: {distanciaNum} unidades ({distancia})");
        }

        private ResultadoTurno ExecutarTurnoJogador()
        {
            Console.WriteLine($"\n1 - {jogador.Ataque1.Nome} ({jogador.Ataque1.Dano} dano, custa {jogador.Ataque1.CustoRecurso} recurso, alcance: {jogador.Ataque1.Alcance})");
            Console.WriteLine($"2 - {jogador.Ataque2.Nome} ({jogador.Ataque2.Dano} dano, custa {jogador.Ataque2.CustoRecurso} recurso, alcance: {jogador.Ataque2.Alcance})");
            Console.WriteLine($"3 - Aproximar (custa {CUSTO_APROXIMAR} recurso)");
            Console.WriteLine("4 - Defender");
            Console.WriteLine("5 - Fugir");

            string escolha = Console.ReadLine();
            
            global::Personagem.Personagem.Ataque ataqueEscolhido = null;

            switch (escolha)
            {
                case "1":
                    ataqueEscolhido = jogador.Ataque1;
                    break;
                case "2":
                    ataqueEscolhido = jogador.Ataque2;
                    break;
                case "3":
                    return ExecutarAproximar();
                case "4":
                    Console.WriteLine($"{jogador.Nome} se coloca em posição defensiva!");
                    return ResultadoTurno.Continuar;
                case "5":
                    Console.WriteLine($"{jogador.Nome} fugiu da batalha!");
                    return ResultadoTurno.Derrota;
                default:
                    Console.WriteLine("Ação inválida! Tente novamente.");
                    return ExecutarTurnoJogador();
            }

            if (ataqueEscolhido != null)
            {
                // Verifica alcance
                string distancia = global::Combate.Combate.CalcularAlcance(jogador.X, jogador.Y, inimigo.X, inimigo.Y);
                if (!VerificarAlcance(ataqueEscolhido.Alcance, distancia))
                {
                    Console.WriteLine($"❌ Inimigo está longe demais! O ataque '{ataqueEscolhido.Nome}' tem alcance '{ataqueEscolhido.Alcance}' mas o inimigo está em '{distancia}'");
                    Console.WriteLine("Escolha se aproximar ou use outro ataque!");
                    return ExecutarTurnoJogador();
                }

                // Permite ataque mesmo com recurso baixo (faz dano mínimo  1 de dano)
                combate.Atacar(jogador, inimigo, ataqueEscolhido);

                if (inimigo.Vida <= 0)
                {
                    Console.WriteLine($"\n🎉 {inimigo.Nome} foi derrotado!");
                    return ResultadoTurno.Vitoria;
                }
            }

            return ResultadoTurno.Continuar;
        }

        private ResultadoTurno ExecutarAproximar()
        {
            if (jogador.Recurso < CUSTO_APROXIMAR)
            {
                Console.WriteLine($"❌ Recurso insuficiente! Você tem {jogador.Recurso} e precisa de {CUSTO_APROXIMAR}");
                return ExecutarTurnoJogador();
            }

            string distanciaAtual = global::Combate.Combate.CalcularAlcance(jogador.X, jogador.Y, inimigo.X, inimigo.Y);
            int distanciaNum = Math.Abs(jogador.X - inimigo.X) + Math.Abs(jogador.Y - inimigo.Y);

            // Determina quanto deve se mover baseado na distância atual
            int passos = distanciaAtual switch
            {
                "longo" => 3,    // De longo: move 3 unidades
                "medio" => 2,    // De médio: move 2 unidades
                "curto" => 1,    // De curto: move 1 unidade 
                _ => 1
            };

            int distX = Math.Abs(jogador.X - inimigo.X);
            int distY = Math.Abs(jogador.Y - inimigo.Y);

       
            int movimentosRestantes = passos;
            while (movimentosRestantes > 0 && (distX > 0 || distY > 0))
            {
                if (distX > distY)
                {
                    jogador.X += jogador.X < inimigo.X ? 1 : -1;
                    distX = Math.Abs(jogador.X - inimigo.X);
                }
                else if (distY > 0)
                {
                    jogador.Y += jogador.Y < inimigo.Y ? 1 : -1;
                    distY = Math.Abs(jogador.Y - inimigo.Y);
                }
                movimentosRestantes--;
            }

            jogador.Recurso -= CUSTO_APROXIMAR;

            int novaDistancia = Math.Abs(jogador.X - inimigo.X) + Math.Abs(jogador.Y - inimigo.Y);
            string novaDistanciaStr = global::Combate.Combate.CalcularAlcance(jogador.X, jogador.X, inimigo.X, inimigo.Y);
            
            Console.WriteLine($"✓ {jogador.Nome} se aproximou com {passos} passos! ({distanciaAtual} → {novaDistanciaStr})");
            Console.WriteLine($"  Posição: ({jogador.X}, {jogador.Y}) | Distância: {novaDistancia} unidades");

            return ResultadoTurno.Continuar;
        }

        private bool VerificarAlcance(string alcanceAtaque, string distanciaAtual)
        {
            return alcanceAtaque switch
            {
                "longo" => true,
                "medio" => distanciaAtual == "medio" || distanciaAtual == "curto",
                "curto" => distanciaAtual == "curto",
                _ => false
            };
        }

        private ResultadoTurno ExecutarTurnoInimigo()
        {
            string distancia = global::Combate.Combate.CalcularAlcance(inimigo.X, inimigo.Y, jogador.X, jogador.Y);
            int distanciaNum = Math.Abs(inimigo.X - jogador.X) + Math.Abs(inimigo.Y - jogador.Y);

            // IA: tentar usar melhor ataque disponível do inimigo 
            global::Personagem.Personagem.Ataque ataqueEscolhido = null;

            // Verifica se pode usar Ataque1
            if (inimigo.Recurso >= inimigo.Ataque1.CustoRecurso && VerificarAlcance(inimigo.Ataque1.Alcance, distancia))
                ataqueEscolhido = inimigo.Ataque1;
            // Senão tenta Ataque2
            else if (inimigo.Recurso >= inimigo.Ataque2.CustoRecurso && VerificarAlcance(inimigo.Ataque2.Alcance, distancia))
                ataqueEscolhido = inimigo.Ataque2;
            // Se nenhum ataque funciona, tenta andar pra frente
            else if (inimigo.Recurso >= CUSTO_APROXIMAR && distanciaNum > 0)
            {
                // Determina quanto deve se mover baseado na distância atual
                int passos = distancia switch
                {
                    "longo" => 3,    // De longo: move 3 unidades
                    "medio" => 2,    // De médio: move 2 unidades
                    "curto" => 1,    // De curto: move 1 unidade
                    _ => 1
                };

                int distX = Math.Abs(inimigo.X - jogador.X);
                int distY = Math.Abs(inimigo.Y - jogador.Y);

                // Aproxima em direção ao jogador 
                int movimentosRestantes = passos;
                while (movimentosRestantes > 0 && (distX > 0 || distY > 0))
                {
                    if (distX > distY)
                    {
                        inimigo.X += inimigo.X < jogador.X ? 1 : -1;
                        distX = Math.Abs(inimigo.X - jogador.X);
                    }
                    else if (distY > 0)
                    {
                        inimigo.Y += inimigo.Y < jogador.Y ? 1 : -1;
                        distY = Math.Abs(inimigo.Y - jogador.Y);
                    }
                    movimentosRestantes--;
                }

                inimigo.Recurso -= CUSTO_APROXIMAR;

                string novaDistancia = global::Combate.Combate.CalcularAlcance(inimigo.X, inimigo.Y, jogador.X, jogador.Y);
                int novaDistanciaNum = Math.Abs(inimigo.X - jogador.X) + Math.Abs(inimigo.Y - jogador.Y);
                Console.WriteLine($"🔄 {inimigo.Nome} se aproxima com {passos} passos! ({distancia} → {novaDistancia})");
                Console.WriteLine($"  Posição: ({inimigo.X}, {inimigo.Y}) | Distância: {novaDistanciaNum} unidades");
                return ResultadoTurno.Continuar;
            }

            if (ataqueEscolhido != null)
            {
                combate.Atacar(inimigo, jogador, ataqueEscolhido);

                if (jogador.Vida <= 0)
                {
                    Console.WriteLine($"\n💀 {jogador.Nome} foi derrotado!");
                    return ResultadoTurno.Derrota;
                }
            }
            else
            {
                Console.WriteLine($"{inimigo.Nome} não consegue atacar e fica imóvel...");
            }

            return ResultadoTurno.Continuar;
        }
    }
    
    public class EstadoVitoria : IEstado
    {
        public ResultadoTurno ExecutarAcao()
        {
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("=== VITÓRIA ===");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("🏆 Você derrotou o inimigo!");
            return ResultadoTurno.Vitoria;
        }
    }

    public class EstadoDerrota : IEstado
    {
        public ResultadoTurno ExecutarAcao()
        {
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("=== DERROTA ===");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("😢 Você foi derrotado!");
            return ResultadoTurno.Derrota;
        }
    }
}