using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;


public class ChageBackground : MonoBehaviour
{
    public GameObject background1;
    public GameObject background2;
    public float watingTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeBackground();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBackground()
    {
        StartCoroutine(modifyBackground());
    }
    IEnumerator modifyBackground()
    {

        background1.SetActive(false);
        background2.SetActive(true);
        //while (true)
        //{
            //int randomNum = Random.range(5,10);
            yield return new WaitForSeconds(watingTime);
            /*if (background1.activeSelf)
            {
                background1.SetActive(false);
                background2.SetActive(true);
            }
            else
            {
                background1.SetActive(true);
                background2.SetActive(false);
            }*/
                
       // }
        
        
        //TO set an if where the background1 will be disable and the background2 enabled 
        
    }
}
