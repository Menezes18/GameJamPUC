using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{
    [SerializeField] private float timeClosing = 2f;
    [SerializeField] private float maxValveDistance = 5f;
    [SerializeField] private GameObject[] prefabToxic;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float returnSpeed;

    private bool isTurning = false;
    private bool isClosed = false;
    private Quaternion initialRotation;
    private bool isPlayerLooking = false;
    private bool isMouseDown = false;
    private float rotationProgress = 0f;

    private void Start()
    {
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        CheckPlayerLooking();

        if (isMouseDown && isPlayerLooking)
        {
            RotateValve();
        }
        else if (!isMouseDown || !isPlayerLooking)
        {
            ReturnToInitialRotation();
        }
    }

    private void RotateValve()
    {
        rotationProgress += rotationSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(1, 0, 0) * rotationSpeed * Time.deltaTime);

        if (rotationProgress >= 360f)
        {
            rotationProgress = 0f;
            isClosed = true;
            isTurning = false;
            CloseValve();
        }
    }

    private void ReturnToInitialRotation()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, initialRotation, returnSpeed * Time.deltaTime);
        if (transform.rotation == initialRotation)
        {
            rotationProgress = 0f;
            isTurning = false;
        }
    }

    private void CheckPlayerLooking()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxValveDistance))
        {
            isPlayerLooking = hit.transform == transform;
        }
        else
        {
            isPlayerLooking = false;
        }
    }

    private void OnMouseDown()
    {
        if (!isClosed)
        {
            isMouseDown = true;
        }
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
    }

    private void CloseValve()
    {
        foreach (var prefab in prefabToxic)
        {
            prefab.SetActive(false);
        }

        Debug.Log("Valve closed");
    }
}
