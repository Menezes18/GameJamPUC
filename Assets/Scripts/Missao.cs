using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "misaoData", menuName = "Misao", order = 1)]
public class Missao : ScriptableObject
{
    public Dictionary<Reciclavel, int> requisitos;
    public int Papel;
    public int Plastico;
    public int Vidros;
    public int Metais;
    public int maxErros;
    public Missao()
    {
        requisitos = new Dictionary<Reciclavel, int>();
    }
}