class Combate{
    public bool VerificarAtaque(Ataque ataque) {
        
        if (ataque.distancia <= distanciaAtual && ataque.Recurso > recursoAtual) {
            return true;
        }
        
        return false;
    }
}
