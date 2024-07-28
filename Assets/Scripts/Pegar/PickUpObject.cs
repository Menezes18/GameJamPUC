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
        if (hit.collider != null && hit.collider.transform.GetComponent<FishCharacter>()){
            Debug.Log("Quest");
            var questManager = hit.collider.transform.GetComponent<FishCharacter>();

            questManager.IniciarMissao();
        }

        if (pickedObject == null)
        {
            TryPickUpObject();
        }
        else{
            
            if (hit.collider != null &&hit.collider.transform.GetComponent<ArrumarSub>()){
                var arrumar = hit.collider.transform.GetComponent<ArrumarSub>();
                var objeto = GetItemInHandName();
                var scripitem = objeto?.GetComponent<Item>();
                if (scripitem != null && scripitem.item == arrumar._ItemData){
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
    private AtivarCanvas objCanvas;
    public void VerificarRaycast(){
        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;
        // if (Physics.Raycast(raycastOrigin.position, playerCamera.transform.forward, out hit, pickupRange, ~playerLayerMask))
        if (Physics.Raycast(ray, out hit, _distancia, ~playerLayerMask)){
            if (hit.collider.transform.GetComponent<AtivarCanvas>()){
                objCanvas = hit.collider.transform.GetComponent<AtivarCanvas>();
                objCanvas.canvasObj.SetActive(true);
            }
            else if(objCanvas != null){
                objCanvas.canvasObj.SetActive(false);
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
    void TryPickUpObject(){
        PlayerManager.instancia.itemMao = true;
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

                // Iterate through all children and apply the same modifications
                foreach (Transform child in pickedObject.transform)
                {
                    rb = child.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.isKinematic = true;
                    }

                    col = child.GetComponent<Collider>();
                    if (col != null)
                    {
                        col.enabled = false;
                    }
                }
            }
        }
    }


    void DropObject()
    {
        PlayerManager.instancia.itemMao = false;
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
