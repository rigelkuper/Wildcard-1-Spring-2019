using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory_manager : MonoBehaviour
{
    public GameObject medkit_counter;
    public int medkits = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(medkit_counter.GetComponents(typeof(Component)));
        medkit_counter.GetComponent<Text>().text = "x" + medkits;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (CompareTag("medkit"))
        {
            medkits += 1;
            Destroy(col);
        }
    }
}
