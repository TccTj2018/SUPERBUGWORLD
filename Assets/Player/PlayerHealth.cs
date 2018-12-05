using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public static bool RecebendoDano; //VARIAVEL ESTATICA QUE INDICA SE ESTA RECEBENDO DANO OU NAO
    public float tempoPorAtaque = 1.5f; // TEMPO MINIMO ENTRE CADA ATAQUE QUE O INIMIGO PODE DAR
    public float cronometroDeAtaque; // CRONOMETRO QUE CONTROLA O TEMPO DOS ATAQUES
    public int VidaDoPlayer = 100; // VIDA DO PERSONAGEM
    public int DanoPorAtaque = 40;
    public int maxMana;

    public int bugCoins;
    public bool isDead;
    public GameObject panelGameOver;

    private Rigidbody rb;
    public Animator anim;
    public GameObject rend;
    private Fight player;
    

    void Start()
    {
        RecebendoDano = false; // A VARIAVEL RecebendoDano RECEBE FALSO
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<GameObject>();
        player = GetComponent<Fight>();

        //panelGameOver = GameObject.Find("GameOver").GetComponent<GameObject>();
        //panelGameOver.SetActive(false);

        VidaDoPlayer = GameManager.inventory.health;
       // VidaDoPlayer = player.maxHealth;
        DanoPorAtaque = player.strength;
        maxMana = player.maxMana;



    }
    void Update()
    {
        if (RecebendoDano == true)
        { // SE RecebendoDano ESTA VERDADEIRO
           // cronometroDeAtaque += Time.deltaTime; // O CRONOMETRO COMEÇA A CONTAR
        }
        else
        { // SE NAO, OU SEJA, SE RecebendoDano ESTA FALSO
            //cronometroDeAtaque = 0; // O CRONOMETRO RECEBE 0
        }
        if (cronometroDeAtaque >= tempoPorAtaque)
        { // SE O CRONOMETRO ULTRAPASSOU O TEMPO POR ATAQUE
           // cronometroDeAtaque = 0; // CRONOMETRO RECEBE 0
           // VidaDoPlayer = VidaDoPlayer - DanoPorAtaque; // A VIDA DO PLAYER RECEBE O VALOR DELA MESMA MENOS O DANO DO ATAQUE
        }
        if (VidaDoPlayer <= 0 && maxMana <= 0)
        { // SE A VIDA FOR MENOR OU IGUAL A 0
            isDead = true;
            rb.velocity = Vector3.zero;
            anim.SetTrigger("Dead");
            FindObjectOfType<Fight>().bugCoins += bugCoins;
            //Invoke("ReloadScene", 2f);
            //Invoke("GameOver", 1f);
           // panelGameOver.SetActive(true);

        }
        else
        {
            //panelGameOver.SetActive(false);
           // StartCoroutine(DamageCoroutine());
        }


    }
    IEnumerator DamageCoroutine()
    {
            for (float i = 0; i < 0.6f; i += 0.2f)
            {
             // rend.SetActive(false);
              //yield return new WaitForSeconds(0.1f);
              //rend.SetActive(true);
             // yield return new WaitForSeconds(0.1f);
            }
        return null;
        
        //isDead = true;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("MenuInicial");
    }
    void ReloadScene()
     {
        BugCoins.instance.gameObject.SetActive(true);
        BugCoins.instance.bugCoins = bugCoins;
        BugCoins.instance.transform.position = transform.position;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     }
}
