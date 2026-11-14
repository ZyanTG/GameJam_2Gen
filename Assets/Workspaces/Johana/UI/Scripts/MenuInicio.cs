using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// botones de la pantalla de inicio, config y creditos
public class MenuInicio : MonoBehaviour
{
    public GameObject panelInicio;
    public GameObject panelConfig;
    public GameObject panelCreditos;
    public TextMeshProUGUI textoRecord;

    public string escenaJuego = "Juego_Prueba"; // cambiar cuando este la escena final

    void Start()
    {
        Time.timeScale = 1;

        // el record se guarda en PlayerPrefs
        int record = PlayerPrefs.GetInt("record", 0);
        textoRecord.text = record.ToString("#,0").Replace(",", "."); // 4800 -> 4.800

        MostrarInicio();
    }

    public void Jugar()
    {
        SceneManager.LoadScene(escenaJuego);
    }

    public void MostrarInicio()
    {
        panelInicio.SetActive(true);
        panelConfig.SetActive(false);
        panelCreditos.SetActive(false);
    }

    public void MostrarConfig()
    {
        panelInicio.SetActive(false);
        panelConfig.SetActive(true);
        panelCreditos.SetActive(false);
    }

    public void MostrarCreditos()
    {
        panelInicio.SetActive(false);
        panelConfig.SetActive(false);
        panelCreditos.SetActive(true);
    }

    public void Salir()
    {
        Debug.Log("salir del juego"); // en el editor no se cierra
        Application.Quit();
    }
}
