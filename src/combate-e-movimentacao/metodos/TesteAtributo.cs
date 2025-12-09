public class Combate{
    public static bool TesteAtributo(int atribAtacante, int atribDefensor)
    {
        int d20_1 = RolarDador(20); // rolagem do atacante
        int d20_2 = RolarDador(20); // rolagem do defensor

        int resultadoAtacante = d20_1 + atribAtacante;
        int resultadoDefensor = d20_2 + atribDefensor;

        return resultadoAtacante >= resultadoDefensor;
    }
}