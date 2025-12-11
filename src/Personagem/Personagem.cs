using System;
namespace Personagem;
public abstract class Personagem
{
    // Propriedades Públicas (para que a classe Combate possa acessar)
    public int Fortitude { get; set; } = 0;
    public int Agilidade { get; set; } = 0;
    public int Sabedoria { get; set; } = 0;
    public int Forca { get; set; } = 0;

    public int Vida { get; set; }      // Renomeado de hp para Vida (padrão C#)
    public int VidaMax { get; set; }   // Adicionado para controle de cura/dano
    public int ClasseArmadura { get; set; }
    public int Recurso { get; set; }   // Adicionado para usar nos ataques

    // Os ataques
    public Ataque Ataque1 { get; set; }
    public Ataque Ataque2 { get; set; }

    // Para história
    public string Artigo { get; protected set; }
    public string GeneroEscolha { get; protected set; }
    public string Pronome { get; protected set; }
    public string Possessivo { get; protected set; }
    public string Nome { get; set; }

    // Posição no Mapa (necessário para o Combate funcionar)
    public int X { get; set; }
    public int Y { get; set; }

    // Classe aninhada Ataque
    public class Ataque
    {
        public int Dano;
        public int PA; // Pontos de Ação?
        public string Nome;
        public int CustoRecurso;
        public string Alcance; // "curto", "medio", "longo"
    }

    // --- MÉTODOS ---

    public string DefinirNome()
    {
        string temp;
        do
        {
            Console.WriteLine("\n*** - Olá, bem vindo a esse novo mundo? Como posso te chamar nessa história? \nDigite um nome com até 15 caracteres:");
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
            Console.WriteLine("\nCom qual gênero você se identifica?\n1- Feminino\n2- Masculino");
            GeneroEscolha = Console.ReadLine();
            // Console.Clear(); // Cuidado com Clear, pode apagar contexto anterior

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

   
    public void DistribuirAtributos()
    {
        int PontosDisponiveis = 5; // Reduzi para 5 para ser mais rápido testar

        while (PontosDisponiveis > 0)
        {
            Console.WriteLine($"\nPontos Restantes: {PontosDisponiveis}");
            Console.WriteLine("Escolha um atributo para aumentar (+1):");
            Console.WriteLine($"1 - Força ({Forca})");
            Console.WriteLine($"2 - Agilidade ({Agilidade})");
            Console.WriteLine($"3 - Fortitude ({Fortitude})");
            Console.WriteLine($"4 - Sabedoria ({Sabedoria})");

            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1": Forca++; PontosDisponiveis--; break;
                case "2": Agilidade++; PontosDisponiveis--; break;
                case "3": Fortitude++; PontosDisponiveis--; break;
                case "4": Sabedoria++; PontosDisponiveis--; break;
                default: Console.WriteLine("Escolha inválida! Tente novamente."); break;
            }
        }

        
        RecalcularStatus();
    }

    
    protected virtual void RecalcularStatus()
    {
      
        VidaMax = 10 + Fortitude;
        Vida = VidaMax;
        ClasseArmadura = 10 + Agilidade;
    }


    public Personagem Quiz()
    {
        int pontosGuerreiro = 0;
        int pontosArqueiro = 0;
        int pontosMago = 0;
        //refartorei o quiz pq estava muito grande ent criei uma funçao para fazer as perguntas

        void Perguntar(string pergunta, string op1, string op2, string op3)
        {
            Console.WriteLine($"\nJorlan - {pergunta}");
            Console.WriteLine($"1 - {op1}");
            Console.WriteLine($"2 - {op2}");
            Console.WriteLine($"3 - {op3}");

            string resp;
            do
            {
                Console.Write("Sua escolha: ");
                resp = Console.ReadLine();
                if (resp != "1" && resp != "2" && resp != "3")
                    Console.WriteLine("Opção inválida, tente 1, 2 ou 3.");
            } while (resp != "1" && resp != "2" && resp != "3");

            if (resp == "1") pontosGuerreiro++;
            else if (resp == "2") pontosArqueiro++;
            else if (resp == "3") pontosMago++;
        }

        // --- Perguntas ---
        Perguntar("Qual foi o momento mais marcante da sua história?",
            "Defendi meu pelotão sozinho.",
            "Percebi que não precisava de ninguém.",
            "O instante em que vi magia pela primeira vez.");

        Perguntar("Qual é o seu maior medo?",
            "Falhar com alguém que confia em mim.",
            "Depender de alguém.",
            "Perder o controle e ferir inocentes.");

        Perguntar("O que te faz sentir verdadeiramente feliz?",
            "Ver meus companheiros seguros.",
            "O silêncio perfeito.",
            "Descobrir algo novo.");

        Personagem jogadorDefinitivo;

        if (pontosGuerreiro >= pontosArqueiro && pontosGuerreiro >= pontosMago)
            jogadorDefinitivo = new Guerreiro();
        else if (pontosArqueiro > pontosGuerreiro && pontosArqueiro >= pontosMago)
            jogadorDefinitivo = new Arqueiro();
        else
            jogadorDefinitivo = new Mago();

      
        jogadorDefinitivo.Nome = this.Nome;
        jogadorDefinitivo.Artigo = this.Artigo;
        jogadorDefinitivo.Pronome = this.Pronome;
        jogadorDefinitivo.Possessivo = this.Possessivo;
        jogadorDefinitivo.GeneroEscolha = this.GeneroEscolha;

        return jogadorDefinitivo;
    }

    public void Exibir()
    {
        Console.WriteLine($"\n--- Ficha de Personagem ---");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Classe: {this.GetType().Name}");
        Console.WriteLine($"Gênero: {Pronome}/{Possessivo}");
        Console.WriteLine($"Vida: {Vida}/{VidaMax}");
        Console.WriteLine($"Recurso: {Recurso}");
        Console.WriteLine($"CA (Armadura): {ClasseArmadura}");
        Console.WriteLine($"Atributos -> For: {Forca} | Agi: {Agilidade} | Fort: {Fortitude} | Sab: {Sabedoria}");
        Console.WriteLine($"Ataque 1: {Ataque1.Nome} ({Ataque1.Dano} dano)");
        Console.WriteLine($"Ataque 2: {Ataque2.Nome} ({Ataque2.Dano} dano)");
        Console.WriteLine("---------------------------\n");
    }
}



public class Arqueiro : Personagem
{
    public Arqueiro()
    {
        Fortitude = 8; Agilidade = 16; Sabedoria = 7; Forca = 10;
        Recurso = 20;
        RecalcularStatus(); 

        Ataque1 = new Ataque { Dano = 5, PA = 2, Nome = "Chuva de Flechas", CustoRecurso = 3, Alcance = "medio" };
        Ataque2 = new Ataque { Dano = 3, PA = 1, Nome = "Tiro de Flecha", CustoRecurso = 1, Alcance = "medio" };
    }

