using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparency : MonoBehaviour
{
    private SpriteRenderer Renderer;

    private Color defaultColor;
    private Color fadedColor;

    public float alpha;

    // Start is called before the first frame update
    void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();

        defaultColor = Renderer.color;
        fadedColor = defaultColor;
        fadedColor.a = alpha;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Renderer.color = fadedColor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Renderer.color = defaultColor;
        }
    }

}
