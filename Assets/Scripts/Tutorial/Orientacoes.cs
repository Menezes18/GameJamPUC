using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientacoes : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.gameObject.SetActive(false);
        }
    }
}
