using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAmmo : MonoBehaviour
{
    public int startingAmmo = 0;
    public int numOfGuns = 4;

    int currentGunIndex;
    List<int> ammo;
    gun_manager playerGuns;
    //int currentAmmo;
    // Start is called before the first frame update
    void Start()
    {
        //currentAmmo = startingAmmo;
        ammo = new List<int>();
        playerGuns = GetComponent<gun_manager>();
        currentGunIndex = playerGuns.current_index;

        for (int i = 0; i < numOfGuns; i++){
            ammo.Add(startingAmmo);
        }
    }

    void Update()
    {
        currentGunIndex = playerGuns.current_index;
    }

    public int getCurrentAmmo()
    {
        return ammo[currentGunIndex];
    }

    public void increaseAmmo(int amount)
    {
        //currentAmmo += amount;
        ammo[currentGunIndex] += amount;
    }

    public void decreaseAmmo(int amount)
    {
        if ((ammo[currentGunIndex] - amount) <= 0){
            ammo[currentGunIndex] = 0;
        } else {
            ammo[currentGunIndex] -= amount;
        }
    }
}
