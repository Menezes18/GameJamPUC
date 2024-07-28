using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreMenu : ModalMenu {

    private List<ItemStore> items;
    [SerializeField] private List<GameObject> storeItensButtons;
    [SerializeField] private GameObject store;
    [SerializeField] private GameObject confirmation;

    private int itemSelectedIndex;

    public string confirmationMessage = "Deseja comprar ";
    [SerializeField] private TMP_Text confimationText;

    private void Start() {
        items = GameManager.instace.items;
        UpdateItensList();
    }

    private void OnEnable() {
        store.gameObject.SetActive(true);
        confirmation.gameObject.SetActive(false);
    }

    public void UpdateItensList() {
        for (int i = 0; i < storeItensButtons.Count; i++) {
            if (i > items.Count - 1) {
                storeItensButtons[i].gameObject.SetActive(false);
            }
            else {
                SetButtonInfo(i, items[i]);
                storeItensButtons[i].gameObject.SetActive(true);
                if (items[i].buyed) {
                    storeItensButtons[i].GetComponent<Button>().interactable = false;
                }
            }
        }
    }

    public void ShowConfirmation(int index) {
        itemSelectedIndex = index;
        confimationText.text = confirmationMessage + storeItensButtons[index].transform.GetChild(0).GetComponent<TMP_Text>().text;
        store.gameObject.SetActive(false);
        confirmation.gameObject.SetActive(true);
    }

    public void CancelConfirmation() {
        itemSelectedIndex = -1;
        store.gameObject.SetActive(true);
        confirmation.gameObject.SetActive(false);
    }


    private void SetButtonInfo(int index, ItemStore item) {
        storeItensButtons[index].transform.GetChild(0).GetComponent<TMP_Text>().text = item.name;
        storeItensButtons[index].transform.GetChild(1).GetComponent<Image>().sprite = item.itemImage;
        storeItensButtons[index].transform.GetChild(2).GetComponent<TMP_Text>().text = "$" + item.price.ToString();
    }

    public void BuyItem() {
        if(GameManager.instace.money > items[itemSelectedIndex].price && !items[itemSelectedIndex].buyed) {
            GameManager.instace.BuyItem(itemSelectedIndex, items[itemSelectedIndex].price);
            UpdateItensList();
            CloseModal();
        }
        
    }

}
