using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Store/Item")]
public class ItemStore : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public float price = 50f;
    public bool bought = false;

    public virtual void BuyAction() { }
}