// Please let Matthew know if you modify this script.

// Handles player damage, iframes, killing player, etc.
// Make sure to attach char_health component to player object

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour
{
    public float maxHealth = 20;
    public int iFrameSeconds = 1;

    
    //char_health playerHealth;
    bool invincible;
    SpriteRenderer playerSprite;
    float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        invincible = false;
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentHealth);
        if (currentHealth <= 0){
            killPlayer();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("Hit something");
        if (other.gameObject.tag == "Enemy" && !other.isTrigger){
            damagePlayer(other.gameObject.GetComponent<enemy_controller>().damageAmount);
        }
    }

    public float getHealth()
    {
        return currentHealth;
    }

    public void damagePlayer(float amount)
    {
        if (!invincible){
            decreaseHealth(amount);

            if (currentHealth <= 0){
                killPlayer();
            } else {
                StartCoroutine(doIFrames());
                StopCoroutine(doIFrames());
            }
        }
    }

    public void healPlayer(float amount)
    {
        float newHealth = currentHealth + amount;
        if (newHealth >= maxHealth){
            currentHealth = maxHealth;
        } else {
            currentHealth = newHealth;
        }
    }

    public void killPlayer()
    {
        Debug.Log("Player died!");
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        SceneManager.LoadScene("MattGameOver");
    }

    void decreaseHealth(float amount)
    {
        if (currentHealth - amount <= 0){
            currentHealth = 0;
        } else {
            currentHealth -= amount;
        }
    }

    IEnumerator doIFrames(){
        invincible = true;
        playerSprite.color = Color.red;
        yield return new WaitForSeconds(iFrameSeconds);
        playerSprite.color = Color.white;
        invincible = false;
    }
}
