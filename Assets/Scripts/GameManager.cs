using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<ItemStore> items;
    [SerializeField] private GameObject storeModal;

    public float money = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            OpenStore();
        }
    }

    private void Start()
    {
        ResetStore();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    public void OpenStore()
    {
        storeModal.SetActive(!storeModal.activeSelf);
        if (storeModal.activeSelf)
        {
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void BuyItem(int index, float price)
    {
        money -= price;
        items[index].bought = true;
        items[index].BuyAction();
    }

    private void ResetStore()
    {
        foreach (ItemStore item in items)
        {
            item.bought = false;
        }
    }

    public void GetMoney(float amount)
    {
        money += amount;
    }
}