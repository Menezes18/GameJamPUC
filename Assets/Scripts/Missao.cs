using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "misaoData", menuName = "Misao", order = 1)]
public class Missao : ScriptableObject{

    public string text;
    public string scene;
    [Header("Lixeiras")]
    public bool reciclavel
        = false;
    public int Papel;
    public int Plastico;
    public int Vidros;
    public int Metais;
    public int maxErros;

    [Header("Habitates")] 
    public bool habitantes = false;
    
    public int PeixeSkin1;
    public int PeixeSkin2;
    public int PeixeSkin3;
}