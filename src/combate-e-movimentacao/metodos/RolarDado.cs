public static int Rolar(int numerofaces)
{
    Random gira = new Random();
    int resultado = gira.Next(1, numerofaces + 1);
    return resultado;
}
