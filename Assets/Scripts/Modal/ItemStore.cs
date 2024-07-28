using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class ItemStore : MonoBehaviour {

    public string name;
    public Sprite itemImage;
    public float price = 50f;
    public bool buyed = false;


    public void BuyItem() {
        buyed = true;
    }

    public float GetPrice() {
        return price;
    }

    public string GetName() {
        return name;
    }

    public Sprite GetImage() {
        return itemImage;
    }

    public virtual void BuyAction() {}
 
}
