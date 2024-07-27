using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;

public class ThirdPersonShooterController : MonoBehaviour {

    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private float aimDistance = 100f;

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;
    public int distancia;
    public GameObject[] SkinPeixe;
    public int Peixes;
    public Transform ArmaPeixe;
    public Transform JogarPeixe;
    public float throwForce = 10f;
    private void Awake() {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        

        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, distancia, aimColliderLayerMask)) {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
            
        } else {
            // Se não colidir com nada, coloca o ponto de debug a uma distância definida no ar
            mouseWorldPosition = ray.origin + ray.direction * aimDistance;
            debugTransform.position = mouseWorldPosition;
        }

        if (starterAssetsInputs.aim) {
            
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 13f));
            if (Mouse.current.leftButton.wasReleasedThisFrame) {
                ThrowObject();
            }
            else{
                
            DetectAndDestroyFish();
                if (raycastHit.transform != null && raycastHit.transform.CompareTag("Peixe")){
                    var Fish = raycastHit.transform.gameObject.GetComponent<FishMovement>();
                    if (Fish != null){
                        Debug.Log(raycastHit.transform.gameObject.name);
                        Fish.puxar = true;
                    }
                }
            }

            Vector3 worldAimTarget = mouseWorldPosition;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            // Define aimDirection.y para zero para evitar rotação no eixo X
            aimDirection.y = 0;

            if (aimDirection != Vector3.zero) {
                transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
            }
        } else {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 13f));
        }

        // Detectar e destruir peixes ao contato
    }

    private void DetectAndDestroyFish() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1f);
        foreach (Collider collider in hitColliders) {
            if (collider.CompareTag("Peixe")) {
                Destroy(collider.gameObject);
                Peixes++;
            }
        }
    }
    void ThrowObject(){
        if (Peixes > 0){
            Debug.Log("AA");
            GameObject thrownObject = Instantiate(SkinPeixe[0], JogarPeixe.position, ArmaPeixe.rotation);

             var peixe = thrownObject.GetComponent<FishMovement>();
            
            Rigidbody rb = thrownObject.GetComponent<Rigidbody>();
            if (rb != null){
                Peixes--;
                rb.AddForce(ArmaPeixe.forward * throwForce, ForceMode.Impulse);
                
            }
            
        }
    }
    private void OnDrawGizmosSelected() {
        Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);
        Gizmos.color = transparentRed;
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), 1f);
    }


    
}
