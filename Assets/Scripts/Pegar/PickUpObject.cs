using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpObject : MonoBehaviour
{
    public Transform hand; // O ponto na mão do jogador onde o objeto será colocado
    public float pickupRange = 3.0f; // A distância máxima para pegar o objeto
    public Camera playerCamera; 
    public Transform raycastOrigin;
    public int layerchao;
    private GameObject pickedObject = null;
    private PlayerInput playerInput;
    private InputAction pegarAction;
    public Material outline;
    public Material verdadeiro;
    public RaycastHit hit;
    private Renderer _renderer;
    private int playerLayerMask;
    
    private void Awake()
    {
        layerchao = LayerMask.NameToLayer("Objeto");
        playerInput = GetComponent<PlayerInput>();
        pegarAction = playerInput.actions["OnPegar"];
        playerLayerMask = LayerMask.GetMask("Player");
    }

    private void OnEnable()
    {
        pegarAction.performed += OnPegar;
    }

    private void OnDisable()
    {
        pegarAction.performed -= OnPegar;
    }

    private void OnPegar(InputAction.CallbackContext context)
    {
        Debug.Log("Apertou pegou");
        if (pickedObject == null)
        {
            TryPickUpObject();
        }
        else
        {
            DropObject();
        }
    }

    private void Update()
    {
        // if (Physics.Raycast(raycastOrigin.position, playerCamera.transform.forward, out hit, pickupRange, ~playerLayerMask))
        // {
        //     if (hit.transform.gameObject.layer == layerchao)
        //     {
        //         _renderer = hit.transform.GetComponent<Renderer>();
        //         if (_renderer != null)
        //         {
        //             verdadeiro = _renderer.material;
        //             _renderer.material = outline;
        //         }
        //     }
        // }
        // else
        // {
        //     if (verdadeiro != null)
        //     {
        //         _renderer.material = verdadeiro;
        //     }
        // }
    }

    void TryPickUpObject()
    {
        if (Physics.Raycast(raycastOrigin.position, playerCamera.transform.forward, out hit, pickupRange, ~playerLayerMask))
        {
            Debug.Log(hit.transform.gameObject.name);
            if (hit.transform.gameObject.layer == layerchao)
            {
                Debug.Log(hit.transform.gameObject.name);
                pickedObject = hit.collider.gameObject;
                pickedObject.transform.SetParent(hand);
                pickedObject.transform.localPosition = Vector3.zero;
                pickedObject.transform.localRotation = Quaternion.identity;

                Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                }

                Collider col = pickedObject.GetComponent<Collider>();
                if (col != null)
                {
                    col.enabled = false;
                }
            }
        }
    }

    void DropObject()
    {
        if (pickedObject != null)
        {
            Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }

            Collider col = pickedObject.GetComponent<Collider>();
            if (col != null)
            {
                col.enabled = true;
            }

            pickedObject.transform.SetParent(null);
            pickedObject = null;
        }
    }

    void OnDrawGizmos()
    {
        if (raycastOrigin != null && playerCamera != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(raycastOrigin.position, raycastOrigin.position + playerCamera.transform.forward * pickupRange);
            Gizmos.DrawSphere(raycastOrigin.position + playerCamera.transform.forward * pickupRange, 0.1f);
        }
    }
}
