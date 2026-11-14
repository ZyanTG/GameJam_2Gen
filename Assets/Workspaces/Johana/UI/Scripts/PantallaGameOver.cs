using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// sale cuando tocan la bomba
public class PantallaGameOver : MonoBehaviour
{
    public GameObject panelGameOver;
    public GameObject paredInvisible;
    public HUDJuego hud;
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
        textoRecord.text = record.ToString("#,0").Replace(",", ".");
        panelGameOver.SetActive(true);
        paredInvisible.SetActive(true);
    }

    public void Reintentar()
    {
        SpawnManager.watingTime = 1f; // si no, cada vez sale mas rapido
        SpawnManager spawn = FindFirstObjectByType<SpawnManager>();
        spawn.ResetLevel(); // el reset de richard
    }

    public void IrAlMenu()
    {
        SelectedTarget.touchBomb = false;
        SpawnManager.watingTime = 1f;
        SceneManager.LoadScene(escenaMenu);
    }
}
