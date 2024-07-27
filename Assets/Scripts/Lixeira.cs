using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lixeira : MonoBehaviour{
    
    
    public Reciclavel _reciclavelLixeira;
    public int _acertos;
    public int _erros;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Objeto") && !PlayerManager.instancia.itemMao)
        {
            var lixoScript = other.GetComponent<LixoReciclavel>();

            // Verifica se o objeto já foi processado
            if (!lixoScript.jaProcessado)
            {
                if (lixoScript.reciclavel == _reciclavelLixeira)
                {
                    _acertos++;
                }
                else
                {
                    _erros++;
                }

                // Marca o objeto como processado
                lixoScript.jaProcessado = true;

                // Destrói o objeto
                Destroy(other.gameObject);
            }
        }
    }

}
