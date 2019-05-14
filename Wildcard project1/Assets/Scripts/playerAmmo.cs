using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAmmo : MonoBehaviour
{
    public int startingAmmo = 0;

    int currentAmmo;
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = startingAmmo;
    }

    public int getCurrentAmmo()
    {
        return currentAmmo;
    }

    public void increaseAmmo(int amount)
    {
        currentAmmo += amount;
    }

    public void decreaseAmmo(int amount)
    {
        if ((currentAmmo - amount) <= 0){
            currentAmmo = 0;
        } else {
            currentAmmo -= amount;
        }
    }
}
