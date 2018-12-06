using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemAudio : MonoBehaviour {

    // AQUI FICA A LISTA DE TODOS OS AUDIOS
    public AudioClip[] audios = new AudioClip[3];

    // ESSE É O METODO QUE É CHAMADO PARA EXECUTAR AUDIO
    public void SetAudio(int numberAudio, Transform areaAudio,bool clones = false , bool loop = false, float time = 0)
    {
        /*
        // ------------------------EXPLICANDO VARIAVEIS---------------------------------//
                                   
int numberAudio = Define qual audio da lista ira tocar !  (verificar catalogo antes de escolher o numero)

Transform areaAudio = ele diz qual a posição em que o audio ira tocar.

bool clones = Determina se será necessário existir clones do mesmo audio ao mesmo tempo ou não.

bool loop = diz se o audio tocara em loop, caso coloque que sim (true) logo em seguida acompanhado de uma 
virgula coloque um numero inteiro de quanto tempo quer q ele continue tocando, caso não diga ele tocara somente
por 1 segundo.

int time = tempo de vida. só utilize caso queira extender o tempo em que ele dure na tela.

        // ------------------------EXPLICANDO VARIAVEIS---------------------------------//
        */


        // ESSE É UM DEBUG COMENTADO
        //Debug.Log("chamou");

        // SE NÃO FOR PERMITIDO CLONES E OBJETO DE AUDIO JA EXISTIR NA CENA ELE CANCELA.
        if (clones == false && GameObject.Find(audios[numberAudio].name))
            return;

        // CRIA UM GAME OBJECT NOVO VAZIO
        GameObject obj;
        // DIZ QUE ELE É UMA GAME OBJECT CHAMADO "RecipienteDoAudio"
        obj = new GameObject("RecipienteDoAudio");
        // TRANSFORMA A POSIÇÃO DELE PARA A DA AREA/LUGAR EM QUE ELE VAI SER EXECUTADO
        obj.transform.transform.position = areaAudio.position;

        // CRIA UM AudioSource dentro do nosso obj RecipienteDoAudio
        AudioSource AudioInstanciado = obj.AddComponent<AudioSource>();
        // NÃO DEIXA AUDIO EXECUTAR ANTES DE DECIDIR SUAS CONFIGURAÇÕES
        AudioInstanciado.Stop();
        // CONFIGURA AUDIO SE ELE SERÁ EM LOOP
        AudioInstanciado.loop = loop;
        // AQUI ADICIONA O AUDIO DO "CATALOGO" QUE É CHAMADO PELA VARIAVEL numberAudio.
        AudioInstanciado.clip = audios[numberAudio];
        // NOMEIA O OBJETO QUE CONTÉM O SOM COM O NOME DO AUDIO.
        obj.name = audios[numberAudio].name;

        // E SÓ ASSIM INICIA O PLAY.
        AudioInstanciado.Play();

        // APENAS UM VERIFICADOR SE VOCÊ COLOCOU EM LOOP OU NÃO. de acordo com sua escolha ele muda o tempo para destruir.
        if (loop == true && time != 0)
        {
            // ESSE É UM DEBUG COMENTADO
            //Debug.Log("Loop Esta True");

            // ADICIONA O SCRIPT destroy E SETA SEU TEMPO PARA SER DESTRUIDO em que foi chamado pela variavel time.
            obj.AddComponent<destroyAudio>().time = time;
        }
        else
        {
            // Tempo é igual ao tamanho do clip. :)
            time = AudioInstanciado.clip.length;
            // ESSE É UM DEBUG COMENTADO
            //Debug.Log("Loop Esta false");

            // ADICIONA O SCRIPT destroy E SETA SEU TEMPO PARA SER DESTRUIDO em que foi chamado pela variavel time.
            obj.AddComponent<destroyAudio>().time = time;
        }
    }

}

