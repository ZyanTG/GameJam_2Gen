using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections;

// HUD: puntaje, barrita de tiempo y aviso de mundo corrupto
public class HUDJuego : MonoBehaviour
{
    [Header("cosas de Richard (no tocar sus scripts)")]
    public TextMeshProUGUI scoreRichard; // el texto que dice "Score: 0"
    public GameObject fondoNormal;       // Background1

    [Header("mi UI")]
    public TextMeshProUGUI textoPuntaje;
    public Image barra;      // fondo de la barra (trae el sol o la alerta)
    public Image relleno;    // lo verde que se va vaciando
    public GameObject avisoCorrupto;
    public GameObject vineta;
    public EfectoGlitch glitch;
    public AudioManager audioManager; // el de ana

    [Header("imagenes dia / corrupto")]
    public Sprite barraDia;
    public Sprite barraCorrupto;
    public Sprite rellenoDia;
    public Sprite rellenoCorrupto;

    [Header("numerito al hacer clic (estan apagados)")]
    public TextMeshProUGUI numeritoSuma;   // verde
    public TextMeshProUGUI numeritoResta;  // rojo

    public float tiempoMaximo = 20f; // richard cambia el mundo entre 5 y 20 seg
    public int puntaje = 0;

    bool estabaCorrupto = false;
    float tiempo = 0;
    int puntajeAnterior = 0;

    void Start()
    {
        avisoCorrupto.SetActive(false);
        vineta.SetActive(false);
        estabaCorrupto = !fondoNormal.activeSelf;

        // sonido del mundo normal al empezar
        if (audioManager != null)
        {
            audioManager.PlayWhiteWorldAmbience();
        }
    }

    void Update()
    {
        LeerPuntaje();

        // si ya toco la bomba la barra se queda quieta
        if (SelectedTarget.touchBomb)
        {
            return;
        }

        // si el fondo normal se apaga es porque estamos en el mundo corrupto
        bool corrupto = !fondoNormal.activeSelf;
        if (corrupto != estabaCorrupto)
        {
            estabaCorrupto = corrupto;
            tiempo = 0;
            CambiarMundo(corrupto);
        }

        // la barrita se va vaciando
        tiempoMaximo = ChageBackground.randomNum;//agregado el tiempo para que sea aleatorio
        tiempo = tiempo + Time.deltaTime;
        float lleno = 1f - tiempo / tiempoMaximo;
        if (lleno < 0.08f)
        {
            lleno = 0.08f; // para que no se vea aplastada
        }
        relleno.rectTransform.anchorMax = new Vector2(lleno, 1);
    }

    public int LeerPuntaje()
    {
        // le quito el "Score: " al texto de richard y me quedo con el numero
        string numero = scoreRichard.text.Replace("Score: ", "");
        int.TryParse(numero, out puntaje);

        // 1250 -> 1.250
        textoPuntaje.text = puntaje.ToString("#,0").Replace(",", ".");

        // si cambio el puntaje saco el numerito
        if (puntaje != puntajeAnterior)
        {
            SacarNumerito(puntaje - puntajeAnterior);
            puntajeAnterior = puntaje;
        }
        return puntaje;
    }

    void SacarNumerito(int cuanto)
    {
        TextMeshProUGUI plantilla = numeritoSuma;
        string texto = "+" + cuanto;
        if (cuanto < 0)
        {
            plantilla = numeritoResta;
            texto = cuanto.ToString(); // ya trae el -
        }

        // copio el numerito que esta apagado
        TextMeshProUGUI numerito = Instantiate(plantilla, plantilla.transform.parent);
        numerito.gameObject.SetActive(true);
        numerito.text = texto;
        numerito.transform.position = Mouse.current.position.ReadValue(); // donde hice clic
        numerito.gameObject.AddComponent<PuntoFlotante>();
    }

    void CambiarMundo(bool corrupto)
    {
        if (corrupto)
        {
            barra.sprite = barraCorrupto;
            relleno.sprite = rellenoCorrupto;
            StartCoroutine(MostrarAviso());
            if (audioManager != null)
            {
                audioManager.PlayWorldGlitch(); // el sonido de ana para el mundo malo
                audioManager.PlayDarkWorldAmbience();
            }
        }
        else
        {
            barra.sprite = barraDia;
            relleno.sprite = rellenoDia;
            if (audioManager != null)
            {
                audioManager.PlayWhiteWorldAmbience();
            }
        }

        vineta.SetActive(corrupto);
        glitch.Lanzar();
    }

    IEnumerator MostrarAviso()
    {
        avisoCorrupto.SetActive(true);
        yield return new WaitForSeconds(2f);
        avisoCorrupto.SetActive(false);
    }
}
