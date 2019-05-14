using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float maxHealth = 10;
    public float damageAmount = 1;

    //char_health enemyHealth;
    float currentHealth;
    void Start()
    {
        //enemyHealth = GetComponent<char_health>();
        //enemyHealth.setHealth(maxHealth);
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == 0){
            killEnemy();
        }
    }

    public float getHealth()
    {
        return currentHealth;
    }

    public void damageEnemy(float amount)
    {
        decraseHealth(amount);
    }

    public void killEnemy()
    {
        Debug.Log("Enemy killed!");
        Destroy(gameObject);
    }

    void decraseHealth(float amount)
    {
        if (currentHealth - amount <= 0){
            currentHealth = 0;
        } else {
            currentHealth -= amount;
        }
    }



}
