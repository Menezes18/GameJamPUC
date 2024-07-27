using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class ArrumarSub : MonoBehaviour{
    public ItemData _ItemData;
    public GameObject objetQuebrado;
    public bool arrumar = true;
    public GameObject canvas;
    private void Update(){
        if (arrumar){
            canvas.SetActive(true);
            
        }
        else{
            canvas.SetActive(false);
        }
        
    }
    
    public void Arrumar(){
        arrumar = false;
        //Destroy(objetQuebrado);
        objetQuebrado.SetActive(true);
        //Instantiate(_ItemData.prefab, objetQuebrado.transform.position, objetQuebrado.transform.rotation);
        }
        
    
}
