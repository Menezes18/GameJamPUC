using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using TMPro;

public class ModalMenu : MonoBehaviour {

    public void CancelButton() {
        Debug.Log("asdasd");
        gameObject.SetActive(false);
        // Destroy(gameObject);
    }

    public void ConfirmButton() {

        gameObject.SetActive(false);
        // Destroy(gameObject);
    }

    public void CloseModal() {
        Debug.Log("asdasd");
        gameObject.SetActive(false);
    }

}
