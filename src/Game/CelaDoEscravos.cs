using System;
using System.Collections.Generic;
using System.Threading;

namespace Game
{
    
    public class CelaDoEscravos
    {
        // Dados sobre os personagens NPCs
        private static Dictionary<string, PersonagemNPC> npcs = new();
        private static bool planoDeJorlanAceito = false;
        private static bool revoadadeDemoniosComecou = false;
        private static int turnosAteRevoada = 0;
        private static Random rng = new Random();

        // Personagens na cela
        public class PersonagemNPC
        {
            public string Nome { get; set; }
            public string Tipo { get; set; } // "Prisioneiro" ou "Drow"
            public string Descricao { get; set; }
            public string[] Dialogos { get; set; }
            public string Info { get; set; }
            public bool JaInteragiu { get; set; }
        }

        public static void Inicializar()
        {
            npcs.Clear();

            
            npcs["Ilvara"] = new PersonagemNPC
            {
                Nome = "Ilvara Mizzrym",
                Tipo = "Drow",
                Descricao = "Uma sacerdotisa drow cruenta com trajes de seda fina. Seu olhar é frio como o aço.",
                Dialogos = new[]
                {
                    "Aceite seu destino, aprenda a obedecer, e você talvez sobreviva.",
                    "*a examina com desprezo* Mais um subhumano esperando a morte em Menzoberranzan.",
                    "*aponta o chicote* Qualquer movimento em falso será punido."
                },
                Info = "Sacerdotisa drow que comanda o posto avançado. É extremamente cruel.",
                JaInteragiu = false
            };

            npcs["Shoor"] = new PersonagemNPC
            {
                Nome = "Shoor Vandree",
                Tipo = "Drow",
                Descricao = "Um guerreiro de elite drow com músculos definidos. Ele caminha com arrogância.",
                Dialogos = new[]
                {
                    "*ri com desdém* Escória da superfície não merece respirar nosso ar.",
                    "Gostaria de vê-los tentar lutar. Seriam divertidos de derrotar.",
                    "*examina a varinha pegajosa em seu cinto com satisfação*"
                },
                Info = "Amante atual de Ilvara. Guerreiro de elite e primo de Asha. Carrega uma varinha de globos pegajosos.",
                JaInteragiu = false
            };

            npcs["Jorlan"] = new PersonagemNPC
            {
                Nome = "Jorlan Duskryn",
                Tipo = "Drow",
                Descricao = "Um guerreiro de elite drow mutilado. Cicatrizes profundas desfiguram metade de seu rosto. Seus olhos parecem guardar ressentimento.",
                Dialogos = new[]
                {
                    "*murmura enquanto passa a comida* Se eu puder oferecer meios para que fuja, você agarraria a oportunidade?",
                    "*observa você com curiosidade* Os prisioneiros falam sobre um plano... talvez seja sua vez.",
                    "*sussurra rapidamente* Deixarei o portão destrancado. Uma distração virá em breve."
                },
                Info = "Antigo tenente e amante de Ilvara. Agora desfigurado e rejeitado. Parece estar planejando algo...",
                JaInteragiu = false
            };

            npcs["Asha"] = new PersonagemNPC
            {
                Nome = "Asha Vandree",
                Tipo = "Drow",
                Descricao = "Uma sacerdotisa iniciante drow, jovem e inexperiente. Ela segue Ilvara com admiração.",
                Dialogos = new[]
                {
                    "A Senhora Ilvara é tão poderosa e sábia...",
                    "*parece nervosa* Vocês não deveriam estar aqui fora da cela...",
                    "Cousin Shoor é tão bravo! Diferente de Jorlan..."
                },
                Info = "Sacerdotisa iniciante, prima de Shoor. Inexperiente mas devota a Ilvara.",
                JaInteragiu = false
            };

            // ===== PRISIONEIROS =====
            npcs["Bran"] = new PersonagemNPC
            {
                Nome = "Bran Dunmanson",
                Tipo = "Prisioneiro",
                Descricao = "Um humano robusto com cicatrizes de batalha. Parece ser um guerreiro veterano.",
                Dialogos = new[]
                {
                    "Há dezenove drows aqui. Incluindo a bruxa Ilvara e aquele cicatrizado Jorlan.",
                    "Ouvi dizer que uma patrulha de Menzoberranzan está alguns dias atrasada. É incomum.",
                    "Se alguém conseguir sair daqui... que considere os outros, hein?"
                },
                Info = "Um guerreiro experiente. Conhece bem a estrutura do posto avançado.",
                JaInteragiu = false
            };

            npcs["Sarith"] = new PersonagemNPC
            {
                Nome = "Sarith Kzekarit",
                Tipo = "Prisioneiro",
                Descricao = "Um drow jovem com aparência assustada. Ele não se parece com os drows da superfície.",
                Dialogos = new[]
                {
                    "*sussurra com medo* Um limo cinzento vive no lago. Não o perturbem... é inofensivo, mas...",
                    "Há quaggoths aqui. Aranhas gigantes. Defesas mágicas na cela.",
                    "*parece culpado* Eu era um mercador... antes de tudo isso..."
                },
                Info = "Um drow renegado capturado. Conhece detalhes sobre o lago e as criaturas.",
                JaInteragiu = false
            };

            npcs["Eldeth"] = new PersonagemNPC
            {
                Nome = "Eldeth Feldrun",
                Tipo = "Prisioneiro",
                Descricao = "Uma anã robusta com cabelo grisalho. Seus olhos refletem força mesmo na escravidão.",
                Dialogos = new[]
                {
                    "Há três guardas vigiam a cela da torre suspensa. Podem nos ver através do portão.",
                    "A magia não funciona aqui. Tentei. Proteção drow feita por sacerdotisas.",
                    "Quando chegarem de Menzoberranzan, será o fim para todos nós."
                },
                Info = "Uma anã corajosa. Conhece sobre as defesas mágicas da cela.",
                JaInteragiu = false
            };

            npcs["Jimjar"] = new PersonagemNPC
            {
                Nome = "Jimjar",
                Tipo = "Prisioneiro",
                Descricao = "Um gnomo miúdo com olhos brilhantes. Apesar da situação, ele mantém uma certa leveza.",
                Dialogos = new[]
                {
                    "Se conseguissem a chave de um dos guardas... Mas qual deles se aproximaria?",
                    "Há um arsenal na torre suspensa. Armas. Armaduras. Recursos para a fuga.",
                    "*sussurra com entusiasmo contido* Alguém vai descobrir como sair daqui. Tenho certeza."
                },
                Info = "Um gnomo engenhoso. Sempre buscando soluções criativas.",
                JaInteragiu = false
            };
        }

