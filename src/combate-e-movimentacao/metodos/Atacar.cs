class Combate{
    void Atacar(PERSONAGEM Jogador, PERSONAGEM Inimigo, ATAQUE Ataque)
    {
        // 1. Chama a função VerificarAtaque
        if (VerificarAtaque(Jogador, Inimigo, Ataque) == true)
        {
            // 2. Se verdadeiro, chama LevarDano com Vida do Inimigo e Dano do Ataque
            LevarDano(Inimigo.Vida, Ataque.Dano);
    
            // 3. Subtrai o Custo do Recurso do Jogador
            Jogador.Recurso = Jogador.Recurso - Ataque.CustoRecurso;
        }
    }
}
