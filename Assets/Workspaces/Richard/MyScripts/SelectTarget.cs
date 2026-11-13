using UnityEngine;
using UnityEngine.InputSystem;
public class SelectTarget : MonoBehaviour
{
    public ParticleSystem particleSystem;
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
                    //gameManager.UpdateScore(pointValue);
                    Destroy(gameObject);
                }
            }
        }
    }
}
