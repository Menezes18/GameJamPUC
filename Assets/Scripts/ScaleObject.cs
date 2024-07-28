using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;


public class ScaleObject : MonoBehaviour
{
    public Transform targetObject;
    public Vector3 maxScale = new Vector3(2, 2, 2); // Valor máximo da escala
    public float duration = 2.0f; // Tempo em segundos para atingir a escala máxima

    void Start()
    {
        StartCoroutine(Scaling(targetObject, maxScale, duration));
    }
    private IEnumerator Scaling(Transform obj, Vector3 targetScale, float duration)
    {
        Vector3 initialScale = obj.localScale;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            obj.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.localScale = targetScale; // Garantir que a escala final seja exatamente a máxima
    }
}
