using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class OxigenioPlayer : MonoBehaviour{
    public static OxigenioPlayer instancia;
    public float oxigenio;
    public float maxOxigenio;
    public float rate = 1.0f;
    public float rateReg = 1.0f;
    public bool OxigenioReg = true;
    public Animator _animacaoVinheta;
    public GameObject _vinheta;

    public Image sliderOxigenio;
    private void Awake(){
        instancia = this;
    }

    public void UpdateUI(){
        sliderOxigenio.fillAmount = oxigenio / 100;
    }
    private void Update(){
        UpdateUI();
        if (oxigenio < 0)
        {
            Debug.Log("moreu");
            
            oxigenio = 0;
        }

        if (OxigenioReg){
            oxigenio -= rateReg * Time.deltaTime;
            
        }
        else if(!OxigenioReg){
            if (oxigenio <= maxOxigenio){
                oxigenio += rate * Time.deltaTime;
            }
            
        }

        if (oxigenio < 25){
            _vinheta.SetActive(true);
            _animacaoVinheta.SetBool("Batenndo",true);
        }
        else{
            _animacaoVinheta.SetBool("Batenndo", false);
            _vinheta.SetActive(false);
        }

    }

    public void AumentarOxigenio(int oxigenioPower){
        maxOxigenio += oxigenioPower;
    }
    
    
    
    
}
