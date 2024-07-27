using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour {

    [SerializeField] private float timeClosing = 2f;
    [SerializeField] private float maxValveDistance = 5f;
    private bool isTurning = false;
    private bool isClosed = false;

    [SerializeField] private float rotationSpeed;

   private void Update() {
    if (isTurning) {
        transform.Rotate(new Vector3(1,0,0) * rotationSpeed * Time.deltaTime);
    }
   }
    private void OnMouseDown() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit; 

        if (Physics.Raycast(ray, out hit, maxValveDistance)) {
                if (hit.transform == transform && !isClosed) {
                    StartCoroutine("StartClosing");
                }
            }
    }

    private IEnumerator StartClosing() {
        isTurning = true;
        yield return new WaitForSeconds(timeClosing);
        CloseValve();
    }


    private void CloseValve() {
        isTurning = false;
        isClosed = true;
        Debug.Log("valve close");
    }

}
