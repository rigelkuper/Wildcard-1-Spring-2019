using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory_manager : MonoBehaviour
{
    public GameObject medkit_counter;
    public int medkits = 0;
    public GameObject player;
    public GameObject selector;
    private int index = 0;
    public float y_val = 55f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //binoculars that change camera zoom
        //energy drink that changes player speed/rotation speed

        medkit_counter.GetComponent<Text>().text = "x" + medkits;

        if (Input.GetButtonDown("change_item"))
        {
            index += 1;
            if (index >= 3)
            {
                index = 0;
            }
        }
        if (Input.GetButtonDown("use_item"))
        {
            UseItem();
        }
        MoveSelector();

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("medkit"))
        {
            medkits += 1;
            Destroy(col.gameObject);
        }
    }
    public void UseItem()
    {
        if ((index == 0) && (medkits > 0))
        {
            medkits -= 1;
            playerLife heal = player.transform.GetComponent<playerLife>();
            heal.healPlayer(5);
        }
    }
    public void MoveSelector()
    {
        //105
        //1 = 47
        //2 = -16
        
        if (index == 0)
        {
            y_val = 275f;
        }
        if (index == 1)
        {
            y_val = 165.5f;
        }
        if (index == 2)
        {
            y_val = 75.6f;
        }
        //Debug.Log(selector.GetComponent<RectTransform>().localPosition);
        //selector.GetComponent<RectTransform>().SetPositionAndRotation(new Vector3(27.3f, y_val, 0.0f), new Quaternion(0.0f, 0.0f, 0.7f, 0.7f));
        // selector.GetComponent<RectTransform>().InverseTransformVector(new Vector3(27.3f, y_val, 0.0f));
        selector.GetComponent<RectTransform>().position = new Vector3(34.8f, y_val, 0.0f);
    }
}
