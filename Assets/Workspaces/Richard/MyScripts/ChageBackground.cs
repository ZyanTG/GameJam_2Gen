using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;


public class ChageBackground : MonoBehaviour
{
    public GameObject background1;
    public GameObject background2;
    public float watingTime;

    private Coroutine coroutine;

    public GameObject gameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeBackground();
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectedTarget.touchBomb)
        {
            StopCoroutine(coroutine);
            gameOver.SetActive(true);
            //Debug.Log("You lose");
        }
    }

    public void ChangeBackground()
    {
        coroutine = StartCoroutine(modifyBackground());
        
    }
    IEnumerator modifyBackground()
    {
        
        /*background1.SetActive(false);
        background2.SetActive(true);*/
        SpawnManager.watingTime = SpawnManager.watingTime*0.1f;
        while (true)
        {
            int randomNum = Random.Range(5,20);
            yield return new WaitForSeconds(randomNum);
            if (background1.activeSelf)
            {
                background1.SetActive(false);
                background2.SetActive(true);
            }
            else
            {
                background1.SetActive(true);
                background2.SetActive(false);
            }
                
        }
        
        
        //TO set an if where the background1 will be disable and the background2 enabled 
        
    }
}
