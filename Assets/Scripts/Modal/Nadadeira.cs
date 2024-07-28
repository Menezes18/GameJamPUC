using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class Nadadeira : ItemStore
{
    ThirdPersonController player = (ThirdPersonController) GameObject.FindObjectOfType(typeof(ThirdPersonController));
   override public void BuyAction() {
    player.MoveSpeed = 4.0f;
    player.SprintSpeed = 6.5f;
   }
}