        /// Cena inicial na Cela dos Escravos
    
        public static void CenaInicial()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"
╔════════════════════════════════════════════════════════════════════════════╗
║                     CELA DOS ESCRAVOS - VELKYNVELVE                        ║
║                                                                            ║
║  Você desperta em uma caverna escura, fria e úmida. O cheiro de mofado    ║
║  e sangue seco preenchem seu olfato. Pesado metal aperta sua garganta     ║
║  e pulsos. Está despido de tudo, apenas com roupas internas farrapadas.  ║
║                                                                            ║
║  Você está em uma cela de ferro parafusado na pedra. Ao seu redor, outros ║
║  prisioneiros – humanos, anões, gnomos – compartilham sua escravidão.     ║
║  O portão é massivo. Impossível forçar. Pelo menos por agora.             ║
╚════════════════════════════════════════════════════════════════════════════╝
");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nVocê ouve passos pesados de drow lá fora...");
            Console.WriteLine("Os prisioneiros sussurram, olhando para você com curiosidade mista a desespero.");
            Console.WriteLine("\nPressione ENTER para despertar completamente...");
            Console.ReadKey(true);

            // Inicializa NPCs
            Inicializar();

            // Mostra primeira visita de Ilvara
            ExibirCenaIlvaraInicial();
        }

        private static void ExibirCenaIlvaraInicial()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"
