using UnityEngine;
using UnityEngine.InputSystem;

public class SelectedTarget : MonoBehaviour
{
    public ParticleSystem  particleSystem;


    private GameManager gameManager;
    private Rigidbody rigidbody;

    public static bool touchBomb;
    //Variables for audio
    private AudioManager audioManager;
    
    public int pointValue; // Variable para marcar los puntos
    // Start is called once before the first execution of Update after the MonoBehaviour is create
    
    void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        touchBomb = false;
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    void Start()
    {
        rigidbody.AddForce(Vector3.up*Random.Range(12,15),ForceMode.Impulse);
        rigidbody.AddTorque(0,2,0,ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-8,8),-2,-2);
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
                    
                    if(gameObject.tag == "GoodObject")
                    {
                        audioManager.PlayGoodObjectHit01();
                    }

                    else if (gameObject.tag == "Bomb" )// Terminacion por bomba
                    {
                        audioManager.PlayBombHit();
                        touchBomb = true;
                    }

                    else
                    {
                        audioManager.PlayBadObjectHit();
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
