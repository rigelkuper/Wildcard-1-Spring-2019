using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hurtbox : MonoBehaviour
{
    [SerializeField] int damageAmount = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Hit something");
        if (collision.gameObject.tag == "Player"){
            collision.gameObject.GetComponent<playerLife>().damagePlayer(damageAmount);
        }
    }


}
