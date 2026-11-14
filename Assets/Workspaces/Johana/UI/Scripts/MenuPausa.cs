using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// pausa con Esc o con el boton
public class MenuPausa : MonoBehaviour
{
    public GameObject panelPausa;
    public GameObject panelComoJugar;
    public GameObject panelGameOver;

    // truco: pared invisible delante de la camara
    // asi el raycast de richard no toca objetos mientras esta en pausa
    public GameObject paredInvisible;

    public string escenaMenu = "Titulo";

    bool pausado = false;

    void Start()
    {
        panelPausa.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            // si esta la ayuda o el game over no hago nada
            if (panelComoJugar.activeSelf || panelGameOver.activeSelf)
            {
                return;
            }

            if (pausado)
            {
                Continuar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Pausar()
    {
        pausado = true;
        panelPausa.SetActive(true);
        paredInvisible.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continuar()
    {
        pausado = false;
        panelPausa.SetActive(false);
        paredInvisible.SetActive(false);
        Time.timeScale = 1;
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1;
        SelectedTarget.touchBomb = false;
        SpawnManager.watingTime = 1f; // lo dejo como al inicio
        SceneManager.LoadScene(escenaMenu);
    }
}
