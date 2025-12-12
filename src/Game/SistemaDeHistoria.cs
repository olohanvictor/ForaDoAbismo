using System;
using System.Threading;

namespace Game
{
    /// <summary>
    /// Sistema de Narrativa do jogo FORA DO ABISMO
    /// </summary>
    public static class SistemaDeHistoria
    {
        private static int resultado;

        // 1. INTRODUÇÃO
        public static void Introducao()
        {
            Console.Clear();
            Console.WriteLine(@"
                    Capturado pelos drows, uma espécie de gnomos negros do 
                    submundo! Você não desejaria esse destino  
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
                    pertence a ela. 'Aceite seu destino, aprenda a obedecer, e 
                    você talvez sobreviva.' Suas palavras ecoam na sua memória, 
                    mesmo enquanto você planeja sua fuga.
                    
                    Seu objetivo é conseguir sair desse submundo e retornar ao seu lar");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadKey(true);
            Console.ResetColor();

            // CHAMA A PRÓXIMA CENA
            CelaDosEscravos();
        }

        // 2. CELA DOS ESCRAVOS
        public static void CelaDosEscravos()
        {
            Console.Clear();
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

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadKey(true);
            Console.ResetColor();

            // CHAMA A PRÓXIMA CENA
            PlanoDeJorlan();
        }

        // 3. O PLANO DE JORLAN
        public static void PlanoDeJorlan()
        {
            Console.Clear();
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

            switch (opcao)
            {
                case "1":
                    // O jogador aceita e a história continua
                    RevoadaDeDemônios();
                    break;
                case "2":
                    // O jogador recusa e perde o jogo
                    Console.Clear();
                    Console.WriteLine("Você recusou a única chance de escapar. Permaneceu como escravo até o fim.");
                    Console.WriteLine("\nPressione ENTER para encerrar...");
                    Console.ReadKey(true);
                    Sistemas.GameOver(); // Chama o Game Over
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("opção inválida, tente novamente.");
                    Console.ReadKey();
                    PlanoDeJorlan(); // Recomeça a cena se errar
                    break;
            }
        }

        // 4. REVOADA DE DEMÔNIOS
        public static void RevoadaDeDemônios()
        {
            Console.Clear();
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

            Console.WriteLine(@"
Você segue a sugestão de Jorlan para cair nas teias e depois mergulhar no lago. 
Chegar até o elevador requer passar dos drows amontoados na plataforma e depois 
tentar operá-lo durante o ataque, o que pode provar-se difícil.

Ao perguntar a Jorlan sobre os demônios você recebe uma austera resposta: 
'Os demônios não são obra minha. Lutem com eles por conta própria.'");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadKey(true);
            Console.ResetColor();

            // CHAMA A PRÓXIMA CENA
            LagoEscuro();
        }

        // 5. LAGO ESCURO
        public static void LagoEscuro()
        {
            Console.Clear();
            Console.WriteLine(@"
Após dias caminhando pela lama, o personagem chega ao imenso 
Lago Escuro, uma massa infinita de água negra onde nada parece vivo, 
exceto coisas que definitivamente não deveriam estar vivas. Para 
atravessar o lago, o jogador pode, construir uma jangada improvisada ou
roubar um barco abandonado.

1.Construir Jangada Improvisada   2.Roubar um barco abandonado
     
     
Digite a opção desejada:
");
            // Apenas para efeito narrativo, lemos a opção mas o fluxo segue
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

            if (ultimoNum >= 10)
            {
                Console.WriteLine(@"
Parabens, você conseguiu atravessar o lago sem nenhum problema dessa vez, 
mas se eu fosse você, eu não voltaria para tentar descobrir as monstruosidades 
que esse local esconde");
            }
            else
            {
                Console.WriteLine("\nAs criaturas te perceberam! PREPARE-SE PARA A BATALHA!");
                // Aqui você poderia inserir um sistema de combate real
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadKey(true);
            Console.ResetColor();

            // CHAMA A PRÓXIMA CENA
            Gracklstugh();
        }

        // 6. GRACKLSTUGH
        public static void Gracklstugh()
        {
            Console.Clear();
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
se referem à Gracklstugh como 'a Cidade das Lâminas'. Tão implacável quanto 
poderia ser, a cidade das lâminas é o bastião principal da civilização no 
Subterrâneo com rotas comerciais ativas. Para o personagem, isto significa 
uma chance potencial de encontrar um caminho de volta para o mundo da superfície.

Com patrulhas rotineiras de anões cinzentos bem armados que podem se tornar invisíveis, 
a cidade das lâminas é um lugar relativamente seguro para aqueles que saibam seu lugar e 
tenham-se a isso. Contudo, as tensões estão aumentando por causa da influência de 
Demogorgon,  muitos estão desenvolvendo tiques, hábitos e comportamentos que vão contra 
suas crenças fundamentais, incluindo guardas que exibem seu comportamento corrupto, os 
usos de adornos por vaidade e a deslealdade para seus clãs. Nos últimos tempos, o povo 
de Gracklstugh tem se tornado cada vez mais violento, abandonando sua característica de
astúcia e pragmatismo estoico pela malícia gratuita e pequenas exibições de auto 
superioridade.");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadKey(true);
            Console.ResetColor();

            // CHAMA A PRÓXIMA CENA
            BazarDaLamina();
        }

        // 7. BAZAR DA LÂMINA
        public static void BazarDaLamina()
        {
            Console.Clear();
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
a superfície.");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadKey(true);
            Console.ResetColor();

            // CHAMA A PRÓXIMA CENA
            BosqueNuncaClaro();
        }

        // 8. BOSQUE NUNCA CLARO (FINAL DA HISTÓRIA)
        public static void BosqueNuncaClaro()
        {
            Console.Clear();
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
dos Demônios emerge no mundo físico.");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n*** FIM DO CAPÍTULO DE HISTÓRIA ***");
            Console.WriteLine("Pressione ENTER para iniciar a exploração...");
            Console.ReadKey(true);
            Console.ResetColor();
        }

        public static int Rolar()
        {
            Random rng = new Random();
            resultado = rng.Next(1, 21);
            return resultado;
        }
    }
}