using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;


public class SpawnManager : MonoBehaviour
{

    public List <GameObject> objetos;
    public float watingTime = 1f;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(watingTime);
            
            int myIndex = Random.Range(0,objetos.Count);
            Instantiate(objetos[myIndex],new Vector3(Random.Range(-9f,9f),Random.Range(-4f,5.5f),objetos[myIndex].transform.position.z),objetos[myIndex].transform.rotation);
            //UpdateScore(1);
        }
        
    }
    public void StartGame()
    {
        StartCoroutine(SpawnObjects());
       
    }


}
