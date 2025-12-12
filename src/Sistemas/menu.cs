using System;

abstract class Sistemas
{
    private static int resultado;

    public static void Inicio()
    {
        Console.Clear();
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
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
??????????????????????????????????????????????????????????
?                                                        ?
?              ?? FORA DO ABISMO ??                      ?
?                                                        ?
??????????????????????????????????????????????????????????
?  1 - Iniciar Jogo                                      ?
?  2 - Informações                                       ?
?  3 - Créditos                                          ?
?  0 - Sair                                              ?
??????????????????????????????????????????????????????????");

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\nEscolha uma opção: ");
        Console.ResetColor();

        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                Program.IniciarJogo();
                break;
            case "2":
                ExibirInformacoes();
                break;
            case "3":
                ExibirCreditos();
                break;
            case "0":
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n??????????????????????????????????????????????????????????");
                Console.WriteLine("?     Obrigado por jogar FORA DO ABISMO!                 ?");
                Console.WriteLine("?              Até a próxima aventura...                ?");
                Console.WriteLine("??????????????????????????????????????????????????????????\n");
                Console.ResetColor();
                Environment.Exit(0);
                break;
            default:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n? Opção inválida, tente novamente.\n");
                Console.ResetColor();
                Menu();
                break;
        }
    }

    private static void ExibirInformacoes()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("??????????????????????????????????????????????????????????????????????????????????????");
        Console.WriteLine("?                          ?? INFORMAÇÕES DO JOGO ??                                  ?");
        Console.WriteLine("??????????????????????????????????????????????????????????????????????????????????????\n");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"Nas profundezas insondáveis do Subterrâneo, você desperta como prisioneiro dos drows 
— acorrentado, desarmado e à mercê da sacerdotisa Ilvara Mizzrym. O posto avançado de 
Velkynvelve é apenas o início de uma jornada perigosa que atravessa cavernas colossais, 
lagos intermináveis e a loucura crescente que ameaça corromper todo o reino subterrâneo.

Entre criaturas hostis, demônios errantes e facções desesperadas pelo controle, você 
descobrirá que escapar é apenas a primeira etapa. O verdadeiro objetivo é simples e brutal: 
encontrar um caminho de volta à superfície. Retornar à luz, à liberdade, ao mundo que 
ficou para trás.

Mas cada túnel, cada cidade subterrânea e cada sombra viva parece conspirar para impedir 
essa fuga. Nada no Subterrâneo permite que um prisioneiro simplesmente vá embora. Rumores 
de algo maior e terrível rondam as profundezas, distorcendo mentes e despertando forças 
além da compreensão mortal.

A cada passo, fica claro que a escuridão não quer apenas mantê-lo cativo — ela quer quebrá-lo. 
Esta é uma aventura de sobrevivência, escolhas difíceis e alianças improváveis em um 
cenário onde a escuridão é viva — e está sempre observando.

Escapar do Subterrâneo será um feito possível… mas jamais fácil.
");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nPressione ENTER para voltar ao menu...");
        Console.ReadKey(true);
        Console.Clear();
        Menu();
    }

    private static void ExibirCreditos()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(@"
??????????????????????????????????????????????????????????????????????????????????????
?                                                                                    ?
?                          ?? CRÉDITOS DO PROJETO ??                                ?
?                                                                                    ?
??????????????????????????????????????????????????????????????????????????????????????
");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("                    GERENTE DO PROJETO:");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("                    Isabelly Sampaio Antunes\n");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("                    COMUNICAÇÃO POR:");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"                    Julia de Almeida dos Santos
                    Khemeronn Sophia Freitas Faziolato
                    Maria Victoria Espindola de Abreu Figueira Rocha
                    Ruan Gonçalves Gustavo
");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("                    COMBATE POR:");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"                    Ana Carolyna de Marins da Mota
                    Caio Cabral Araujo
                    Davi Fernandes de Oliveira Moreira
                    Lohan Victor do Nascimento Silva
                    Lucas Joe Felix dos Santos Abreu
                    Paulo Vitor Silva Ferreira
                    Rafael Almeida Diniz Filho
                    Ryan Moraes Vieira
                    Sofia de Sousa Sampaio
");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("                    IMPLEMENTAÇÃO POR:");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"                    Guilherme Sodre Souza
                    Joao Victor Lima Honorio
                    Joao Vitor Almeida Correa
");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("                    MAPA POR:");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"                    Andre Luiz Dutra Sales Filho
                    Arthur Porto Coutinho
                    Bruno Tavares dos Santos
                    Carolline de Silva Pimentel
                    Caua Henrique do Amaral Souza
                    Giovanna Oliveira dos Santos
                    Matheus Santos Domingues
                    Raissa Diniz Falleiro
                    Vitor Hugo Mendes Pacheco
");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("                    SISTEMAS POR:");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"                    Arthur Santos Costa Viellas
                    Lara Porto Muniz
                    Manuella Thomaz Lino
                    Raphaella Vasquez Elias e Silva
                    Joao Pedro da Silva Guimaraes
");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("                    PERSONAGENS POR:");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"                    Ana Clara Lanes Moura
                    Arnaldo Oliveira Meirelles
                    Isadora Figueira Faya
                    Leticia dos Santos Silva Bastos
                    Livia Barbosa Parente
                    Maria Eduarda Elizeu Soares
                    Miguel Ferreira Ribeiro Nunes
                    Vitoria Coutinho Reis
");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n???????????????????????????????????????????????????????????????????????????????????????");
        Console.WriteLine("Pressione ENTER para voltar ao menu...");
        Console.ReadKey(true);
        Console.Clear();
        Menu();
    }

    public static void GameOver()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(@"
 ______     ______     __    __     ______        ______     __   __   ______     ______    
/\  ___\   /\  __ \   /\ -._/  \   /\  ___\      /\  __ \   /\ \ / /  /\  ___\   /\  == \   
\ \ \__ \  \ \  __ \  \ \ \-./\ \  \ \  __\      \ \ \/\ \  \ \ \'/   \ \  __\   \ \  __<   
 \ \_____\  \ \_\ \_\  \ \_\ \ \_\  \ \_____\     \ \_____\  \ \__|    \ \_____\  \ \_\ \_\ 
  \/_____/   \/_/\/_/   \/_/  \/_/   \/_____/      \/_____/   \/_/      \/_____/   \/_/ /_/ 
");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
??????????????????????????????????????????????????????????
?                                                        ?
?           O JOGO CHEGOU AO FIM                         ?
?                                                        ?
??????????????????????????????????????????????????????????
");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("                    1 - MENU PRINCIPAL");
        Console.WriteLine("                    2 - SAIR");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\nDigite a opção desejada: ");
        Console.ResetColor();

        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                Menu();
                break;
            case "2":
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n??????????????????????????????????????????????????????????");
                Console.WriteLine("?     Obrigado por jogar FORA DO ABISMO!                 ?");
                Console.WriteLine("?              Até a próxima aventura...                ?");
                Console.WriteLine("??????????????????????????????????????????????????????????\n");
                Console.ResetColor();
                Environment.Exit(0);
                break;
            default:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n? Opção inválida, tente novamente.\n");
                Console.ResetColor();
                GameOver();
                break;
        }
    }

    public static int Rolar()
    {
        Random rng = new Random();
        resultado = rng.Next(1, 21);
        return resultado;
    }
}
