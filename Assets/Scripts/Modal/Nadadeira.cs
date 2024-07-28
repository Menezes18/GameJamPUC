using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class Nadadeira : ItemStore{
    public ThirdPersonController player = FindObjectOfType<ThirdPersonController>();
   override public void BuyAction() {
    ThirdPersonController.instancia.Movement(5);
    
   }
}
