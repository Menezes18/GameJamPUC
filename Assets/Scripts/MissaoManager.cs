using System.Collections.Generic;
using UnityEngine;

public class MissaoManager : MonoBehaviour
{
    public static MissaoManager instancia;

    public Missao missaoAtiva;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SelecionarMissao(Missao missao)
    {
        missaoAtiva = missao;
        QuestManager.instancia.IniciarFase(missaoAtiva);
    }
}