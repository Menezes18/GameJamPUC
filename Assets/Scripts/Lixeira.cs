using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lixeira : MonoBehaviour{
    
    
    public Reciclavel _reciclavelLixeira;
    public int _acertos;
    public int _erros;



    private void OnTriggerEnter(Collider other){

        if (other.gameObject.CompareTag("Objeto")){

            var lixoScript = other.GetComponent<LixoReciclavel>();
            if (lixoScript.reciclavel == _reciclavelLixeira){
                _acertos++;
                Destroy(other.gameObject);
            }
            else{
                _erros++;
                Destroy(other.gameObject);
            }
        }
    }
}
