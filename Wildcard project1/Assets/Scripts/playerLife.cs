// Please let Matthew know if you modify this script.

// Handles player damage, iframes, killing player, etc.
// Make sure to attach char_health component to player object

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLife : MonoBehaviour
{
    public int maxHealth = 20;
    
    char_health playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<char_health>();
        playerHealth.setHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerHealth.getHealth());
        if (playerHealth.getHealth() == 0){
            killPlayer();
        }
    }

    public void damagePlayer(int amount)
    {
        playerHealth.decraseHealth(amount);
    }

    public void healPlayer(int amount)
    {
        int newHealth = playerHealth.getHealth() + amount;
        if (newHealth >= maxHealth){
            playerHealth.setHealth(maxHealth);
        } else {
            playerHealth.setHealth(newHealth);
        }
    }

    public void killPlayer()
    {
        Debug.Log("Player died!");
        Destroy(gameObject);
    }

    
}
