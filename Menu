using System;

abstract class Sistemas 
{
    
    public static void Inicio()
    {
    Console.WriteLine(@"
            ______                           _   _ _           _       
            | ___ \                         | | | (_)         | |      
            | |_/ / ___ _ __ ___    ______  | | | |_ _ __   __| | ___  
            | ___ \/ _ \ '_ ` _ \  |______| | | | | | '_ \ / _` |/ _ \ 
            | |_/ /  __/ | | | | |          \ \_/ / | | | | (_| | (_) |
            \____/ \___|_| |_| |_|           \___/|_|_| |_|\__,_|\___/ 

                       _____              
                      |  ___|              
              __ _    | |_ ___  _ __ __ _  
             / _` |   |  _/ _ \| '__/ _` | 
            | (_| |   | || (_) | | | (_| | 
             \__,_|   \_| \___/|_|  \__,_| 
                        ______         ___  _     _                     _ 
                        |  _  \       / _ \| |   (_)                   | |
                        | | | |___   / /_\ \ |__  _ ___ _ __ ___   ___ | |
                        | | | / _ \  |  _  | '_ \| / __| '_ ` _ \ / _ \| |
                        | |/ / (_) | | | | | |_) | \__ \ | | | | | (_) |_|
                        |___/ \___/  \_| |_/_.__/|_|___/_| |_| |_|\___/(_)
                         
    
                            Pressione ENTER para continuar        ");
    Console.ReadKey();
    }
    
    public static void Menu()
    {
        Console.Clear();
        Console.WriteLine(@"
========================================
|                                      | 
|          FORA DO ABISMO              | 
|                                      | 
|======================================|
|1 - Iniciar Jogo                      | 
|2 - Informacoes                       | 
|3 - Creditos                          | 
|0 - Sair                              | 
========================================
Escolha uma opcao: ");

        string opcao = Console.ReadLine();//lê a escolha do player

        switch(opcao) 
        {
            case "1":
                Console.WriteLine("..."); //CT e MAIN vão implementar. chamar cenas, por mapas
                break;
            case "2":
                Console.WriteLine("Nas profundezas insondáveis do Subterrâneo, você desperta como prisioneiro dos drows — acorrentado, desarmado e à mercê da sacerdotisa Ilvara Mizzrym. O posto avançado de Velkynvelve é apenas o início de uma jornada perigosa que atravessa cavernas colossais, lagos intermináveis e a loucura crescente que ameaça corromper todo o reino subterrâneo. Entre criaturas hostis, demônios errantes e facções desesperadas pelo controle, você descobrirá que escapar é apenas a primeira etapa. O verdadeiro objetivo é simples e brutal: encontrar um caminho de volta à superfície. Retornar à luz, à liberdade, ao mundo que ficou para trás Mas cada túnel, cada cidade subterrânea e cada sombra viva parece conspirar para impedir essa fuga. Nada no Subterrâneo permite que um prisioneiro simplesmente vá embora. Rumores de algo maior e terrível rondam as profundezas, distorcendo mentes e despertando forças além da compreensão mortal. A cada passo, fica claro que a escuridão não quer apenas mantê-lo cativo — ela quer quebrá-lo. Esta é uma aventura de sobrevivência, escolhas difíceis e alianças improváveis em um cenário onde a escuridão é viva — e está sempre observando. Escapar do Subterrâneo será um feito possível… mas jamais fácil."); 
                Console.WriteLine(@"Pressione ENTER para continuar        ");
                Console.ReadKey();
                Console.Clear();
                Sistemas.Menu(); //loop pro metódo Menu
                break;
            case "3":
                Console.WriteLine(@"
        ========================================
                       CREDITOS
        ========================================

                GERENTE DO PROJETO:
                Isabelly Sampaio Antunes

                COMUNICAÇÃO POR:
                Julia de Almeida dos Santos
                Khemeronn Sophia Freitas Faziolato
                Maria Victoria Espindola de Abreu Figueira Rocha
                Ruan Gonçalves Gustavo

                COMBATE POR:
                Ana Carolyna de Marins da Mota
                Caio Cabral Araujo
                Davi Fernandes de Oliveira Moreira
                Lohan Victor do Nascimento Silva
                Lucas Joe Felix dos Santos Abreu
                Paulo Vitor Silva Ferreira
                Rafael Almeida Diniz Filho
                Ryan Moraes Vieira
                Sofia de Sousa Sampaio

                IMPLEMENTAÇAO POR:
                Guilherme Sodre Souza
                Joao Victor Lima Honorio
                Joao Vitor Almeida Correa

                MAPA POR:
                Andre Luiz Dutra Sales Filho
                Arthur Porto Coutinho
                Bruno Tavares dos Santos
                Carolline de Silva Pimentel
                Caua Henrique do Amaral Souza
                Giovanna Oliveira dos Santos
                Matheus Santos Domingues
                Raissa Diniz Falleiro
                Vitor Hugo Mendes Pacheco

                SISTEMAS POR:
                Arthur Santos Costa Viellas
                Lara Porto Muniz
                Manuella Thomaz Lino
                Raphaella Vasquez Elias e Silva
                Joao Pedro da Silva Guimaraes

                PERSONAGENS POR:
                Ana Clara Lanes Moura
                Arnaldo Oliveira Meirelles
                Isadora Figueira Faya
                Leticia dos Santos Silva Bastos
                Livia Barbosa Parente
                Maria Eduarda Elizeu Soares
                Miguel Ferreira Ribeiro Nunes
                Vitoria Coutinho Reis
                "); 
                Console.WriteLine(@"Pressione ENTER para continuar        ");
                Console.ReadKey();//lê o enter
                Console.Clear();
                Sistemas.Menu(); //loop pro metódo Menu
                break;
            case "0":
                Console.WriteLine("Até a próxima, obrigado por estar aqui!"); 
                break;
            default:
                Console.Clear();
                Console.WriteLine("opção inválida, tente novamente.");
                Sistemas.Menu(); //loop pro metódo Menu
                break;

        }      
    }
    
    public static void GameOver()
    {
        Console.WriteLine(@"
 ______     ______     __    __     ______        ______     __   __   ______     ______    
/\  ___\   /\  __ \   /\ -._/  \   /\  ___\      /\  __ \   /\ \ / /  /\  ___\   /\  == \   
\ \ \__ \  \ \  __ \  \ \ \-./\ \  \ \  __\      \ \ \/\ \  \ \ \'/   \ \  __\   \ \  __<   
 \ \_____\  \ \_\ \_\  \ \_\ \ \_\  \ \_____\     \ \_____\  \ \__|    \ \_____\  \ \_\ \_\ 
  \/_____/   \/_/\/_/   \/_/  \/_/   \/_____/      \/_____/   \/_/      \/_____/   \/_/ /_/ 
              
                    
                    1.MENU                          2.SAIR 

                    
digite a opção desejada:
        ");
        string opcao = Console.ReadLine();
        
        switch(opcao)
        {
            case "1":
                Menu();
                break;
            case "2":
                Console.WriteLine("Obrigado por jogar!");
                break;
            default:
                Console.Clear();
                Console.WriteLine("opção inválida, tente novamente.");
                GameOver(); //loop pro metódo GameOver, KKKKKKK isso é genial
                break;
        }
    }
    
    public static void Introducao()
    {
                    Console.WriteLine(@"
                    Capturado pelos drows! Você não   desejaria esse destino  
                    para ninguém, ainda assim, aqui está você – trancado em 
                    uma caverna escura, com a sensação do frio e pesado metal 
                    apertado ao redor de sua garganta e punhos. Você não está 
                    sozinho. Outros prisioneiros estão encarcerados aqui com 
                    você, em um posto avançado subterrâneo longe da luz do sol.
                     Entre seus captores, inclui-se uma cruel sacerdotisa drow 
                    que se autoproclama Senhora Ilvara da Casa Mizzrym. No 
                    decorrer dos últimos dias, você a encontrou várias vezes, 
                    vestindo trajes de seda e flanqueada por dois drows machos, 
                    um dos quais tem uma massa de cicatrizes em um dos lados 
                    de sua face e pescoço.
                     A Senhora Ilvara gosta de incutir sua vontade com um 
                    chicote em punho, e lembrar a você que sua vida agora 
                    pertence a ela. “Aceite seu destino, aprenda a obedecer, e 
                    você talvez sobreviva.” Suas palavras ecoam na sua memória, 
                    mesmo enquanto você planeja sua fuga.");
    }
    
    public static void CelaDosEscravos()
    {
        Console.WriteLine(@"
A cela dos escravos, onde você está, é fechada com um pesado portão de ferro parafusado na pedra.
Os prisioneiros recebem um penico de barro e uma das tarefas dos escravos é esvaziá-los no lago durante o turno de vigia.
Não há outro conforto na cela. Os prisioneiros sentam ou deitam no chão de pedra e comem 1 vez por dia (caldo ralo de cogumelo).
A cela foi construída para conter os cativos até que sejam mandados para Menzoberranzan para serem vendidos como escravos.
O portão para a cela de escravos é mantido trancado.

Conversando com seus colegas de cela você descobre as seguintes informações:

Jorlan, o drow guerreiro, recentemente sofreu ferimentos que o desfiguraram. Antes disso, ele parecia estar mais nas graças de Ilvara. 
Agora Shoor parece ter tomado seu lugar.

Um limo cinzento vive no lago. Ele é inofensivo, se alimentando do lixo a menos que seja perturbado.

Uma patrulha de suprimento vinda de Menzoberranzan está alguns dias atrasada, o que é incomum.

");
    }

    public static void PlanoDeJorlan()
    {
        Console.WriteLine(@"
        
        
Jorlan Duskryn traz a comida dos prisioneiros e murmura:
'Se eu puder oferecer meios para que fuja, você agarraria a oportunidade?'
Caso aceite, ele promete deixar a cela destrancada e criar uma distração durante a troca de turno dos guardas.
Ele te conta sobre o arsenal na torre suspensa e sugere pular nas teias abaixo para alcançar o lago.
O objetivo dele é apenas embaraçar Shoor e Ilvara, não ajudar de fato na fuga completa.

            1.Aceitar a ajuda                     2.Recusar
            
            
Digite a opção desejada:
        ");
        
        string opcao = Console.ReadLine();
        
        switch(opcao)
        {
            case "1":
                RevoadaDeDemônios();
                break;
            case "2":
                Console.Clear();
                GameOver();
                break;
            default:
                Console.Clear();
                Console.WriteLine("opção inválida, tente novamente.");
                PlanoDeJorlan();
                break;
        }
        
    }

    public static void RevoadaDeDemônios()
    {
        Console.WriteLine(@"
Durante a troca de guarda, os prisioneiros escutam um zumbido horrível ecoando 
pela caverna, seguido por gritos inumanos. O alarme ecoa alto enquanto 4 
demônios perseguem um par de drows caverna adentro pela passagem norte. 
Os demônios voam e zumbem nos arredores, inicialmente ignorando as outras 
criaturas conforme ambos os grupos se atacam selvagemente. A chegada dos 
demônios pega os drows despreparados. Os drows correm para defender o posto 
avançado de um possível ataque. Os demônios inicialmente voam pelas torres 
suspensas, deixando passarelas e cavernas fora do alcance de seus zumbidos e gritos. 
Contudo, os drows nas torres estão próximos o suficiente para serem afetados. 
A batalha aérea eventualmente circula ao redor da plataforma e das torres dos 
guerreiros de elite, conforme os demônios rasgam uns aos outros. 
Os drows se movem para engajarem-se no combate com os demônios e defenderem seu posto, 
deixando os personagens com uma oportunidade para escapar. 
O personagem pode utilizar a distração para engendrar sua própria fuga e então, 
descer para o piso da caverna e para onde ir depois disso.
        ");
        
//possibilidade de luta de acordo com script
        
        Console.WriteLine(@"
Você segue a sugestão de Jorlan para cair nas teias e depois mergulhar no lago. 
Chegar até o elevador requer passar dos drows amontoados na plataforma e depois 
tentar operá-lo durante o ataque, o que pode provar-se difícil.

Ao perguntar a Jorlan sobre os demônios você recebe uma austera resposta: 
“Os demônios não são obra minha. Lutem com eles por conta própria.”

        ");
    }

    public static void LagoEscuro()//falta coisa
    {
        Console.WriteLine(@"
Após dias caminhando, o personagem chega ao imenso Lago Escuro.
Água negra infinita, criaturas deformadas e luzes estranhas.
Pode construir uma jangada ou roubar um barco abandonado.
Encontros aleatórios: role 1D20 (1-10 nada acontece, 11-20 encontro com 6 kuo-toas em um barco).
");
    }

    public static void Gracklstugh()//falta coisa
    {
        Console.WriteLine(@"
Gracklstugh, a Cidade das Lâminas.
Fundições flamejantes, forjas alimentadas por Themberchaud, o dragão ferreiro.
Distrito do Lago Escuro é o ponto de entrada.
Covil de Ghohlbrorn é a hospedaria para forasteiros.
Tensões crescentes pela influência de Demogorgon.
");
    }

    public static void BazarDaLamina()//falta coisa
    {
        Console.WriteLine(@"
Mercado barulhento, mercadores duergars vendem armas e armaduras.
Comportamentos estranhos: insultos, preços variáveis, desaparecimentos súbitos, ameaças como técnica de pechincha.
Alguns mercadores falam com irmãos gêmeos invisíveis.
");
    }

    public static void BosqueNuncaClaro()//falta coisa
    {
        Console.WriteLine(@"
Bosque Nunca Claro: cogumelos gigantes iluminam trilhas.
Corpos cobertos de fungos respiram lentamente, transformados em Servos Esporos.
Colônia de miconides dividida: Phylo vê bênção, Basidia teme corrupção.
Investigação revela influência demoníaca: Demogorgon.
");
    }

    public static void BatalhaFinalDemogorgon()//falta coisa
    {
        Console.WriteLine(@"
Demogorgon emerge do solo em vapor púrpuro e tentáculos retorcidos.
Fase 1: 350 pontos de vida, ataques físicos devastadores, Olhar da Ruína, invocação de Servos Esporos.
Fase 2: ao chegar em 200 pontos de vida, Olhar da Dominação, fendas de energia, ataques ainda mais perigosos.
Ao ser derrotado, é banido de volta ao Abismo.
");
    }
}

class Principal //teste de tudo
{
    static void Main() 
    {
    //Sistemas.GameOver();
    //Sistemas.Inicio();
    //Sistemas.PlanoDeJorlan();
    //Sistemas.BatalhaFinalDemogorgon();
    
    }
}
