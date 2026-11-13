using UnityEngine;
using UnityEngine.InputSystem;

public class SelectedTarget : MonoBehaviour
{
    public ParticleSystem  particleSystem;


   private GameManager gameManager;

    public int pointValue; // Variable para marcar los puntos
    // Start is called once before the first execution of Update after the MonoBehaviour is create
    
    void Awake()
    {
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
   

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame) //I detected the mouse left button
        {
            Debug.Log("Mouse was pressed ");
            Ray ray =  Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()); //I coverted the camera cordinated to world cordinates
            Debug.DrawRay(ray.origin,ray.direction*100f,Color.blue,2f);//Drawing a new ray or line
            //Al parecer los raycast se usanpara detectar colisiones en 3d usando el ratón
            if (Physics.Raycast(ray, out RaycastHit hit))// Que significa ese out
            {
                if(hit.transform == transform)
                {
                    Instantiate(particleSystem,transform.position,particleSystem.transform.rotation);
                   gameManager.UpdateScore(pointValue);
                    Destroy(gameObject);
                }
            }
    }
}
}
