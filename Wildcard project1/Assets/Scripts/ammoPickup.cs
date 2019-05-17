using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoPickup : MonoBehaviour
{
    public int increaseAmount = 5;

    bool pickedUp;

    void Start()
    {
        pickedUp = false;
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player" && pickedUp == false){
            //Debug.Log("Player touched ammo pickup");
            other.gameObject.GetComponent<playerAmmo>().increaseAmmo(increaseAmount);
            pickedUp = true;
            Destroy(gameObject);
        }

    }
}
