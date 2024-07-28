using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    public static GameManager instace;
    public List<ItemStore> items;
    [SerializeField] private GameObject storeModal;


    public float money = 0;




   private void Update() {
      if (Input.GetKeyDown(KeyCode.L)) {
         this.OpenStore();
      }
   }

   private void Start() {
      ResetStore();
   }

    private void Awake() {
        if (instace == null) {
            instace = this;
            DontDestroyOnLoad(this);
        }
        else {
            DestroyImmediate(gameObject);
        }
    }

    public void OpenStore() {
      storeModal.SetActive(!storeModal.activeSelf);
      if (storeModal.activeSelf){
          Cursor.visible = true;
          Cursor.lockState = CursorLockMode.None;
          
      }
      else{
          Cursor.lockState = CursorLockMode.Locked;
          Cursor.visible = false;
          Cursor.lockState = CursorLockMode.Locked;
      }
    }


    public void BuyItem(int index, float price) {
      money-=price;
      items[index].buyed = true;
      items[index].BuyAction();
    }

    private void ResetStore() {
      foreach (ItemStore item in items) {
         item.buyed = false;
      }
    }

    public void GetMoney(float amount) {
      this.money+=amount;
    }
    
    
   // public 
}
