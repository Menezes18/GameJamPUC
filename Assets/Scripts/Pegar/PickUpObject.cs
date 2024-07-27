using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpObject : MonoBehaviour
{
    public Transform hand; 
    public float pickupRange = 3.0f; 
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
    public float _distancia = 10;
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
        
        if (pickedObject == null)
        {
            TryPickUpObject();
        }
        else{
            if (hit.collider.transform.GetComponent<ArrumarSub>()){
                var arrumar = hit.collider.transform.GetComponent<ArrumarSub>();
                var objeto = GetItemInHandName();
                var scripitem = objeto.GetComponent<Item>();
                if (scripitem.item == arrumar._ItemData){
                    Debug.Log("Esta certo");
                    arrumar.Arrumar();
                    Destroy(objeto);
                }
                else{
                    Debug.Log("Errado");
                }

            }
            else{
                DropObject();
                
            }
            
        }
    }

    private void Update(){
        VerificarRaycast();
        
        
    }

    private ArrumarSub _arrumarSub;
    public void VerificarRaycast(){
        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;
        // if (Physics.Raycast(raycastOrigin.position, playerCamera.transform.forward, out hit, pickupRange, ~playerLayerMask))
        if (Physics.Raycast(ray, out hit, _distancia, ~playerLayerMask)){
            if (hit.collider.transform.GetComponent<ArrumarSub>()){
                _arrumarSub = hit.collider.transform.gameObject.GetComponent<ArrumarSub>();
                
            }else if (_arrumarSub != null){
                
            }
        }
    }
    GameObject GetItemInHandName()
    {
        if (hand.childCount > 0)
        {
            return hand.GetChild(0).gameObject;
        }
        return null;
    }
    void TryPickUpObject()
    {
        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;
       // if (Physics.Raycast(raycastOrigin.position, playerCamera.transform.forward, out hit, pickupRange, ~playerLayerMask))
        if (Physics.Raycast(ray, out hit, _distancia, ~playerLayerMask)) {
        
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
        }
    }
}
