using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewO2Plus", menuName = "Store/O2Plus")]
public class O2Plus : ItemStore
{
    public override void BuyAction()
    {
        OxigenioPlayer.instancia.AumentarOxigenio(100);
        OxigenioPlayer.instancia.SaveOxigenio();
    }
}