// Please let Matthew know if you modify this script.

// Handles player damage, iframes, killing player, etc.
// Make sure to attach char_health component to player object

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour
{
    public int maxHealth = 20;
    public int iFrameSeconds = 3;
    public string gameOverScene;

    
    char_health playerHealth;
    bool invincible;
    SpriteRenderer playerSprite;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<char_health>();
        playerHealth.setHealth(maxHealth);
        invincible = false;
        playerSprite = GetComponent<SpriteRenderer>();
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
        if (other.gameObject.tag == "Enemy" && !other.isTrigger){
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
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        SceneManager.LoadScene("MattGameOver");
        //Destroy(gameObject);
    }

    IEnumerator doIFrames(){
        invincible = true;
        playerSprite.color = Color.red;
        yield return new WaitForSeconds(iFrameSeconds);
        playerSprite.color = Color.white;
        invincible = false;
    }
    
}
