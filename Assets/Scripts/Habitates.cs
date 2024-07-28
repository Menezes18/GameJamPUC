using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habitates : MonoBehaviour
{
    public bool habitates = false;
    public SkinPeixe _SkinPeixe;
    public int peixes;
    private Collider myCollider;
    private List<Transform> movedObjects = new List<Transform>();

    private void Awake()
    {
        myCollider = GetComponent<Collider>();
    }

    private void Update(){
        peixes = movedObjects.Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        FishMovement fishMovement = other.GetComponent<FishMovement>();
        if (fishMovement != null && _SkinPeixe == fishMovement._skinPeixe)
        {
            if (!movedObjects.Contains(other.transform)){
                var fish = other.GetComponent<FishMovement>();
                movedObjects.Add(other.transform);
                
                MoveToRandomPositionWithinCollider(other.transform, fish);
            }

            habitates = true;

            if (other.GetComponent<Rigidbody>())
            {
                var rb = other.GetComponent<Rigidbody>();

                if (rb != null)
                {
                     rb.isKinematic = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        FishMovement fishMovement = other.GetComponent<FishMovement>();
        if (fishMovement != null && _SkinPeixe == fishMovement._skinPeixe)
        {
                
            if (other.GetComponent<Rigidbody>())
            {
                var rb = other.GetComponent<Rigidbody>();
                if (rb != null)
                {
                     rb.isKinematic = false;
                }
            }

            // Remover da lista de objetos movidos ao sair do gatilho
            //movedObjects.Remove(other.transform);
        }
    }

    private void MoveToRandomPositionWithinCollider(Transform objTransform, FishMovement fishMovement)
    {
        Debug.Log("TESTE1");
        Vector3 randomPosition = GetRandomPositionWithinCollider(myCollider,fishMovement);
        objTransform.position = randomPosition;
    }

    private Vector3 GetRandomPositionWithinCollider(Collider collider, FishMovement fishMovement)
    {
        Vector3 min = collider.bounds.min;
        Vector3 max = collider.bounds.max;

        fishMovement.movimenta = true;
        return new Vector3(
            UnityEngine.Random.Range(min.x, max.x),
            UnityEngine.Random.Range(min.y, max.y),
            UnityEngine.Random.Range(min.z, max.z)
        );

    }
}
