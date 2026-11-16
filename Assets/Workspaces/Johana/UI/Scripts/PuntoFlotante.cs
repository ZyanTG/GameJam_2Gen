using UnityEngine;
using TMPro;

// el numerito que sube y desaparece
public class PuntoFlotante : MonoBehaviour
{
    public float velocidad = 150f;
    public float duracion = 0.8f;

    TextMeshProUGUI texto;
    float tiempo = 0;

    void Start()
    {
        texto = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        tiempo = tiempo + Time.unscaledDeltaTime; // unscaled por si el juego esta congelado

        // sube
        transform.position = transform.position + Vector3.up * velocidad * Time.unscaledDeltaTime;

        // se va desvaneciendo
        texto.alpha = 1f - tiempo / duracion;

        if (tiempo >= duracion)
        {
            Destroy(gameObject);
        }
    }
}
