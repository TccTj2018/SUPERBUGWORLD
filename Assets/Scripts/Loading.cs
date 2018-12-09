using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

    public string cenaAcarregar;
    public float tempoFixoSeg = 5;
    public enum tipoCarreg { carregamento, tempoFixo };
    public tipoCarreg tipoDeCarregamento;
    public Image barraDeCarregamento;
    public Text textoProgress;

    private int progress = 0;
    private string textOriginal;

    void Start()
    {
        switch (tipoDeCarregamento)
        {
            case tipoCarreg.carregamento:
                StartCoroutine(CenaDeCarregamento(cenaAcarregar));
                break;

            case tipoCarreg.tempoFixo:
                StartCoroutine(TempoFixo(cenaAcarregar));
                break;

        }
        if (textoProgress != null)
            textOriginal = textoProgress.text;

        if (barraDeCarregamento != null)
        {
            barraDeCarregamento.type = Image.Type.Filled;
            barraDeCarregamento.fillMethod = Image.FillMethod.Horizontal;
            barraDeCarregamento.fillOrigin = (int)Image.OriginHorizontal.Left;
        }
    }
    IEnumerator CenaDeCarregamento(string cena)
    {

        AsyncOperation carregamento = SceneManager.LoadSceneAsync(cena);
        while (!carregamento.isDone)
        {
            progress = (int)(carregamento.progress * 100.0f);
            yield return null;
        }


    }

    IEnumerator TempoFixo(string cena)
    {

        yield return new WaitForSeconds(tempoFixoSeg);
        SceneManager.LoadScene(cena);


    }

    void FixedUpdate()
    {
        switch (tipoDeCarregamento)
        {
            case tipoCarreg.carregamento:
                break;

            case tipoCarreg.tempoFixo:
                progress = (int)(Mathf.Clamp((Time.time / tempoFixoSeg), 0.0f, 1.0f) * 100.0f);
                break;


        }
        if (textoProgress != null)
        {
            textoProgress.text = textOriginal + "" + progress + "%";
        }

        if (barraDeCarregamento != null)
        {
            barraDeCarregamento.fillAmount = (progress / 100.0f);
        }
    }
}
