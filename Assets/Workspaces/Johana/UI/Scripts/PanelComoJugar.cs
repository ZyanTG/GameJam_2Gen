using UnityEngine;

// la ayuda que sale al comienzo del juego
public class PanelComoJugar : MonoBehaviour
{
    public GameObject panelComoJugar;
    public GameObject paredInvisible;

    void Start()
    {
        panelComoJugar.SetActive(true);
        paredInvisible.SetActive(true);
        Time.timeScale = 0; // el juego espera
    }

    // boton A JUGAR
    public void Empezar()
    {
        panelComoJugar.SetActive(false);
        paredInvisible.SetActive(false);
        Time.timeScale = 1;
    }
}
