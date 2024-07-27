using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RecarregarOxigenio : MonoBehaviour{

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
