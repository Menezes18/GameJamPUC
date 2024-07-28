using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UiManager : MonoBehaviour{
    public static UiManager instancia;

    private void Awake(){
        instancia = this;
    }

    public GameObject AtivarPeixesUI;
    public TextMeshProUGUI numberPeixe1;
    public TextMeshProUGUI numberPeixe2;
    public TextMeshProUGUI numberPeixe3;
}
