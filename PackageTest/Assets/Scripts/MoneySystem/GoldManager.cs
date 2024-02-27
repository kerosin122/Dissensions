using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class GoldManager : MonoBehaviour
{
    private static GoldManager instance;

     public int startingGold = 100;
    public int currentGold;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentGold = startingGold;
    }

    public void AddGold(int amount)
    {
        currentGold += amount;
    }

    public void SpendGold(int amount)
    {
        if (currentGold >= amount)
        {
            currentGold -= amount;
        }
        else
        {
            Debug.Log("Not enough gold to spend!");
        }
    }

    public int GetCurrentGold()
    {
        return currentGold;
    }
}
 