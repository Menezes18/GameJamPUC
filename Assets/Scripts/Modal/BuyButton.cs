using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    private Button button;
    private int itemIndex;
    private StoreMenu storeMenu;

    private void Awake()
    {
        button = GetComponent<Button>();
        storeMenu = FindObjectOfType<StoreMenu>();
    }

    private void Start()
    {
        button.onClick.AddListener(OnBuyButtonClicked);
    }

    public void SetItemIndex(int index)
    {
        itemIndex = index;
    }

    private void OnBuyButtonClicked()
    {
        storeMenu.ShowConfirmation(itemIndex);
    }
}