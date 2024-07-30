using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour{
    public static PlayerManager instancia;
    
    public float vida = 100;
    public bool itemMao = false;

    public GameObject vfxBolhaSobe;
    public GameObject vfxBolhaDesce;
    
    public GameObject painel;
    public TextMeshProUGUI textMesh;
    private void Awake(){
        instancia = this;
        ChamarVfx(1);
    }

    public void Start(){
        
        
    }

    public void textPainel(string text){
        
        var canvasInfo = painel.GetComponent<CanvasGroup>();
        textMesh.text = text;
        StartCoroutine(FadeInAndOut());
        
    }
    private IEnumerator FadeInAndOut()
    {
        CanvasGroup canvasInfo = painel.GetComponent<CanvasGroup>();
        yield return StartCoroutine(FadeCanvasGroup(canvasInfo, 0, 1, 1.0f)); // Fade in over 1 second
        yield return new WaitForSeconds(5); // Wait for 5 seconds
        yield return StartCoroutine(FadeCanvasGroup(canvasInfo, 1, 0, 1.0f)); // Fade out over 1 second
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }
    }
    public void ChamarVfx(int i){
        if (i == 0){
            var ativar = vfxBolhaSobe.GetComponent<ParticleSystem>();
            ativar.Play();
            vfxBolhaSobe.SetActive(true);
            vfxBolhaDesce.SetActive(false);
            
        }
        else{
            var ativar = vfxBolhaDesce.GetComponent<ParticleSystem>();
            ativar.Play();
            vfxBolhaSobe.SetActive(false);
            vfxBolhaDesce.SetActive(true);
        }
        
    }
    
}
