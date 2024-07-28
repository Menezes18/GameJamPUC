using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCharacter : MonoBehaviour {

    public GameObject movTargetPosition;
    [SerializeField] private float stopDistance = 2f;
    [SerializeField] private float speed = 20f;
    public Missao _missao;
    private bool isMoving = false;
    public Animator _animation;
    public float yPosition;
    public DialogueSystem _DialogueSystem;
    public FishLine fishLine;

    private void Start(){
        fishLine = FindObjectOfType<FishLine>();
    }

    private void Update() {
        // Calcula a distância entre o NPC e o alvo de movimento
        float distanceToTarget = Vector3.Distance(movTargetPosition.transform.position, transform.position);
    
        // Verifica se o NPC está em movimento
        bool isCurrentlyMoving = distanceToTarget > stopDistance;
    
        // Se o NPC está se movendo
        if (isCurrentlyMoving) {
            // Move o NPC em direção ao alvo
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, movTargetPosition.transform.position, step);
        
            _animation.SetBool("Andando", true);
            // Example: LookAt but only rotate around the Y axis
            Vector3 lookDirection = movTargetPosition.transform.position - transform.position;
            lookDirection.y = yPosition; // Zero out the y-axis to prevent tilting
            transform.rotation = Quaternion.LookRotation(lookDirection);
            _DialogueSystem.Desativar();
        } else {
            _animation.SetBool("Andando", false);
            Vector3 lookDirection = movTargetPosition.transform.position - transform.position;
            lookDirection.z = -90; // Zero out the y-axis to prevent tilting
            
            transform.rotation = Quaternion.LookRotation(lookDirection);
            if (IsFirstInLine()) {
               _DialogueSystem.Iniciar();
            }
            else{
                //_DialogueSystem.Desativar();
            }
            
        }
    
        isMoving = isCurrentlyMoving;
    }

    public bool IsFirstInLine() {
        if (fishLine != null && fishLine.fishes.Count > 0) {
            return fishLine.fishes[0] == this.gameObject;
        }
        return false;
    }

    public void IniciarMissao(){
        if (_missao == null) {
            Debug.LogError("_missao é nulo. Certifique-se de que está corretamente configurado.");
            return;
        }
        QuestManager.instancia.IniciarFase(_missao);
    }

    public void SetTarget(GameObject pos) {
        movTargetPosition = pos;
        isMoving = true;
    }
    
    public void CompleteRequest() {
        Destroy(gameObject, 1f);
    }
}
