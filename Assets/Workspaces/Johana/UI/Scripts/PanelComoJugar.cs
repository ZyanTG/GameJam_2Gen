using UnityEngine;

// la ayuda que sale al comienzo del juego
public class PanelComoJugar : MonoBehaviour
{
    public GameObject panelComoJugar;
    public GameObject paredInvisible;

    // static para que se acuerde aunque se reinicie la escena
    static bool yaLoVio = false;

    void Start()
    {
        // si ya lo vio (por ejemplo al darle reintentar) no lo muestro otra vez
        if (yaLoVio)
        {
            panelComoJugar.SetActive(false);
            paredInvisible.SetActive(false);
            Time.timeScale = 1;
            return;
        }

        panelComoJugar.SetActive(true);
        paredInvisible.SetActive(true);
        Time.timeScale = 0; // el juego espera
    }

    // boton A JUGAR
    public void Empezar()
    {
        yaLoVio = true;
        panelComoJugar.SetActive(false);
        paredInvisible.SetActive(false);
        Time.timeScale = 1;
    }
}
