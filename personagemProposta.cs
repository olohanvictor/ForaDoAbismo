using System;

// =======================================================
// 1. CLASSE BASE E MÉTODOS DE SETUP/QUIZ
// =======================================================

public abstract class Personagem
{
    // Atributos protegidos para as estatísticas
    protected int fortitude { get; set; } = 0;
    protected int agilidade { get; set; } = 0;
    protected int sabedoria { get; set; } = 0;
    protected int forca { get; set; } = 0;
    protected int hp { get; set; }
    protected int classearmadura { get; set; }

    // Propriedades para metadados (Alteradas para public/protected set)
    public string Artigo { get; protected set; }
    public string GeneroEscolha { get; protected set; }
    public string Pronome { get; protected set; }
    public string Possessivo { get; protected set; }
    public string Nome { get; protected set; } 

    public string DefinirNome()
    {
        string temp;
        
        do
        {
            Console.WriteLine("*** - Olá, bem vindo a esse novo mundo? Como posso te chamar nessa história? \nDigite um nome com até 15 caracteres:");
            temp = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(temp) || temp.Length > 15);
        
        temp = char.ToUpper(temp[0]) + temp.Substring(1).ToLower();
        Nome = temp; 
        return Nome;
    }
        

    public void DefinirGenero()
    {
        do
        {
            Console.WriteLine("Com qual gênero você se identifica?\n1- Feminino\n2- Masculino");
            GeneroEscolha = Console.ReadLine();
            Console.Clear();

            if (GeneroEscolha == "1" || GeneroEscolha == "2")
            {
                Artigo = GeneroEscolha == "1" ? "a" : "o";
                Pronome = Artigo == "a" ? "la" : "le";
                Possessivo = Artigo == "a" ? "dela" : "dele";
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        } while (GeneroEscolha != "1" && GeneroEscolha != "2");
    }

    public void ContagemQuiz(ref string resp, ref int pontosGuerreiro, ref int pontosArqueiro, ref int pontosMago)
    {
        do
        {
            resp = Console.ReadLine();
            Console.Clear();
        
            switch (resp)
            {
                case "1": pontosGuerreiro++; break;
                case "2": pontosArqueiro++; break;
                case "3": pontosMago++; break;
                default:
                    Console.WriteLine("Resposta inválida!\nSempre tenha certeza de quem você é.");
                    break;
            }

        } while (resp != "1" && resp != "2" && resp != "3");    
    }

    public Personagem Quiz()
    {
        int pontosGuerreiro = 0;
        int pontosArqueiro = 0;
        int pontosMago = 0;
        string resp = "";
        string nomeTemporario = this.Nome; 

        // --- Perguntas do Quiz ---
        Console.WriteLine("Jorlan - Qual foi o momento mais marcante da sua história?");
        Console.WriteLine("1 - Quando defendi meu pelotão sozinho contra aqueles Drows. Ali descobri quem eu era.");
        Console.WriteLine("2 - A primeira vez que percebi que não precisava de ninguém me dizendo o que fazer.");
        Console.WriteLine("3 - O instante em que vi magia pela primeira vez. Foi como compreender um novo idioma do universo.");
        ContagemQuiz(ref resp, ref pontosGuerreiro, ref pontosArqueiro, ref pontosMago);


        Console.WriteLine("Jorlan - Qual foi a melhor fase da sua vida?");
        Console.WriteLine("1 - Agora. Cada desafio me deixa mais forte.");
        Console.WriteLine("2 - Provavelmente agora. Não porque tudo esteja perfeito, mas porque finalmente escolho meu próprio caminho.");
        Console.WriteLine("3 - “A melhor fase foi quando eu podia ler em paz, sem interrupções.");
        ContagemQuiz(ref resp, ref pontosGuerreiro, ref pontosArqueiro, ref pontosMago);

        Console.WriteLine("Jorlan - Quais são os seus valores mais importantes?");
        Console.WriteLine("1 - Honra e lealdade.");
        Console.WriteLine("2 - Liberdade e escolhas bem feitas.");
        Console.WriteLine("3 - Conhecimento e busca honesta pela verdade.");
        ContagemQuiz(ref resp, ref pontosGuerreiro, ref pontosArqueiro, ref pontosMago);
        
        Console.WriteLine("Jorlan - Como você lida com o fracasso?");
        Console.WriteLine("1 - Caio, levanto, continuo meu caminho. Simples.");
        Console.WriteLine("2 - Reviso, ajusto, tento de novo. E faço piada no processo.");
        Console.WriteLine("3 - Analiso, registro e tento novamente com uma abordagem diferente.");
        ContagemQuiz(ref resp, ref pontosGuerreiro, ref pontosArqueiro, ref pontosMago);        
        
        Console.WriteLine("Jorlan - Qual é o seu maior medo?");
        Console.WriteLine("1 - Falhar com alguém que confia em mim.");
        Console.WriteLine("2 - Depender de alguém… e essa pessoa me deixar na mão.");
        Console.WriteLine("3 - Perder o controle e ferir inocentes.");
        ContagemQuiz(ref resp, ref pontosGuerreiro, ref pontosArqueiro, ref pontosMago);
        
        Console.WriteLine("Jorlan - O que te faz sentir verdadeiramente feliz?");
        Console.WriteLine("1 - Ver meus companheiros seguros… e uma boa luta.");
        Console.WriteLine("2 - Aquele silêncio perfeito depois de um disparo certeiro.");
        Console.WriteLine("3 - Descobrir algo novo. Mesmo que seja pequeno.");
        ContagemQuiz(ref resp, ref pontosGuerreiro, ref pontosArqueiro, ref pontosMago);
        
        
        Console.WriteLine("Jorlan - Como você se reconecta consigo mesmo em momentos de crise?");
        Console.WriteLine("1 - Treino até o corpo parar de pensar.");
        Console.WriteLine("2 - Sumo por umas horas. Só eu e o vento.");
        Console.WriteLine("3 - Eu paro tudo, respiro fundo. Isso me acalma.");
        ContagemQuiz(ref resp, ref pontosGuerreiro, ref pontosArqueiro, ref pontosMago);
        
        
        // --- Determinação da Classe ---
        Personagem Jogador;

        if (pontosGuerreiro > pontosArqueiro && pontosGuerreiro > pontosMago) {
            Jogador = new Guerreiro();
        }
        else if (pontosArqueiro > pontosGuerreiro && pontosArqueiro > pontosMago) {
            Jogador = new Arqueiro(); 
        }
        else {
            Jogador = new Mago();
        }

        // Transfere os metadados para o novo objeto Jogador
        Jogador.Nome = nomeTemporario;
        Jogador.Artigo = this.Artigo;
        Jogador.Pronome = this.Pronome;
        Jogador.Possessivo = this.Possessivo;
        
        return Jogador;
    }
    
    public void Exibir()
    {
        Console.WriteLine($"\n--- Ficha de Personagem ---");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Classe: {this.GetType().Name} ({Artigo} {this.GetType().Name})");
        Console.WriteLine($"Pronomes: {Pronome}/{Possessivo}");
        Console.WriteLine($"HP: {hp}");
        Console.WriteLine($"Classe de Armadura: {classearmadura}");
        Console.WriteLine($"Sabedoria: {sabedoria}");
        Console.WriteLine($"Força: {forca}");
        Console.WriteLine($"Agilidade: {agilidade}");
        Console.WriteLine($"Fortitude: {fortitude}");
        Console.WriteLine("---------------------------\n");
    }
}

// =======================================================
// 2. CLASSES CONCRETAS (Classes Filhas)
// =======================================================

public class Arqueiro : Personagem
{
	public Arqueiro()
	{
		fortitude = 8;
		agilidade = 16;
		sabedoria = 7;
		forca = 10;
		hp = 15 + fortitude;
		classearmadura = 20 + agilidade;
	}
}

public class Mago : Personagem
{
    public Mago()
    {
	    fortitude = 10;
	    agilidade = 8;
	    sabedoria = 16;
	    forca = 6;
	    hp = 20 + fortitude;
	    classearmadura = 12 + agilidade;
    }
}

public class Guerreiro : Personagem
{
    public Guerreiro()
    {
	    fortitude = 15;
	    agilidade = 11;
	    sabedoria = 9;
	    forca = 16;
	    hp = 30 + fortitude;
	    classearmadura = 15 + agilidade;
    }
}