    protected override void RecalcularStatus()
    {
        VidaMax = 15 + Fortitude;
        Vida = VidaMax;
        ClasseArmadura = 20 + Agilidade;
    }
}

public class Mago : Personagem
{
    public Mago()
    {
        Fortitude = 10; Agilidade = 8; Sabedoria = 16; Forca = 6;
        Recurso = 30;
        RecalcularStatus();

        Ataque1 = new Ataque { Dano = 8, PA = 2, Nome = "Bola de Fogo", CustoRecurso = 5, Alcance = "curto" };
        Ataque2 = new Ataque { Dano = 3, PA = 1, Nome = "Míssel Mágico", CustoRecurso = 3, Alcance = "medio" };
    }

    protected override void RecalcularStatus()
    {
        VidaMax = 12 + Fortitude;
        Vida = VidaMax;
        ClasseArmadura = 12 + Agilidade;
    }
}

public class Guerreiro : Personagem
{
    public Guerreiro()
    {
        Fortitude = 15; Agilidade = 11; Sabedoria = 9; Forca = 16;
        Recurso = 20;
        RecalcularStatus();

        Ataque1 = new Ataque { Dano = 10, PA = 2, Nome = "Investida Feroz", CustoRecurso = 8, Alcance = "curto" };
        Ataque2 = new Ataque { Dano = 3, PA = 1, Nome = "Corte de Machado", CustoRecurso = 3, Alcance = "curto" };
    }

    protected override void RecalcularStatus()
    {
        VidaMax = 30 + Fortitude;
        Vida = VidaMax;
        ClasseArmadura = 15 + Agilidade;
    }
}