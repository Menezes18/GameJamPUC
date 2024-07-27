using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkinPeixe {
    peixeSkin1,
    peixeSkin2,
    peixeSkin3
}

public class FishMovement : MonoBehaviour {
    public Transform playerTransform;
    public float speed = 5f;
    public float destroyDistance = 1f;
    public bool puxar;
    public float smoothFactor = 100f;
    public SkinPeixe _skinPeixe;
    public float amplitude = 0.5f; 
    public float frequencia = 1f; 
    private Vector3 posicaoInicial;
    public Rigidbody rb;
    public bool movimenta = false;

    private void Start() {
        var player = GameObject.FindWithTag("TranformArma");
        playerTransform = player.transform;
        rb = GetComponent<Rigidbody>();
        posicaoInicial = transform.position;
    }

    private void Update() {
        if (puxar) {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            Vector3 targetPosition = transform.position + direction * speed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.deltaTime);
        }
        
        if (movimenta) {
            
            float newY = posicaoInicial.y + Mathf.Sin(Time.time * frequencia) * amplitude;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, destroyDistance);
    }
}