using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pc_sprite_manager : MonoBehaviour
{
    public Sprite pistol;
    public Sprite machine_gun;
    public Sprite shotgun;
    public SpriteRenderer sprite_manager;
    void Update()
    {
        if (this.GetComponentInParent<gun_manager>().current_index == 0)
        {
            sprite_manager.sprite = machine_gun;
        }
        if (this.GetComponentInParent<gun_manager>().current_index == 2)
        {
            sprite_manager.sprite = pistol;
        }
        if (this.GetComponentInParent<gun_manager>().current_index == 1)
        {
            sprite_manager.sprite = shotgun;
        }
        
    }
}
