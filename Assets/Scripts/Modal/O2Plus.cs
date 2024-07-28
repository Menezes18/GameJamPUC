using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2Plus : ItemStore
{
 override public void BuyAction() {
    OxigenioPlayer.instancia.maxOxigenio = OxigenioPlayer.instancia.maxOxigenio * 2;
    OxigenioPlayer.instancia.oxigenio = OxigenioPlayer.instancia.oxigenio * 2;
 }
}
