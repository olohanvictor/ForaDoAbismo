# ?? Fora do Abismo - Tactical RPG

Um Tactical RPG desenvolvido em C# onde você encarna um personagem lutando pela sobrevivência em um mundo subterrâneo perigoso. Crie seu herói, escolha sua classe através de um quiz imersivo e enfrente inimigos em combates estratégicos.

## ?? Sobre o Projeto

**Fora do Abismo** é um projeto de Tactical RPG (Role-Playing Game) criado colaborativamente por uma turma de estudantes. O jogo combina elementos de exploração, narrativa interativa e combate tático em um ambiente de texto enriquecido com cores e símbolos visuais.

### Características Principais

- ?? **Sistema de Criação de Personagem** com quiz dinâmico
- ?? **Combate Tático** baseado em atributos e testes de habilidades
- ??? **Exploração de Mapa** com múltiplos níveis
- ?? **Narrativa Interativa** que guia o jogador pela história
- ?? **Interface em Cores** para melhor experiência visual
- ??? **3 Classes Diferentes**: Guerreiro, Arqueiro e Mago

## ?? Como Executar

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download) instalado
- Windows, macOS ou Linux

### Instalação

1. Clone o repositório:
```bash
git clone https://github.com/olohanvictor/ForaDoAbismo.git
cd ForaDoAbismo
```

2. Execute o jogo:
```bash
dotnet run
```

## ?? Como Jogar

### Controles

| Tecla | Ação |
|-------|------|
| **W** | Mover para cima |
| **S** | Mover para baixo |
| **A** | Mover para esquerda |
| **D** | Mover para direita |
| **Q** | Sair do jogo |

### Legenda do Mapa

| Símbolo | Significado |
|---------|-------------|
| **P** | Você (Jogador) |
| **)(** | Saída/Entrada para próximo nível |
| **\*** | Perigo/Armadilha |
| **C** | Inimigo/Carcereiro |
| **?** | Árvore/Fungo Gigante |
| **˜** | Água/Lago |
| **[ ]** | Parede |

### Fluxo do Jogo

1. **Criação de Personagem**: Defina seu nome e escolha seu gênero
2. **Quiz de Classe**: Responda perguntas que determinam sua classe (Guerreiro, Arqueiro ou Mago)
3. **Distribuição de Atributos**: Aloque 10 pontos entre Força, Agilidade, Fortitude e Sabedoria
4. **Cela dos Escravos**: Primeira cena da história onde você precisa escapar
5. **Exploração**: Navegue pelos níveis do abismo
6. **Combate**: Enfrente inimigos usando estratégia e ataque

## ??? Classes de Personagem

### Guerreiro
- **Força**: 16 | **Agilidade**: 11 | **Fortitude**: 15 | **Sabedoria**: 9
- **Vida Max**: 30 + Fortitude
- **Ataques**:
  - Investida Feroz: 10 dano, 8 recurso
  - Corte de Machado: 3 dano, 3 recurso

### Arqueiro
- **Força**: 10 | **Agilidade**: 16 | **Fortitude**: 8 | **Sabedoria**: 7
- **Vida Max**: 15 + Fortitude
- **Ataques**:
  - Chuva de Flechas: 5 dano, 3 recurso
  - Tiro de Flecha: 3 dano, 1 recurso

### Mago
- **Força**: 6 | **Agilidade**: 8 | **Fortitude**: 10 | **Sabedoria**: 16
- **Vida Max**: 12 + Fortitude
- **Ataques**:
  - Bola de Fogo: 8 dano, 5 recurso
  - Míssel Mágico: 3 dano, 3 recurso

## ?? Estrutura do Projeto

```
ForaDoAbismo/
+-- main.cs                      # Arquivo principal do programa
+-- src/
¦   +-- Personagem/
¦   ¦   +-- Personagem.cs        # Classes base e derivadas de personagem
¦   +-- Combate/
¦   ¦   +-- Combate.cs           # Lógica de combate
¦   ¦   +-- Movimento.cs         # Lógica de movimento
¦   +-- Mapa/
¦   ¦   +-- Mapa.cs              # Geração e renderização do mapa
¦   +-- Game/
¦   ¦   +-- GerenciadorDoJogo.cs # Gerenciador principal do jogo
¦   ¦   +-- GerenciadorCombate.cs# Orquestração de combates
¦   ¦   +-- SistemaDeInimigos.cs # Comportamento dos inimigos
¦   ¦   +-- SistemaDeHistoria.cs # Narrativa e eventos
¦   ¦   +-- CelaDoEscravos.cs    # Cena inicial
¦   +-- Sistemas/
¦   ¦   +-- menu.cs              # Sistema de menu
¦   +-- ControleDeTurno/
¦       +-- fsm_ct.cs            # State machine para controle de turno
+-- ForaDoAbismo.csproj          # Arquivo de configuração do projeto
+-- README.md                    # Este arquivo
+-- tarefas.md                   # Documentação de desenvolvimento
```

## ?? Sistema de Combate

O combate utiliza um sistema baseado em atributos e testes:

1. **Verificação de Alcance**: O ataque é válido se o inimigo está no alcance
2. **Teste de Habilidade**: O atacante faz um d20 + atributo de Força
3. **Defesa**: O defensor faz um d20 + atributo de Agilidade
4. **Resultado**: Se o atacante vencer o teste, causa dano ao inimigo
5. **Recurso**: Cada ataque consome recurso (mana/stamina)

## ?? Atributos

| Atributo | Descrição |
|----------|-----------|
| **Força** | Aumenta dano dos ataques |
| **Agilidade** | Aumenta Classe de Armadura e defesa |
| **Fortitude** | Aumenta vida máxima |
| **Sabedoria** | Afeta resistência a efeitos mágicos |

## ?? Equipe de Desenvolvimento

O projeto foi desenvolvido colaborativamente pela **turma 2003** com as seguintes áreas de especialização:

- **Combate**: Lógica de combate e mecanismos
- **Mapa**: Design e renderização visual do mapa
- **Sistema**: Menus, fluxo de jogo e narrativa
- **Personagem**: Criação e gerenciamento de personagens
- **Implementação**: Integração e testes
- **Comunicação**: Documentação e coordenação
- **Gerência**: Coordenação geral do projeto

Veja `tarefas.md` para detalhes completos da equipe.

## ?? Documentação

Para documentação técnica detalhada, consulte `tarefas.md`.

## ?? Requisitos Técnicos

- **Linguagem**: C# 14.0
- **Framework**: .NET 10
- **Tipo de Projeto**: Console Application

## ?? Licença

Este projeto é parte de um trabalho educacional.

## ?? Contribuindo

Este é um projeto estudantil. Para contribuições, entre em contato com a equipe do projeto.

---

**Desenvolvido com ?? pela Turma 2003**
