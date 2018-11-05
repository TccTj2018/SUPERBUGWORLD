using UnityEngine;
using System.Collections;
public class PlayerHealth : MonoBehaviour
{
    public static bool RecebendoDano; //VARIAVEL ESTATICA QUE INDICA SE ESTA RECEBENDO DANO OU NAO
    public float tempoPorAtaque = 1.5f; // TEMPO MINIMO ENTRE CADA ATAQUE QUE O INIMIGO PODE DAR
    private float cronometroDeAtaque; // CRONOMETRO QUE CONTROLA O TEMPO DOS ATAQUES
    public int VidaDoPlayer = 100; // VIDA DO PERSONAGEM
    public int DanoPorAtaque = 40;
    void Start()
    {
        RecebendoDano = false; // A VARIAVEL RecebendoDano RECEBE FALSO
    }
    void Update()
    {
        if (RecebendoDano == true)
        { // SE RecebendoDano ESTA VERDADEIRO
            cronometroDeAtaque += Time.deltaTime; // O CRONOMETRO COMEÇA A CONTAR
        }
        else
        { // SE NAO, OU SEJA, SE RecebendoDano ESTA FALSO
            cronometroDeAtaque = 0; // O CRONOMETRO RECEBE 0
        }
        if (cronometroDeAtaque >= tempoPorAtaque)
        { // SE O CRONOMETRO ULTRAPASSOU O TEMPO POR ATAQUE
            cronometroDeAtaque = 0; // CRONOMETRO RECEBE 0
            VidaDoPlayer = VidaDoPlayer - DanoPorAtaque; // A VIDA DO PLAYER RECEBE O VALOR DELA MESMA MENOS O DANO DO ATAQUE
        }
        if (VidaDoPlayer <= 0)
        { // SE A VIDA FOR MENOR OU IGUAL A 0
            
        }
    }
}
