using UnityEngine;

public class dano : MonoBehaviour {

    public int damageEnemy = 5;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerHealth>().DamagePlayer(damageEnemy);
        }
        
    }
}

public class BugCoin : MonoBehaviour
{

    public int bugCoins = 1;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Este pode ser adicionado na morte de um inimigo para que 
            //também colete BugCoins
            FindObjectOfType<Fight>().bugCoins += bugCoins;
        }

    }
}