🔔 O portão da cela estronda ao ser aberto. Você ouve o som metálico ecoando.

Uma figura graciosamente maligna entra na cela. É uma mulher drow de beleza
perturbadora, vestida com trajes de seda negra e púrpura. Em sua mão, um
chicote de couro fino que parece sussurrar ameaças.

Esta é ILVARA MIZZRYM.
");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n[Ilvara fala com uma voz doce, mas letal]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"
    ""Bem-vindo ao posto avançado de Velkynvelve, prisioneiro.
    Vocês agora pertencem à Casa Mizzrym.
    
    Aceitem seu destino, aprendam a obedecer, e talvez... apenas talvez...
    vocês sobrevivam o tempo suficiente para chegar a Menzoberranzan.""
");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n[Ela passa o chicote levemente nos ombros dos prisioneiros enquanto caminha]");
            Console.WriteLine("\nOs outros prisioneiros abaixam os olhos. Ninguém ousa fitar a sacerdotisa.");
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadKey(true);

            MenuInteracaoCela();
        }

     
        /// Menu principal da Cela - Permite interagir com NPCs
     
        public static void MenuInteracaoCela()
        {
            bool naoCela = false;

            while (!naoCela && !revoadadeDemoniosComecou)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"═══════════════════════════════════════════════════");
                Console.WriteLine($"  CELA DOS ESCRAVOS - Menu de Interação");
                Console.WriteLine($"═══════════════════════════════════════════════════");
                Console.ResetColor();

                Console.WriteLine("\n[1] Falar com Jorlan Duskryn (o drow cicatrizado)");
                Console.WriteLine("[2] Falar com outros prisioneiros");
                Console.WriteLine("[3] Observar a cela (receber informações)");
                Console.WriteLine("[4] Tentar dormir (avançar turno)");
                Console.WriteLine("\n[0] Sair da cela (quando Jorlan abrir o portão)");

                Console.Write("\nEscolha: ");
                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        InteragirComJorlan();
                        break;
                    case "2":
                        MenuPrisioneiros();
                        break;
                    case "3":
                        ObservarCela();
                        break;
                    case "4":
                        AvancarTurno();
                        break;
                    case "0":
                        if (planoDeJorlanAceito && revoadadeDemoniosComecou)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("✓ O portão está aberto! Você consegue sair!");
                            Console.ResetColor();
                            naoCela = true;
                            SistemaDeHistoria.RevoadaDeDemônios();
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("✗ O portão está fechado e trancado. Você está preso.");
                            Console.ResetColor();
                            Console.ReadKey(true);
                        }
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida!");
                        Console.ResetColor();
                        Console.ReadKey(true);
                        break;
                }
            }
        }

   
        /// Interação especial com Jorlan
  
        private static void InteragirComJorlan()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@"
═══════════════════════════════════════════════════════════════════════
Você se aproxima cautelosamente de Jorlan. O drow cicatrizado está sentado
sozinho, afastado dos outros prisioneiros. Seus olhos acompanham cada
movimento dos guardas na torre suspensa.

Ele olha para você e aproxima sua voz, sussurrando para que ninguém ouça.

[Jorlan fala baixo, com amargura em cada palavra]
    ""Se eu puder oferecer meios para que fuja...
      você agarraria a oportunidade?""
