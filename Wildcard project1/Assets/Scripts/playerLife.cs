// Please let Matthew know if you modify this script.

// Handles player damage, iframes, killing player, etc.
// Make sure to attach char_health component to player object

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLife : MonoBehaviour
{
    public int maxHealth = 20;
    public int iFrameSeconds = 3;

    
    char_health playerHealth;
    bool invincible;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<char_health>();
        playerHealth.setHealth(maxHealth);
        invincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerHealth.getHealth());
        if (playerHealth.getHealth() == 0){
            killPlayer();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Hit something");
        if (other.gameObject.tag == "Enemy"){
            damagePlayer(other.gameObject.GetComponent<enemy_controller>().damageAmount);
        }
    }

    public void damagePlayer(int amount)
    {
        if (!invincible){
            playerHealth.decraseHealth(amount);

            if (playerHealth.getHealth() == 0){
                killPlayer();
            } else {
                StartCoroutine(doIFrames());
                StopCoroutine(doIFrames());
            }
        }
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
        //Destroy(gameObject);
    }

    IEnumerator doIFrames(){
        invincible = true;
        yield return new WaitForSeconds(iFrameSeconds);
        invincible = false;
    }

    
}
