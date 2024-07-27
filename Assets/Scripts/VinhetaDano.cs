using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;
public class VinhetaDano : MonoBehaviour
{
    private Volume _volume;
    private Vignette _vignette;

    void Start()
    {
        // Obtém o componente Volume
        _volume = GetComponent<Volume>();

        // Verifica se o Volume tem um perfil e tenta obter o componente Vignette
        if (_volume.profile.TryGet<Vignette>(out _vignette))
        {
            // Inicializa o valor da intensidade da Vignette
            _vignette.intensity.value = 0f;
        }
        else
        {
            Debug.LogError("Vignette não encontrada no perfil do Volume.");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ApplyVignetteEffect());
        }
    }

    private IEnumerator ApplyVignetteEffect()
    {
        float targetIntensity = 0.4f;
        float duration = 0.4f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            _vignette.intensity.value = Mathf.Lerp(0f, targetIntensity, elapsed / duration);
            yield return null;
        }

        // Mantém o efeito por um breve período e, em seguida, diminui
        yield return new WaitForSeconds(0.4f);

        while (_vignette.intensity.value > 0)
        {
            _vignette.intensity.value -= 0.01f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
