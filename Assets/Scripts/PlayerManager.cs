using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour{
    public static PlayerManager instancia;
    
    public float vida = 100;
    public bool itemMao = false;

    public GameObject vfxBolhaSobe;
    public GameObject vfxBolhaDesce;
    private void Awake(){
        instancia = this;
        ChamarVfx(1);
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
