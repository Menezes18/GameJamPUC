using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCharacter : MonoBehaviour {

    public GameObject movTargetPosition;
    [SerializeField] private float stopDistance = 2f;
    [SerializeField] private float speed = 20f;

    private bool isMoving = false;

    private void Update() {
        if (isMoving && Vector3.Distance(movTargetPosition.transform.position, transform.position) > stopDistance) {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, movTargetPosition.transform.position, step);
        } else {
            isMoving = false;
        }
    }

    public void SetTarget(GameObject pos)
    {
        movTargetPosition = pos;
        isMoving = true;
    }
    

    public void CompleteRequest() {
        Destroy(gameObject, 1f);
    }
}
