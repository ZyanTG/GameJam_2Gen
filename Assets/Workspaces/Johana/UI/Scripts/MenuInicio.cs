using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

// botones de la pantalla de inicio, config y creditos
public class MenuInicio : MonoBehaviour
{
    public GameObject panelInicio;
    public GameObject panelConfig;
    public GameObject panelCreditos;
    public TextMeshProUGUI textoRecord;
    public AudioManager audioManager; // el de ana

    public string escenaJuego = "Juego_Prueba"; // cambiar cuando este la escena final

    void Start()
    {
        Time.timeScale = 1;

        // el record se guarda en PlayerPrefs
        int record = PlayerPrefs.GetInt("record", 0);
        // 4800 -> 4.800 y la palabra RECORD al lado
        textoRecord.text = "<size=22><color=#9A6A3A>RÉCORD</color></size> " + record.ToString("#,0").Replace(",", ".");

        MostrarInicio();

        // musica del menu
        if (audioManager != null)
        {
            audioManager.PlayMainMenuAmbience();
        }
    }

    public void Jugar()
    {
        // dejo todo en cero antes de empezar (son variables de richard)
        SelectedTarget.touchBomb = false;
        SpawnManager.watingTime = 1f;
        GameManager.scorePunt = 0;
        StartCoroutine(CargarEscena(escenaJuego));
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

    // espero un poquito para que se alcance a oir el clic
    // (realtime para que funcione aunque el juego este en pausa)
    IEnumerator CargarEscena(string nombre)
    {
        yield return new WaitForSecondsRealtime(0.25f);
        SceneManager.LoadScene(nombre);
    }
}
