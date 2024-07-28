using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public float typingSpeed = 0.05f;

    private string fullText;
    private Coroutine typingCoroutine;
    public GameObject balao;
    private bool chamar = true;
    
    private void Start(){
        //Iniciar();
    }

    public void Desativar(){
        balao.SetActive(false);
    }
    public void Iniciar(){
        if (chamar){
        fullText = "Este é um exemplo de diálogo que aparece como uma animação de digitação.";

        // Start the typing animation
        StartTyping();
        chamar = false;
        }
    }

    public void StartTyping()
    {
        balao.SetActive(true);
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(TypeText(fullText));
    }

    private IEnumerator TypeText(string text)
    {
        dialogueText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