═══════════════════════════════════════════════════════════════════════
");
            Console.ResetColor();

            Console.WriteLine("\n[1] SIM - Aceitar a ajuda de Jorlan");
            Console.WriteLine("[2] NÃO - Recusar e continuar preso");
            Console.WriteLine("[3] Fazer perguntas antes de decidir");

            Console.Write("\nEscolha: ");
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    AceitarPlanoDeJorlan();
                    break;
                case "2":
                    RecusarPlanoDeJorlan();
                    break;
                case "3":
                    FazerPerguntas();
                    break;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Você não responde. Jorlan desiste e se afasta.");
                    Console.ResetColor();
                    Console.ReadKey(true);
                    break;
            }
        }

        private static void AceitarPlanoDeJorlan()
        {
            planoDeJorlanAceito = true;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
[Jorlan assente lentamente]

    ""Bem. Você tem coragem. Ouço isso na sua respiração.""

Ele sussurra rápida e silenciosamente:

    ""Deixarei o portão destrancado na próxima troca de turnos.
     Criarei uma distração. Será breve. Você terá apenas alguns minutos.
     
     Suba pelas teias abaixo da plataforma. O arsenal está lá acima,
     na câmara acima do posto de guarda. Pegue o que puder.
     
     Depois, caia para o lago. Mergulhe fundo. Os demônios vêm vindo
     do norte, então o caminho sul está aberto.""

    ""Oh... e uma coisa. Não pergunte a mim sobre o limo cinzento.
     Os demônios não são obra minha. Se encontrar com aquilo... 
     Lutem com isso por conta própria.""

[Jorlan se afasta e assume sua posição como guarda]

Você agora tem um plano de fuga. Mas precisa esperar pela oportunidade.
");
            Console.ResetColor();
            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadKey(true);
        }

        private static void RecusarPlanoDeJorlan()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
[Você recusa a oferta]

Jorlan observa você com um misto de desprezo e resignação.

    ""Como quiser. Mas quando chegarem os carregadores de Menzoberranzan,
     estarás marcado para uma vida de escravidão.
     
     Esta era sua única chance. Desperdicei meu tempo.""

Ele se afasta, seus passos ecoando na cela fria.

Você permanecerá prisioneiro. O destino de escravo em Menzoberranzan
o aguarda.

GAME OVER - Você ficou preso.
");
            Console.ResetColor();
            Console.ReadKey(true);
            Sistemas.GameOver();
        }

        private static void FazerPerguntas()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
[Você sussurra suas dúvidas]

[Jorlan responde, ainda cautelsoso]

    Q: ""Por que você ajuda?""
    R: ""Porque Shoor humilhou Ilvara roubando minha varinha. Essa
        humilhação será deliciosa. Se você conseguir ou não... nem me
        importa. O que importa é que eles estarão em pânico.""

    Q: ""Qual é o plano exatamente?""
    R: ""Deixo o portão aberto na troca de turnos. Distração. Você sobe.
        Arsenal. Teias. Lago. Simples. Tudo que você precisa saber.""

    Q: ""E se o portão não abrir?""
    R: ""Não abrirá. Então você morrerá aqui. Escolha simples.""

Ele se afasta. Parece que está esperando sua resposta final.

