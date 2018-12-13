using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// APENAS UM CÓDIGO PARA TESTAR O SISTEMA DE AUDIO
public class InputTest : MonoBehaviour {

    // AQUI GUARDA O SISTEMA DE AUDIO QUE DEVERA ESTAR LOCALIZADO NO GAMEOBJECT (EventSystemAudio)
    public SystemAudio systemAudio;
    public int numAudio;
    //public Transform posStart;
    //public bool clones;
    //public bool loop;
    //public float timeDestroy;


	// APENAS MAIS UM UPDATE
	void Update () {

        // CASO PRESSIONE PARA BAIXO A LETRA "A" ELE EXECUTA O CÓDIGO
        if (Input.GetKeyDown(KeyCode.A))
        {
            // ESSE É UM DEBUG COMENTADO
            //Debug.Log("A");

            // ABAIXO É CHAMADO O MÉTODO DO AUDIO.

            systemAudio.SetAudio(numAudio, gameObject.transform, false, false, 3);
            // numAudio = é a variavel int com o numero selecionado da lista de audios. int = x;
            // gameObject.transform = está selecionando o local em que quero que o audio apareça. transform.position;
            // false = é a permissão para executar o mesmo audio mais de uma vez ao mesmo tempo. clone = true;
            // false = é a afirmação de que o Audio selecionado NÃO tocara em loop.  loop = false;
            // 3 = é o timer para destruir o objeto CASO loop seja true. float = 3;
        }

    }
}