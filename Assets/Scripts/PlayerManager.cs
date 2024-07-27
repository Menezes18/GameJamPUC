using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour{
    public static PlayerManager instancia;
    
    public float vida = 100;
    public int coin;
    public bool itemMao = false;
    private void Awake(){
        instancia = this;
    }
    
    
}
