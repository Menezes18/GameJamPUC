using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instancia;
    public Missao _missao;
    public int erros;
    public Lixeira[] lixeiras;

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

    public void IniciarFase(Missao missao)
    {
        if (missao.requisitos == null)
        {
            Debug.LogError("missao.requisitos é nulo. Certifique-se de que está corretamente inicializado.");
            return;
        }

        _missao = missao;

        Debug.Log("Iniciou");
        erros = 0;
    }

    public void VerificarItem(Reciclavel reciclavel)
    {
        // Código para verificar o item (mantido igual)
    }

    public void VerificarMissao()
    {
        lixeiras = FindObjectsOfType<Lixeira>();

        bool missaoCorreta = true;

        foreach (var lixeira in lixeiras)
        {
            switch (lixeira._reciclavelLixeira)
            {
                case Reciclavel.Papel:
                    if (lixeira._acertos < _missao.Papel)
                    {
                        missaoCorreta = false;
                    }
                    break;
                case Reciclavel.Plastico:
                    if (lixeira._acertos < _missao.Plastico)
                    {
                        missaoCorreta = false;
                    }
                    break;
                case Reciclavel.Vidros:
                    if (lixeira._acertos < _missao.Vidros)
                    {
                        missaoCorreta = false;
                    }
                    break;
                case Reciclavel.Metais:
                    if (lixeira._acertos < _missao.Metais)
                    {
                        missaoCorreta = false;
                    }
                    break;
            }

            if (!missaoCorreta)
            {
                Debug.Log("Missão está errada!");
                return;
            }
        }

        Debug.Log("Missão está correta!");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            VerificarMissao();
        }
    }
}
