using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    int scorePunt;
   
    public TextMeshProUGUI score; 

    public GameObject Destructor;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Destructor == null)
        {
            Debug.Log("Juego Finalizado");
        }
    }

    public void UpdateScore(int myScore)
    {
        scorePunt += myScore;
        score.text = "Score: " + scorePunt;
    }

   
    

    
}
