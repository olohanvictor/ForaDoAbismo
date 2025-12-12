using System;

namespace Game
{
    public interface IInimigo
    {
        string Nome { get; }
        int Vida { get; set; }
        int VidaMax { get; }
        int Dano { get; }
        int Defesa { get; }
        string Descricao { get; }
        string Tipo { get; }
        
        void Inicializar();
        int CalcularDano();
        void SofrerDano(int dano);
    }

    public class FabricaDeInimigos
    {
        public static IInimigo CriarInimigo(char tipoMapa)
        {
            return tipoMapa switch
            {
                'C' => new Carcereiro(),
                'X' => new BossDemogorgon(),
                _ => new CarcereiroSimples()
            };
        }

        public static IInimigo CriarInimigoCantinaLevel(int nivel)
        {
            return nivel switch
            {
                1 => new Quaggoth(),
                2 => new QuaggothChefe(),
                3 => new TentaculoMenor(),
                _ => new Quaggoth()
            };
        }
    }

    public class Carcereiro : IInimigo
    {
        public string Nome => "Carcereiro Sombrio";
        public int Vida { get; set; }
        public int VidaMax => 45;
        public int Dano => 6;
        public int Defesa => 12;
        public string Descricao => "Um mago drow com olhos que brilham com magia sombria";
        public string Tipo => "Mago";

        public void Inicializar()
        {
            Vida = VidaMax;
        }

        public int CalcularDano()
        {
            Random rng = new Random();
            return Dano + rng.Next(-2, 3);
        }

        public void SofrerDano(int dano)
        {
            Vida -= dano;
            if (Vida < 0) Vida = 0;
        }
    }

    public class CarcereiroSimples : IInimigo
    {
        public string Nome => "Guarda Drow";
        public int Vida { get; set; }
        public int VidaMax => 30;
        public int Dano => 4;
        public int Defesa => 10;
        public string Descricao => "Um soldado drow comum";
        public string Tipo => "Guerreiro";

        public void Inicializar()
        {
            Vida = VidaMax;
        }

        public int CalcularDano()
        {
            return Dano;
        }

        public void SofrerDano(int dano)
        {
            Vida -= dano;
            if (Vida < 0) Vida = 0;
        }
    }

    public class Quaggoth : IInimigo
    {
        public string Nome => "Quaggoth Selvagem";
        public int Vida { get; set; }
        public int VidaMax => 50;
        public int Dano => 8;
        public int Defesa => 13;
        public string Descricao => "Uma criatura bestial com garras afiadas e instintos selvagens";
        public string Tipo => "Besta";

        public void Inicializar()
        {
            Vida = VidaMax;
        }

        public int CalcularDano()
        {
            Random rng = new Random();
            return Dano + rng.Next(0, 4);
        }

        public void SofrerDano(int dano)
        {
            Vida -= dano;
            if (Vida < 0) Vida = 0;
        }
    }

    public class QuaggothChefe : IInimigo
    {
        public string Nome => "Quaggoth Chefe";
        public int Vida { get; set; }
        public int VidaMax => 70;
        public int Dano => 10;
        public int Defesa => 14;
        public string Descricao => "Um Quaggoth mais antigo e experiente, cicatrizado por inúmeras batalhas";
        public string Tipo => "Besta";

        public void Inicializar()
        {
            Vida = VidaMax;
        }

        public int CalcularDano()
        {
            Random rng = new Random();
            return Dano + rng.Next(-1, 5);
        }

        public void SofrerDano(int dano)
        {
            Vida -= dano;
            if (Vida < 0) Vida = 0;
        }
    }

    public class TentaculoMenor : IInimigo
    {
        public string Nome => "Tentáculo Corrompido";
        public int Vida { get; set; }
        public int VidaMax => 40;
        public int Dano => 7;
        public int Defesa => 11;
        public string Descricao => "Um tentáculo púrpura retorcido, pulsando com energia maligna";
        public string Tipo => "Aberração";

        public void Inicializar()
        {
            Vida = VidaMax;
        }

        public int CalcularDano()
        {
            Random rng = new Random();
            return Dano + rng.Next(-1, 3);
        }

        public void SofrerDano(int dano)
        {
            Vida -= dano;
            if (Vida < 0) Vida = 0;
        }
    }

    public class BossDemogorgon : IInimigo
    {
        public string Nome => "Demogorgon - Príncipe dos Demônios";
        public int Vida { get; set; }
        public int VidaMax => 200;
        public int Dano => 8;
        public int Defesa => 12;
        public string Descricao => @"
???????????????????????????????????????????????????????????
?  O próprio Príncipe dos Demônios materializa-se         ?
?  em forma colossal. Tentáculos púrpura retorcidos,      ?
?  energia maligna irradiando do seu corpo massivo.       ?
?  Seus múltiplos olhos focam em você com ódio absoluto.  ?
?                                                         ?
?  Este é o seu último obstáculo para a liberdade.        ?
???????????????????????????????????????????????????????????";
        public string Tipo => "Lorde Demônico";

        private Random rng = new Random();

        public void Inicializar()
        {
            Vida = VidaMax;
        }

        public int CalcularDano()
        {
            int danoBase = Dano;

            if (Vida < VidaMax * 0.5)
            {
                danoBase += 2;
            }

            return danoBase + rng.Next(-1, 4);
        }

        public void SofrerDano(int dano)
        {
            Vida -= dano;
            if (Vida < 0) Vida = 0;

            if (Vida == VidaMax / 2)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n? Demogorgon RUGE de raiva! Sua fúria cresce!");
                Console.ResetColor();
            }
            else if (Vida <= VidaMax / 4)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n?? O fim está próximo! Demogorgon enfraquece!");
                Console.ResetColor();
            }
        }
    }

    public class ServoEsporo : IInimigo
    {
        public string Nome => "Servo Esporo";
        public int Vida { get; set; }
        public int VidaMax => 25;
        public int Dano => 3;
        public int Defesa => 8;
        public string Descricao => "Um corpo humanoide coberto de fungos pulsantes, ainda respirando lentamente";
        public string Tipo => "Aberração Fúngica";

        public void Inicializar()
        {
            Vida = VidaMax;
        }

        public int CalcularDano()
        {
            return Dano;
        }

        public void SofrerDano(int dano)
        {
            Vida -= dano;
            if (Vida < 0) Vida = 0;
        }
    }

    public class MiconideCorrempido : IInimigo
    {
        public string Nome => "Miconide Corrompido";
        public int Vida { get; set; }
        public int VidaMax => 35;
        public int Dano => 5;
        public int Defesa => 10;
        public string Descricao => "Um elfo fúngico outrora sábio, agora retorcido pela loucura de Demogorgon";
        public string Tipo => "Humanóide Fúngico";

        public void Inicializar()
        {
            Vida = VidaMax;
        }

        public int CalcularDano()
        {
            return Dano;
        }

        public void SofrerDano(int dano)
        {
            Vida -= dano;
            if (Vida < 0) Vida = 0;
        }
    }
}
