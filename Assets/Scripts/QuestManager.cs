using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class QuestManager : MonoBehaviour
{
    public static QuestManager instancia;
    public Missao _missao;
    public int erros;
    public Lixeira[] lixeiras;
    public Habitates[] habitates;

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
        if (missao == null)
        {
            Debug.LogError("A missão fornecida é nula. Certifique-se de que está corretamente inicializada.");
            return;
        }

        _missao = missao;
        if (_missao.habitantes){
            SceneManager.LoadScene(_missao.scene);
        }else if (missao.reciclavel){
            SceneManager.LoadScene(_missao.scene);
        }
        Debug.Log("Iniciou a missão.");
        erros = 0;
    }
    

    public void VerificarMissao()
    {
        if (VerificarConclusaoLixeiras() && VerificarConclusaoHabitates())
        {
            Debug.Log("Missão está correta!");
            PlayerManager.instancia.textPainel("Missão está correta!");
            PlayerManager.instancia.ChamarVfx(1);
            Invoke("ChamarScene", 1f);
            
            
        }
        else{
            PlayerManager.instancia.textPainel("Missão está errada!");
            Debug.Log("Missão está errada!");
        }
    }

    public void ChamarScene(){
        SceneManager.LoadScene("PlaygroundRecuperado");
    }
    private bool VerificarConclusaoLixeiras(){
        if (!_missao.reciclavel)
            return true;
        lixeiras = FindObjectsOfType<Lixeira>();

        foreach (var lixeira in lixeiras)
        {
            switch (lixeira._reciclavelLixeira)
            {
                case Reciclavel.Papel:
                    if (lixeira._acertos < _missao.Papel)
                    {
                        return false;
                    }
                    break;
                case Reciclavel.Plastico:
                    if (lixeira._acertos < _missao.Plastico)
                    {
                        return false;
                    }
                    break;
                case Reciclavel.Vidros:
                    if (lixeira._acertos < _missao.Vidros)
                    {
                        return false;
                    }
                    break;
                case Reciclavel.Metais:
                    if (lixeira._acertos < _missao.Metais)
                    {
                        return false;
                    }
                    break;
            }
        }

        return true;
    }

    private bool VerificarConclusaoHabitates(){
        if (!_missao.habitantes)
            return true;

        habitates = FindObjectsOfType<Habitates>();

        foreach (var habitate in habitates){
            if (habitate._SkinPeixe == SkinPeixe.peixeSkin1){
                if (habitate.peixes >= _missao.PeixeSkin1){
                    Debug.Log("Peixe1 Certo");
                }
                else{
                    return false;
                }
            }
            else if (habitate._SkinPeixe == SkinPeixe.peixeSkin2){
                if (habitate.peixes >= _missao.PeixeSkin2){
                    Debug.Log("Peixe1 Certo");
                }
                else{
                    return false;

                }
            }
            else if (habitate._SkinPeixe == SkinPeixe.peixeSkin3){
                if (habitate.peixes >= _missao.PeixeSkin3){
                    Debug.Log("Peixe1 Certo");
                }
                else{
                    return false;

                }
            }
        }

        return true;
       
}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            VerificarMissao();
        }
    }
}
