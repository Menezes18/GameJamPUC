using UnityEngine;

public class ObjectThrower : MonoBehaviour
{
    public GameObject objectPrefab; // Prefab do objeto que será arremessado
    public Transform spawnPoint; // Ponto de onde o objeto será arremessado
    public float throwForce = 10f; // Força aplicada ao objeto

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Exemplo: arremessar quando a tecla Espaço é pressionada
        {
            ThrowObject();
        }
    }

    void ThrowObject()
    {
        // Instancia o objeto no ponto de spawn
        GameObject thrownObject = Instantiate(objectPrefab, spawnPoint.position, spawnPoint.rotation);

        // Obtém o Rigidbody do objeto instanciado
        Rigidbody rb = thrownObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Aplica uma força ao Rigidbody para arremessar o objeto
            rb.AddForce(spawnPoint.forward * throwForce, ForceMode.Impulse);
        }
    }
}