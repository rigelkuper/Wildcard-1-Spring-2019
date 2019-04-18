// Please let Matthew know if you modify this script.

// Base character health script
// Use this for health of all characters

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class char_health : MonoBehaviour
{

    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
    }

    public int getHealth()
    {
        return currentHealth;
    }

    public void setHealth(int newHealth)
    {
        currentHealth = newHealth;
    }

    public void decraseHealth(int amount)
    {
        if (currentHealth - amount <= 0){
            currentHealth = 0;
        } else {
            currentHealth -= amount;
        }
    }


}
