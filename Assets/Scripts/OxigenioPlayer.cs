using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxigenioPlayer : MonoBehaviour{
    public float oxigenio;
    public float rate = 1.0f;
    
    private void Update(){
        oxigenio -= rate * Time.deltaTime;

        if (oxigenio < 0){
            oxigenio = 0;
            Debug.Log("morreu");
        }
    }
}
