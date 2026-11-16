using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

// sale cuando tocan la bomba
public class PantallaGameOver : MonoBehaviour
{
    public GameObject panelGameOver;
    public GameObject paredInvisible;
    public HUDJuego hud;
    public AudioManager audioManager; // el de ana
    public TextMeshProUGUI textoPuntaje;
    public TextMeshProUGUI textoRecord;
    public string escenaMenu = "Titulo";

    bool yaSalio = false;

    void Start()
    {
        panelGameOver.SetActive(false);
    }

    void Update()
    {
        // touchBomb es la variable de richard
        if (SelectedTarget.touchBomb && !yaSalio)
        {
            yaSalio = true;
            MostrarGameOver();
        }
    }

    void MostrarGameOver()
    {
        int puntaje = hud.LeerPuntaje();
        int record = PlayerPrefs.GetInt("record", 0);

        // nuevo record
        if (puntaje > record)
        {
            record = puntaje;
            PlayerPrefs.SetInt("record", record);
        }

        // 1250 -> 1.250
        textoPuntaje.text = puntaje.ToString("#,0").Replace(",", ".");
        // le pongo la palabra RECORD para que no se confunda con el puntaje
        textoRecord.text = "<size=22><color=#9A6A3A>RÉCORD</color></size> " + record.ToString("#,0").Replace(",", ".");
        panelGameOver.SetActive(true);
        paredInvisible.SetActive(true);
        Time.timeScale = 0; // se congela todo lo de atras (barra, objetos, fondo)

        // paro la musica y suena el game over
        if (audioManager != null)
        {
            audioManager.musicSource.Stop();
            audioManager.PlayGameOver();
        }
    }

    public void Reintentar()
    {
        SpawnManager.watingTime = 1f; // si no, cada vez sale mas rapido
        GameManager.scorePunt = 0;     // richard lo dejo static y no se reinicia solo
        StartCoroutine(Reiniciar());
    }

    IEnumerator Reiniciar()
    {
        yield return new WaitForSecondsRealtime(0.25f); // para que se oiga el clic
        Time.timeScale = 1; // descongelo antes de reiniciar
        SpawnManager spawn = FindFirstObjectByType<SpawnManager>();
        spawn.ResetLevel(); // el reset de richard
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1;
        SelectedTarget.touchBomb = false;
        SpawnManager.watingTime = 1f;
        GameManager.scorePunt = 0;
        StartCoroutine(CargarEscena(escenaMenu));
    }

    // espero un poquito para que se alcance a oir el clic
    // (realtime para que funcione aunque el juego este en pausa)
    IEnumerator CargarEscena(string nombre)
    {
        yield return new WaitForSecondsRealtime(0.25f);
        SceneManager.LoadScene(nombre);
    }
}
