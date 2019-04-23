using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_follow : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float distance;
    private Transform target;

    [SerializeField]
    private bool isTarget;

    // Start is called before the first frame update
    void Start()
    {
        isTarget = false;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTarget)
        {
            var relativePosition = target.position - transform.position;
            var angle = Mathf.Atan2(relativePosition.y, relativePosition.x) * Mathf.Rad2Deg - 90;
            var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = rotation;
        }
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Vector2.Distance(transform.position, target.position) > distance)
            {
                isTarget = true;
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }

        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        isTarget = false;
    }
}
