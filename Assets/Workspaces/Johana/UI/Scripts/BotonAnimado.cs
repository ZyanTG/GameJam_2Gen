using UnityEngine;
using UnityEngine.EventSystems;

// el boton se agranda un poquito cuando paso el mouse
// y suena el clic del audio manager de ana
public class BotonAnimado : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public float grande = 1.08f;

    Vector3 tamanoNormal;
    Vector3 tamanoQueQuiero;

    void Start()
    {
        tamanoNormal = transform.localScale;
        tamanoQueQuiero = tamanoNormal;
    }

    void Update()
    {
        // uso unscaled para que funcione en pausa tambien
        transform.localScale = Vector3.Lerp(transform.localScale, tamanoQueQuiero, 12f * Time.unscaledDeltaTime);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tamanoQueQuiero = tamanoNormal * grande;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tamanoQueQuiero = tamanoNormal;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // busco el audio manager que este en la escena
        AudioManager audio = FindFirstObjectByType<AudioManager>();
        if (audio != null)
        {
            audio.PlayUIClick();
        }
    }
}
