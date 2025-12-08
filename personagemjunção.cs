using System;

public abstract class Personagem
{
	protected int fortitude { get; set; } = 0;
	protected int agilidade { get; set; } = 0;
	protected int sabedoria { get; set; } = 0;
	protected int forca { get; set; } = 0;
	protected int hp { get; set; }
	protected int classearmadura { get; set; }
  protected string artigo;
  protected string genero;
  protected string proNome;
  protected string possessivo;
  private string _Nome;

public string Nome {
    
    get { return _Nome; }
    set {
        if (value.Length <= 15) {
            _Nome = value;
        } else {
            Console.WriteLine("O Nome deve ter no máximo 15 caracteres.");
            _Nome = value.Substring(0, 15); 
        }
    }
}

    
public string EscolherNome () {
    Console.WriteLine("\n Por qual Nome devo te chamar nessa história?");
    string NomeTemp = Console.ReadLine();
    NomeTemp = char.ToUpper(NomeTemp[0]) + NomeTemp.Substring(1).ToLower();
    Console.Clear();    
    return NomeTemp;
}


public string Genero () {
    do {
    Console.WriteLine(" Você se identifica com o gênero... \n  1- Feminino \n  2- Masculino");
    
        genero = Console.ReadLine();
        Console.Clear();
        
        if (genero == "1") {
            artigo = "a";
        }
        
        else if (genero == "2") {
            artigo = "o";
        }
        else {
            Console.WriteLine(">>>>Erro!<<<<");
            
        }    } while (genero != "1" && genero != "2");
        
        return artigo; }

public string ProNome () {
            
if (artigo == "a") {
	proNome = "la";
}    
else if (artigo == "o"){
         proNome = "le";
}
return proNome;
}
    
public string Possessivo () {
            
if (artigo == "a") {
	possessivo = "dela";
}    
else if (artigo == "o"){
	possessivo = "dele";
}
return possessivo;
}


public Personagem Quiz() {
    
    int pontosGuerreiro = 0;
    int pontosArqueiro = 0;
    int pontosMago = 0;
    string resp;

        Console.WriteLine("Você vê um monstro à frente. O que faz?");
        Console.WriteLine("1 - Ataco sem pensar!");
        Console.WriteLine("2 - Observo e tento derrotar o monstro.");
        Console.WriteLine("3 - Protejo os outros!");

    do {
        resp = Console.ReadLine();
        Console.Clear();
        if (resp == "1"){
           pontosGuerreiro++; 
        } 
        else if (resp == "2") {
            pontosArqueiro++;
        }
        else if (resp == "3") {
            pontosMago++;
        }
        else Console.WriteLine(" Resposta Inválida!\n Sempre tenha certeza de quem você é.");

    } while (resp != "1" && resp != "2" && resp != "3");

        Console.WriteLine("Alguém que você ama está em perigo, o que você faz? :");
        Console.WriteLine("1 - Coloco-me em risco para protege-la.");
        Console.WriteLine("2 - Usar inteligência.");
        Console.WriteLine("3 - Ajudar e proteger.");
        
    do {
        resp = Console.ReadLine();
        if (resp == "1") {
            pontosGuerreiro++;
        }
        else if (resp == "2") {
            pontosArqueiro++;
        }
        else if (resp == "3") {
            pontosMago++;
        }
        else Console.WriteLine(" Resposta Inválida!\n Sempre tenha certeza de quem você é.");
        Console.Clear();
    } while (resp != "1" && resp != "2" && resp != "3");   

        Console.WriteLine("Você se considera:");
        Console.WriteLine("1 - Impulsivo(a)");
        Console.WriteLine("2 - Analítico(a)");
        Console.WriteLine("3 - Protetor(a)");
        
    do {
        resp = Console.ReadLine();
        if (resp == "1") {
            pontosGuerreiro++;
        }
        else if (resp == "2") {
            pontosArqueiro++;
        }
        else if (resp == "3") {
            pontosMago++;
        }
        else Console.WriteLine(" Resposta Inválida!\n Sempre tenha certeza de quem você é.");
        Console.Clear();
    } while (resp != "1" && resp != "2" && resp != "3");   
    
    
    Console.WriteLine("Você está andando com alguém querido e, de repente, ouve um barulho estranho vindo de um beco escuro. O que você faz? \n1- Entra no beco e investiga \n2- Procura outro caminho \n3- fica na frente da pessoa e a protege");
    do {
        resp = Console.ReadLine();
        if (resp == "1") {
            pontosGuerreiro++;
        }
        else if (resp == "2") {
            pontosArqueiro++;
        }
        else if (resp == "3") {
            pontosMago++;
        }
        else Console.WriteLine(" Resposta Inválida!\n Sempre tenha certeza de quem você é.");
        Console.Clear();
        
    } while (resp != "1" && resp != "2" && resp != "3"); 
        
        Personagem Jogador;

        if (pontosGuerreiro > pontosArqueiro || pontosGuerreiro > pontosMago) {
            Jogador = new Guerreiro();
            Jogador.Nome = Nome;
        }
            
        else if (pontosArqueiro > pontosGuerreiro || pontosArqueiro > pontosMago) {
            Jogador = new Arqueiro(); 
            Jogador.Nome = Nome;
        }
        
        else {
            Jogador = new Mago();
            Jogador.Nome = Nome;
        }
        
        return Jogador;
        
	 public void Exibir()
    {
        Console.WriteLine($"HP: {hp}");
        Console.WriteLine($"Classe de Armadura: {classearmadura}");
        Console.WriteLine($"Sabedoria: {sabedoria}");
        Console.WriteLine($"Força: {forca}");
        Console.WriteLine($"Agilidade: {agilidade}");
        Console.WriteLine($"Fortitude: {fortitude}");
    }
} 

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
}
