class Combate
{
    public bool PodeAtacar; 

    public bool VerificarAtaque(Ataque ataque)
    {
        PodeAtacar = ataque.distancia <= distanciaAtual &&
                      ataque.Recurso <= recursoAtual;

        return PodeAtacar; 
    }
}
