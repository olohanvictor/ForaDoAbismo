using System;

abstract class Sistemas 
{
    private static int resultado;
    
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
    
    public static int Rolar()
    {
        Random rng = new Random();
        resultado = rng.Next(1, 21); // gera número entre 1 e 20
        return resultado;
    }
    
    public static void Introducao()
    {
                    Console.WriteLine(@"
                    Capturado pelos drows, uma espécie de gnomos negros do 
                    submundo! Você não   desejaria esse destino  
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
                    mesmo enquanto você planeja sua fuga.
                    
                    Seu objetivo é conseguir sair desse submundo e retornar ao seu lar");
    }
    
    public static void CelaDosEscravos()
    {
        Console.WriteLine(@"
A cela dos escravos, onde você está, é fechada com um pesado portão 
de ferro parafusado na pedra. Os prisioneiros recebem um penico de 
barro e uma das tarefas dos escravos é esvaziá-los no lago durante o 
turno de vigia. Não há outro conforto na cela. Os prisioneiros sentam 
ou deitam no chão de pedra e comem 1 vez por dia (caldo ralo de cogumelo).
A cela foi construída para conter os cativos até que sejam mandados para 
Menzoberranzan para serem vendidos como escravos. O portão para a cela de 
escravos é mantido trancado.

Conversando com seus colegas de cela você descobre as seguintes informações:

Jorlan Duskryn é guerreiro de elite drow mutilado. Antigo tenente e antigo 
amante de Ilvara, faz seu serviço com mal humor, mas é bem curioso em relação 
aos seus prisioneiros

Jorlan, o drow guerreiro, recentemente sofreu ferimentos que o desfiguraram. 
Antes disso, ele parecia estar mais nas graças de Ilvara. 
Agora Shoor parece ter tomado seu lugar. 

Um limo cinzento vive no lago. Ele é inofensivo, se alimentando do lixo a menos 
que seja perturbado.

Uma patrulha de suprimento vinda de Menzoberranzan está alguns dias atrasada, 
o que é incomum.");
    }

    public static void PlanoDeJorlan()
    {
        Console.WriteLine(@"
Jorlan Duskryn traz a comida dos prisioneiros e murmura:

           'Se eu puder oferecer meios para que fuja, 
                você agarraria a oportunidade?'

Caso aceite, ele promete deixar a cela destrancada e criar uma distração 
durante a troca de turno dos guardas.
Ele te conta sobre o arsenal na torre suspensa e sugere pular nas teias 
abaixo para alcançar o lago. O objetivo dele é apenas embaraçar Shoor e 
Ilvara, não ajudar de fato na fuga completa.

            1.Aceitar a ajuda                     2.Recusar
            
            
Digite a opção desejada:
        ");
        
        string opcao = Console.ReadLine();
        
        switch(opcao)
        {
            case "1":
                //RevoadaDeDemônios();//chama a proxima cena
                break;
            case "2":
                Console.Clear();
                GameOver();//moreu paizão
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
descer para o piso da caverna e para onde ir depois disso.");

//implementar batalha

        Console.WriteLine(@"
Você segue a sugestão de Jorlan para cair nas teias e depois mergulhar no lago. 
Chegar até o elevador requer passar dos drows amontoados na plataforma e depois 
tentar operá-lo durante o ataque, o que pode provar-se difícil.

Ao perguntar a Jorlan sobre os demônios você recebe uma austera resposta: 
“Os demônios não são obra minha. Lutem com eles por conta própria.");
    }

    public static void LagoEscuro()
    {
        Console.WriteLine(@"
Após dias caminhando pela lama, o personagem chega ao imenso 
Lago Escuro, uma massa infinita de água negra onde nada parece vivo, 
exceto coisas que definitivamente não deveriam estar vivas. Para 
atravessar o lago, o jogador pode, construir uma jangada improvisada ou
roubar um barco abandonado.

1.Construir Jangada Improvisada   2.Roubar um barco abandonado
     
     
Digite a opção desejada:
");

        Console.ReadLine();

        Console.WriteLine(@"
O lago esconde criaturas deformadas, zumbidos estranhos e luzes 
que dançam à distância. Em algum momento, o grupo pode encontrar a vila 
dos kuo-toa, Sloobludop, onde a loucura tomou conta do povo-peixe. 
Eventos estranhos ocorrem ali, e o grupo testemunha a influência de 
demonhos que estão corrompendo todo o Subterrâneo.

Este é o momento em que os heróis começam a suspeitar que algo muito 
maior está acontecendo na escuridão com um clima de medo e suspense.

O Heróis suspeitam que tem algo na escuridão, porém, através de um dado, 
você saberá se de fato passará ileso pela escuridão Lago Obscuro e suas 
monstruosidades, ou não.

1.Rolar o dado");

        Console.ReadLine();

        int ultimoNum = Rolar();

        Console.WriteLine($"O resultado foi: {ultimoNum}");
        
        if(ultimoNum >=10) 
        {
            Console.WriteLine(@"
Parabens, você conseguiu atravessar o lago sem nenhum problema dessa vez, 
mas se eu fosse você, eu não voltaria para tentar descobrir as monstruosidades 
que esse local esconde");
        }
        else
        {
            Console.WriteLine("batalhaaaaaa");//implementar batalha
        }
        
    }

    public static void Gracklstugh()
    {
        Console.WriteLine(@"
Após dias navegando dentro do Lago Escuro, passando por diversas criaturas 
que são bem difíceis de mencionar, você finalmente enxerga terra a vista. 
Você consegue enxergar a silhueta de um porto, onde há a grande movimentação 
de diferentes raças do submundo, você está prestes a chegar em Gracklstugh!

Visitantes de Gracklstugh são recepcionados por seu 
ar quente e ácido, seguido pelo brilho vermelho furioso das eternamente 
flamejantes fundições alimentando os trabalhos de metal da cidade, seu 
coração ressoante, e as forjas mantidas vivas pelas chamas de Themberchaud, 
o dragão vermelho que carrega o título de Dragão ferreiro. Gracklstugh 
trabalha incansavelmente, seus ferreiros produzindo as melhores armas e 
armaduras dentre as raças do Subterrâneo. Aqueles que fazem negócios aqui 
se referem à Gracklstugh como “a Cidade das Lâminas”. Tão implacável quanto 
poderia ser, a cidade das lâminas é o bastião principal da civilização no 
Subterrâneo com rotas comerciais ativas. Para o personagem, isto significa 
uma chance potencial de encontrar um caminho de volta para o mundo da superfície.

“Com patrulhas rotineiras de anões cinzentos bem armados que podem se tornar invisíveis, 
a cidade das lâminas é um lugar relativamente seguro para aqueles que saibam seu lugar e 
atenham-se a isso. Contudo, as tensões estão aumentando por causa da influência de 
Demogorgon,  muitos estão desenvolvendo tiques, hábitos e comportamentos que vão contra 
suas crenças fundamentais, incluindo guardas que exibem seu comportamento corrupto, os 
usos de adornos por vaidade e a deslealdade para seus clãs. Nos últimos tempos, o povo 
de Gracklstugh tem se tornado cada vez mais violento, abandonando sua característica de
astúcia e pragmatismo estoico pela malícia gratuita e pequenas exibições de auto 
superioridade.”");
    }
    
    public static void BazarDaLamina()
    {
        Console.WriteLine(@"
O BAZAR DAS LÂMINAS:

Este mercado é nomeado por causa dos bens mais abundantes que os duergars têm a oferecer, 
mas as lojas aqui vendem quase tudo disponível na cidade, juntamente com as barracas montadas 
por mercadores visitantes. O ruído das pessoas discutindo, quase abafa o som das marteladas 
vindo das forjas da cidade.

VOCÊ PERCEBE AS SEGUINTES COISAS:

• Um mercador duergar não para de insultar clientes quando eles estão tentando vender algo, 
mas torna-se um exemplo de polidez quando querem comprar.

• Vários mercadores duergars dão preços diferentes para compra ou venda cada vez que são 
perguntados sobre o mesmo item, e insistem que os personagens lidando com eles são os únicos 
a mudarem os termos da negociação.

• Um mercador duergar subitamente fica invisível no meio da negociação, mas continua 
conversando como se nada tivesse acontecido.

• Um mercador duergar ameaça matar os personagens como uma técnica de pechincha, e 
então nega ter dito isso. 

• Um mercador duergar constantemente pede a opinião de um irmão gêmeo imaginário, 
dizendo que ele está invisível

Após você passar um período dentro da cidade, conversar com duergares e viver 
experiências alegres, fuga e quase morte, você traça um caminho em direção ao 
Bosque Nunca Claro, onde percebe que é a direção para finalmente poder retornar 
a superfície.
");
    }

    public static void BosqueNuncaClaro()
    {
        Console.WriteLine(@"
Os personagens chegam ao Bosque Nunca Claro em busca de abrigo no Subterrâneo. 
Estão cansados e precisam de descanso, de orientação e de qualquer pista que 
possa levá-los de volta à superfície. À primeira vista, o bosque parece tranquilo. 
Cogumelos gigantes iluminam as trilhas com luz própria e o ar é estranhamente 
agradável para um local tão profundo. No entanto, essa tranquilidade começa a 
parecer estranhamente errada.

Ao entrarem no Jardim das Boas Vindas, os aventureiros percebem figuras imóveis 
espalhadas entre os fungos. São prisioneiros anteriores e membros de uma antiga 
patrulha drow. Seus corpos estão cobertos por fungos e micélio, mas ainda 
respiram lentamente. Eles foram transformados em Servos Esporos, vítimas da 
influência de Zuggtmoy, um dos reis demônios. O ambiente inteiro passa de 
acolhedor para perturbador, e a sensação de que algo está profundamente errado.

Logo, os personagens encontram a colônia de miconides, uma espécie de elfos fúngica. 
Dois soberanos se destacam. Phylo parece acreditar que o que está acontecendo é 
uma bênção para sua espécie e demonstra uma estranha alegria. Basidia, em contraste, 
se mostra desconfiado e inquieto. Ele se comunica diretamente com os aventureiros, 
pedindo que investiguem a origem da doença que está se espalhando pelo Jardim das 
Boas Vindas. Diz que algo corrompe as mentes dos miconides e teme que sua colônia 
esteja sendo destruída por dentro.

Vocês iniciam as investigações e, através de observações e testes, descobrem 
que a doença esporângia não é natural. Os fungos estão crescendo rápido demais, 
apresentam comportamento quase animal e emitem uma energia mágica instável vibe 
the last of us. Conforme avançam, percebem que esse fenômeno não tem origem em 
Zuggtmoy, mas em algo muito mais perigoso. A influência que contamina o bosque é
demoníaca e poderosa. Depois de reunir pistas suficientes, chega a conclusão 
inevitável. O responsável é Demogorgon.

A presença do Príncipe dos Demônios não é física no início, mas sua influência 
se espalha pelo solo, pelas árvores, pelos fungos e pela mente das criaturas que
vivem ali. Ele instiga impulsos destrutivos, causa surtos de loucura e manipula 
emoções até que seres pacíficos se tornem violentos. O bosque inteiro é um reflexo 
da corrupção mental causada por ele. Com essa descoberta, os personagens tentam 
abandonar o local antes que a loucura os atinja. 

Os aventureiros deixam o Bosque Nunca Claro levando a certeza de que um único 
lorde demônio é capaz de alterar todo o equilíbrio do Plano Material. Presenciaram 
a ascensão de Demogorgon em Grackstugh, agora entendem que mais de um lorde está 
à solta, e que o mundo enfrenta uma ameaça que nenhum povo está preparado para encarar.

Quando finalmente se afastam do bosque e acreditam estar seguros, o chão começa 
a tremer. Fungos murcham de forma instantânea, a luz bioluminescente se apaga e 
o ar fica pesado. A influência de Demogorgon, antes difusa, se concentra em um 
único ponto. O solo se abre em uma rachadura larga e profunda. De dentro dela, 
envolto em vapor púrpura e tentáculos retorcidos, o corpo colossal do Príncipe 
dos Demônios emerge no mundo físico.
");

        //BATALHA

    }

}

class Principal //teste de tudo
{
    static void Main() 
    {
    Sistemas.BosqueNuncaClaro();
    
    }
}
