using UnityEngine;
using UnityEngine.UI;
using TMPro;

// volumen de la musica, solo musica no efectos
public class VolumenMusica : MonoBehaviour
{
    public AudioSource musica;
    public Slider slider;
    public TextMeshProUGUI textoPorcentaje; // el "70%"

    void Start()
    {
        // 0.7 = 70% la primera vez
        float volumen = PlayerPrefs.GetFloat("volumenMusica", 0.4f);

        if (musica != null)
        {
            musica.volume = volumen;
        }

        if (slider != null)
        {
            slider.value = volumen;
            slider.onValueChanged.AddListener(CambiarVolumen);
        }
        MostrarPorcentaje(volumen);
    }

    public void CambiarVolumen(float valor)
    {
        if (musica != null)
        {
            musica.volume = valor;
        }
        PlayerPrefs.SetFloat("volumenMusica", valor);
        MostrarPorcentaje(valor);
    }

    void MostrarPorcentaje(float valor)
    {
        if (textoPorcentaje != null)
        {
            textoPorcentaje.text = Mathf.RoundToInt(valor * 100) + "%";
        }
    }
}