ACEITAR O PLANO? Digite [ACEITAR]
");
            Console.ResetColor();

            Console.Write("\n> ");
            string resposta = Console.ReadLine().ToUpper();

            if (resposta == "ACEITAR")
            {
                AceitarPlanoDeJorlan();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Você não diz nada. Jorlan desiste e se afasta.");
                Console.ReadKey(true);
            }
        }

        /// Menu para falar com outros prisioneiros
   
        private static void MenuPrisioneiros()
        {
            bool voltarMenu = false;

            while (!voltarMenu)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"═══════════════════════════════════════════════════");
                Console.WriteLine($"  PRISIONEIROS");
                Console.WriteLine($"═══════════════════════════════════════════════════");
                Console.ResetColor();

                Console.WriteLine("\n[1] Bran Dunmanson (Guerreiro humano)");
                Console.WriteLine("[2] Sarith Kzekarit (Drow renegado)");
                Console.WriteLine("[3] Eldeth Feldrun (Anã)");
                Console.WriteLine("[4] Jimjar (Gnomo)");
                Console.WriteLine("\n[0] Voltar");

                Console.Write("\nEscolha: ");
                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        InteragirComPrisioneiro("Bran");
                        break;
                    case "2":
                        InteragirComPrisioneiro("Sarith");
                        break;
                    case "3":
                        InteragirComPrisioneiro("Eldeth");
                        break;
                    case "4":
                        InteragirComPrisioneiro("Jimjar");
                        break;
                    case "0":
                        voltarMenu = true;
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida!");
                        Console.ResetColor();
                        Console.ReadKey(true);
                        break;
                }
            }
        }

        private static void InteragirComPrisioneiro(string nomePrisioneiro)
        {
            if (!npcs.ContainsKey(nomePrisioneiro))
                return;

            var npc = npcs[nomePrisioneiro];

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine($"║ {npc.Nome.PadRight(58)} ║");
            Console.WriteLine($"╚════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine($"\n{npc.Descricao}");
            Console.WriteLine($"\n[Info] {npc.Info}");

            if (!npc.JaInteragiu)
            {
                Console.WriteLine($"\n[Diálogo] {npc.Dialogos[rng.Next(npc.Dialogos.Length)]}");
                npc.JaInteragiu = true;
            }
            else
            {
                Console.WriteLine($"\n[Diálogo] {npc.Dialogos[rng.Next(npc.Dialogos.Length)]}");
            }

            Console.WriteLine("\nPressione ENTER para voltar...");
            Console.ReadKey(true);
        }

        private static void ObservarCela()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(@"
═══════════════════════════════════════════════════════════════════════════
                        OBSERVAÇÕES DA CELA

Ao examinar cautelosamente o ambiente, você descobre:

• A cela é fechada por um pesado portão de ferro parafusado na pedra
  CD 20 para arrombar. CD 20 para forçar.

• Há três guardas drow na torre suspensa através do portão trancado.
  Eles estão sempre vigilantes.

• Magia não funciona aqui. Há uma proteção drow poderosa.
  Qualquer tentativa de magia gasta o espaço mágico em vão.

• Você descobre aproximadamente 19 drows no posto:
  - Ilvara Mizzrym (Sacerdotisa - Líder)
  - Shoor Vandree (Guerreiro - Amante de Ilvara)
  - Jorlan Duskryn (Guerreiro - Desfigurado e amargado)
  - Asha Vandree (Sacerdotisa Iniciante)
  - 15 drows comuns

• Há também quaggoths e aranhas gigantes no posto avançado.

• Uma patrulha de Menzoberranzan é esperada em dias ou semanas.
  Atualmente, está alguns dias atrasada.

• No arsenal acima da torre suspensa há armas e armaduras.

• O lago abaixo contém um limo cinzento inofensivo que se alimenta de lixo.
  Não perturbá-lo é recomendado.
═══════════════════════════════════════════════════════════════════════════
");
            Console.ResetColor();
            Console.WriteLine("\nPressione ENTER para voltar...");
            Console.ReadKey(true);
        }

        private static void AvancarTurno()
        {
            if (planoDeJorlanAceito)
            {
                turnosAteRevoada++;

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"Turno {turnosAteRevoada}: Você tenta descansar na fria cela de pedra.");
                Console.WriteLine("O tempo passa lentamente. Os prisioneiros sussurram em voz baixa.");
                Console.ResetColor();

                // Revoada de demônios acontece no turno 3
                if (turnosAteRevoada >= 3)
                {
                    revoadadeDemoniosComecou = true;
                    Console.WriteLine("\n⚠️ De repente, um som horrível ecoa pela caverna!");
                    Console.WriteLine("Um zumbido inumano... gritos... O alarme dos drows!");
                    Console.WriteLine("\n🔔 A Revoada de Demônios começou!");
                    Console.WriteLine("\nPressione ENTER...");
                    Console.ReadKey(true);
                    return;
                }

                Console.WriteLine($"\nTempo até a oportunidade de fuga: {3 - turnosAteRevoada} turnos");
                Console.WriteLine("\nPressione ENTER para continuar...");
                Console.ReadKey(true);
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Você não tem um plano. Apenas espera pelo seu destino.");
                Console.ResetColor();
                Console.ReadKey(true);
            }
        }
    }
}
