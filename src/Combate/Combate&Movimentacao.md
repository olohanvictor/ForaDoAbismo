##Movimentação e Combate

Integrantes: Ana Carolyna, Caio Cabral, Davi Fernandes, Lohan Victor, Lucas Joe, Paulo Vitor, Rafael Diniz, Ryan Moraes e Sofia Sampaio

---

### 1. Rolar (Rolar Dado)

**Descrição:** Função que simula a rolagem de um dado de N lados.
**Assinatura (C#):** `public static int Rolar(int numerofaces)`
**Comportamento:**

* Retorna um valor aleatório entre 1 e o número de faces (`numerofaces`).

### 2. LevarDano

**Descrição:** Aplica dano ao personagem, reduzindo seus Pontos de Vida (PV). Garante que a vida permaneça dentro dos limites (0 a Vida Máxima).
**Assinatura (C#):** `static int LevarDano(int vidaAtual, int vidaMax, int danoTomado)`
**Comportamento:**

* Subtrai o dano do PV atual.
* Garante que o novo PV não seja menor que 0.
* Garante que o novo PV não seja maior que a Vida Máxima.

### 3. CalcularAlcance

**Descrição:** Calcula a distância entre dois personagens no mapa (baseado em coordenadas X e Y) e classifica essa distância em categorias ("curto", "medio" ou "longo").
**Assinatura (C#):** `public static string CalcularAlcance(int px, int py, int ex, int ey)`
**Comportamento:**

* Calcula a distância total como a soma das diferenças absolutas das coordenadas (Distância Manhattan).
* Se a distância $\le 2$, retorna "curto".
* Se a distância $\le 5$ (e $> 2$), retorna "medio".
* Se a distância $> 5$, retorna "longo".

### 4. TesteAtributo (Teste de Atributo Contra Atributo)

**Descrição:** Realiza um teste comparando a competência do atacante contra a defesa/agilidade do defensor através de rolagem de dados.
**Assinatura (C#):** `public static bool TesteAtributo(int atribAtacante, int atribDefensor)`
**Comportamento:**

* Rola dois dados d20: um para o atacante e um para o defensor.
* Calcula o resultado final: (rolagem d20 + valor do atributo).
* Sucesso se: `resultadoAtacante >= resultadoDefensor`.

### 5. VerificarAtaque

**Descrição:** Verifica se o ataque é válido, checando se o atacante possui recurso suficiente e se o alvo está dentro do alcance do ataque.
**Assinatura (C#):** `public bool VerificarAtaque(global::Personagem.Personagem atacante, global::Personagem.Personagem defensor, global::Personagem.Personagem.Ataque ataque)`
**Comportamento:**

* Verifica se o `atacante.Recurso` é suficiente para o `ataque.CustoRecurso`.
* Chama `CalcularAlcance` para determinar a distância atual.
* Compara a distância atual com o `ataque.Alcance` ("curto", "medio" ou "longo"). O alcance mais longo cobre alcances mais curtos.
* Retorna `true` se recurso for suficiente e o alvo estiver dentro do alcance; caso contrário, retorna `false`.

### 6. Atacar

**Descrição:** Executa a ação de ataque entre dois personagens, lidando com custo de recurso, verificação de ataque e aplicação de dano, incluindo a regra de ataque fraco.
**Assinatura (C#):** `public void Atacar(global::Personagem.Personagem jogador, global::Personagem.Personagem inimigo, global::Personagem.Personagem.Ataque ataque)`
**Comportamento:**

* **Se jogador tem recurso suficiente (`jogador.Recurso >= ataque.CustoRecurso`):**
    * Chama `VerificarAtaque`.
    * Se válido, chama `TesteAtributo` (`jogador.Forca` vs `inimigo.Agilidade`).
    * Se o teste passar, subtrai `ataque.CustoRecurso` do `jogador.Recurso` e aplica `ataque.Dano` no inimigo via `LevarDano`.
* **Se jogador NÃO tem recurso suficiente:**
    * Chama `TesteAtributo` (ataque fraco).
    * Se o teste passar, aplica um `danoMinimo = 1` ao inimigo.
    * Se o teste falhar, o ataque não causa dano.