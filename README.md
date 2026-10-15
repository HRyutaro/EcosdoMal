# Ecos do Mal

Jogo de **terror psicológico em primeira pessoa** inspirado em *O Iluminado*. Charles Grady, veterano da Guerra Civil, assume os cuidados de um hotel isolado e, dia após dia, vai perdendo a consciência.

▶️ **Baixe no itch.io:** https://hryutaro.itch.io/ecosdomal

## Minha função
**Único programador do projeto**: toda a lógica de gameplay, eventos, UI e sistemas foi feita por mim.
Projeto em equipe do 6º semestre de Design de Games da Universidade Anhembi Morumbi (2023).

## Destaques técnicos
- **Estrutura por dias**: 5 dias jogáveis, cada um com sua cena e lista de tarefas (limpar o hotel, consertar canos, ler o jornal…), terminando em um labirinto final.
- **Sistema de tarefas** com checklist que libera os eventos da história conforme o jogador avança.
- **Interação por raycast** a partir da câmera, com **outline** destacando objetos interagíveis.
- **Eventos de terror** acionados por triggers: aparições, apagões, sons no corredor e perseguições.
- **Lanterna com bateria**, interruptores de luz e fósforos como recurso de inventário.
- **Diálogos com efeito de máquina de escrever**, cutscenes que podem ser puladas e tutorial.
- **Controle em primeira pessoa** próprio, com sensibilidade e suavização de câmera, agachar e itens na mão (machado, vassoura, arma, caderno).
- **Menu de pausa e opções**, além de um modo de depuração ("modo deus") para testar as fases.

## Tecnologias
Unity 2021.3 · C# · Unity UI · Corrotinas · Raycasts

## Como abrir o projeto
1. Clone o repositório.
2. Abra no Unity Hub com a **Unity 2021.3.21f1**.
3. Comece pela cena `Assets/Scenes/Menu.unity`.
