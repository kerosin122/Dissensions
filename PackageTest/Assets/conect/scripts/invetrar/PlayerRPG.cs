using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnCollisionDetector : MonoBehaviour
{
    public GameObject panel;
    
    private float timeScale;

    private void Awake()
    {
        timeScale = Time.timeScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the other collider is an enemy
        if (other.gameObject.CompareTag("Enemy")){
            
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void exit()
   {
        // Check if the other collider is an enemy
       
        
           
            panel.SetActive(false);
            Time.timeScale = timeScale;
        
    }
}