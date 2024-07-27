using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class OxigenioPlayer : MonoBehaviour{
    public static OxigenioPlayer instancia;
    public float oxigenio;
    public float maxOxigenio;
    public float rate = 1.0f;
    public float rateReg = 1.0f;
    
    public bool OxigenioReg = true;

    private void Awake(){
        instancia = this;
    }

    private void Update(){
        
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

    }

    public void AumentarOxigenio(int oxigenioPower){
        maxOxigenio += oxigenioPower;
    }
    
    
    
    
}
