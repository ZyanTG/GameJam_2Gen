using UnityEngine;
using UnityEngine.InputSystem;

public class SelectedTarget : MonoBehaviour
{
    public ParticleSystem  particleSystem;


    private GameManager gameManager;
    private Rigidbody rigidbody;

    public static bool touchBomb;

    
    public int pointValue; // Variable para marcar los puntos
    // Start is called once before the first execution of Update after the MonoBehaviour is create
    
    void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        touchBomb = false;
    }

    void Start()
    {
        rigidbody.AddForce(Vector3.up*Random.Range(12,15),ForceMode.Impulse);
        rigidbody.AddTorque(Random.Range(5,9),Random.Range(5,8),Random.Range(-12,16),ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-9,9),-6,-1);
    }
   

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame) //I detected the mouse left button
        {
          
            Ray ray =  Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()); //I coverted the camera cordinated to world cordinates
            Debug.DrawRay(ray.origin,ray.direction*100f,Color.blue,2f);//Drawing a new ray or line
            //Al parecer los raycast se usanpara detectar colisiones en 3d usando el ratón
            if (Physics.Raycast(ray, out RaycastHit hit))// Que significa ese out
            {
                if(hit.transform == transform)
                {
                    Instantiate(particleSystem,transform.position,particleSystem.transform.rotation);
                    gameManager.UpdateScore(pointValue);
                    if (gameObject.tag == "Bomb" )// Terminacion por bomba
                    {
                        touchBomb = true;
                    }
                    if(GameManager.scorePunt < 0) //Terminacion por puntos 
                    {
                        touchBomb = true;
                    }

                    
                    Destroy(gameObject);
                }
            }
            
    }
}
}
