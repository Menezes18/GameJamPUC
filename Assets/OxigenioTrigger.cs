using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxigenioTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other){
        if (other.CompareTag("Player")){
            OxigenioPlayer.instancia.OxigenioReg = false;
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.CompareTag("Player")){
            OxigenioPlayer.instancia.OxigenioReg = true;
        }
    }
}
