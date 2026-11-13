using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;


public class SpawnManager : MonoBehaviour
{

    public List <GameObject> objetos;
    public float watingTime = 1f;
    
    private Coroutine coroutine; 

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("la variable es: " + SelectedTarget.touchBomb);
        if (SelectedTarget.touchBomb)
        {
            StopCoroutine(coroutine);
        }
    }

    IEnumerator SpawnObjects()
    {
       
        while (true)
        {

            yield return new WaitForSeconds(watingTime);
            
            int myIndex = Random.Range(0,objetos.Count);
            Instantiate(objetos[myIndex]);
           
        }
        
    }
    public void StartGame()
    {
       coroutine =  StartCoroutine(SpawnObjects());
       
    }


}
