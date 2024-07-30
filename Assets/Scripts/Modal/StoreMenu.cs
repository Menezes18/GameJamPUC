using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreMenu : ModalMenu
{
    private List<ItemStore> items;
    [SerializeField] private List<GameObject> storeItemsButtons;
    [SerializeField] private GameObject store;
    [SerializeField] private GameObject confirmation;
    
    private int itemSelectedIndex;

    public string confirmationMessage = "Deseja comprar ";
    [SerializeField] private TMP_Text confirmationText;

    private void Start()
    {
        
        items = GameManager.instance.items;
        UpdateItemsList();
    }

    private void OnEnable()
    {
        store.SetActive(true);
        confirmation.SetActive(false);
    }

    public void UpdateItemsList()
    {
        for (int i = 0; i < storeItemsButtons.Count; i++)
        {
            if (i > items.Count - 1)
            {
                storeItemsButtons[i].SetActive(false);
            }
            else
            {
                SetButtonInfo(i, items[i]);
                storeItemsButtons[i].SetActive(true);
                if (items[i].bought)
                {
                    storeItemsButtons[i].GetComponent<Button>().interactable = false;
                }
            }
        }
    }
    
    public void ShowConfirmation(int index)
    {
        itemSelectedIndex = index;
        confirmationText.text = confirmationMessage + storeItemsButtons[index].transform.GetChild(0).GetComponent<TMP_Text>().text;
        store.SetActive(false);
        confirmation.SetActive(true);
    }

    public void CancelConfirmation()
    {
        itemSelectedIndex = -1;
        store.SetActive(true);
        confirmation.SetActive(false);
    }

    private void SetButtonInfo(int index, ItemStore item)
    {
        storeItemsButtons[index].transform.GetChild(0).GetComponent<TMP_Text>().text = item.itemName;
        storeItemsButtons[index].transform.GetChild(1).GetComponent<Image>().sprite = item.itemImage;
        storeItemsButtons[index].transform.GetChild(2).GetComponent<TMP_Text>().text = "$" + item.price.ToString();
    }

    public void BuyItem()
    {
        if (GameManager.instance.money > items[itemSelectedIndex].price && !items[itemSelectedIndex].bought)
        {
            GameManager.instance.BuyItem(itemSelectedIndex, items[itemSelectedIndex].price);
            UpdateItemsList();
            CloseModal();
        }
    }
}