/*
---------------------------------CATALAGO-DE-AUDIOS--------------------------------
---------------------------------------------------------------------------------------------

                      "Escolha o número do audio que pretende executar"

---------------------------------------------------------------------------------------------
CUTSCENE
---------------------------------------------------------------------------------------------

-Cutscene opcional
0 ----- Música / Dorme Neném / Acordando ou Dormindo

---------------------------------------------------------------------------------------------
EFEITOS SONOROS
---------------------------------------------------------------------------------------------

-todas as fases
4 ----- Efeito / Morte
5 ----- Efeito / Cipó
8 ----- Efeito / Armadilha Comum
9 ----- Efeito / Armadilha Espinhos
16 --- Efeito / Boss Vencido

---------------------------------------------------------------------------------------------
MONSTROS
---------------------------------------------------------------------------------------------

-Fase 1
1 ----- Grito / Ataque Inimigo
2 ----- Grito / Ataque peao com lanca
3 ----- Efeito / Ataques magicos peoes

-Fase 2
6 ----- Efeito / Plantas Ataque
7 ----- Efeito / Pulo Cogumelo

-Fase 3
10 --- Efeito / Ataque Mago 01
11 --- Efeito / Ataque Mago 02

-Fase 4
12 --- Efeito / Golpe Do Inimigo DO Martelo
13 --- Efeito / Motor Moto

---------------------------------------------------------------------------------------------
PERSONAGEM
---------------------------------------------------------------------------------------------

-Player 
17 --- Efeito / Ataque Magico Comum
18 --- Efeito / Ataque Magico Especial
19 --- Efeito / Pulo
60 --- Grito / Ataque 1
61 --- Grito / Ataque 2
62 --- Grito / Ataque 3
63 --- Grito / Ataque 4
64 --- Grunido / Cansado
65 --- Sopro / Pulo 1
66 --- Sopro / Pulo 2
67 --- Sopro / Pulo 3
68 --- Sopro / Pulo 4

---------------------------------------------------------------------------------------------
MENU PRINCIPAL
---------------------------------------------------------------------------------------------

-Menu 
14 --- Efeito / Botao 1
15 --- Efeito / Botao 2

---------------------------------------------------------------------------------------------
TODAS AS FALAS
---------------------------------------------------------------------------------------------

-Cristian
20 --- Cleber, voce naoo vai para a empressora
21 --- Eae Irmao
22 --- Estao dando errado
23 --- Grito de dor 
24 --- O videogame naoooo
25 --- Sei que veio em busca do meu tesouro, engula esses dados
26 --- Som de morte
27 --- Vai dar pau em

-Gilvan
28 --- Caguei para voce
29 --- Discurso de primeiro dia de aula
30 --- Ei eu nao sou seu amigo
31 --- Esperava mais
32 --- Gemido
33 --- Grito de dor 
34 --- Grito de morte
35 --- Você sabe O que é um game designer?
36 --- O que voce veio fazer aqui
37 --- Veii

-Paulinho
38 --- Certinho
39 --- E mais isso
40 --- E mais issooo
41 --- Estao desmotivado
42 --- Oi eu sou o paulinho
43 --- Risada de morte
44 --- teapot
45 --- Tome isso
46 --- Tome isso e mais isso e issooo

-Wagner
47 --- Agora me de isso garoto
48 --- Agora que tenho o que preciso, nao ficarei mais ao seu lado moleque
49 --- Arduino
50 --- Explicacao sobre bug world
51 --- Muito bem Kleber, deixa que eu falo com os deuses
52 --- Nao
53 --- Ninguem vai me impedir na minha forma finalllll
54 --- Oí garoto bem vindo a bug world
55 --- Risada
56 --- Som de dor  e morte
57 --- Vamos
58 --- Voce nao e pareo para mim
59 --- Vou te atropelar

-Player/Kleber
69 --- Detonando
70 --- Eiii pensei que voce iria me ajudar
71 --- Entao ele tambem e um vilao
72 --- Estou tao cansado
73 --- Etnao foi tudo um...sonho
74 --- Ja vai comecar a parte chata
75 --- Nuncaaaa
76 --- O que e isso, ele se fundiu com uma moto 
77 --- O que eisso, o que esta acontecendo aaaaaa
78 --- O que eu estou fazendo aqui, aonde eu estou
79 --- Peraí muita informacao, tenho alguma escolha
80 --- Que velho estranho..fazer oque vamos ir
81 --- Restart 1
82 --- Restart 2
83 --- Risos
84 --- Tarzan, grito de queda aaaaaaaaaaa

---------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------
*/
