using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNadadeira", menuName = "Store/Nadadeira")]
public class Nadadeira : ItemStore
{
    public override void BuyAction()
    {
        ThirdPersonController.instancia.Movement(50);
    }
}
