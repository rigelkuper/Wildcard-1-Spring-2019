using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int maxHealth = 10;
    public int damageAmount = 1;

    char_health enemyHealth;
    void Start()
    {
        enemyHealth = GetComponent<char_health>();
        enemyHealth.setHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth.getHealth() == 0){
            killEnemy();
        }
    }

    public void damageEnemy(int amount)
    {
        enemyHealth.decraseHealth(amount);
    }

    public void killEnemy()
    {
        Debug.Log("Enemy killed!");
        Destroy(gameObject);
    }

    /* 
    void onTriggerStay2D(GameObject other)
    {
        Debug.Log("Enemy hit something");
        if (other.tag == "Player"){
            other.GetComponent<playerLife>().damagePlayer(damageAmount);
        }
    }*/
}
