class Combate{
    static int LevarDano(int vidaAtual, int vidaMax, int danoTomado)
    {
        int novaVida = vidaAtual - danoTomado;
    
        if (novaVida < 0)
            novaVida = 0;
    
        if (novaVida > vidaMax)
            novaVida = vidaMax;
    
        return novaVida;
    }
}