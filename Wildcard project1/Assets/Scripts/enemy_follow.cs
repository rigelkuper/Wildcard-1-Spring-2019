using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_follow : MonoBehaviour
{
    //For moving and following player
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float speed; //speed for zombie
    [SerializeField]
    private float distance; //how far away the zombie should be from the player; just incase the zombie pushes the player
    private Transform target; //the target in which to chase
    [SerializeField]
    private bool follow_player;

    //For the zombie moving around randomly
    [SerializeField]
    private bool idle;
    [SerializeField]
    private Transform move_spots;
    [SerializeField]
    private Transform minX;
    [SerializeField]
    private Transform maxX;
    [SerializeField]
    private Transform minY;
    [SerializeField]
    private Transform maxY;
    private float wait_time; // make private
    [SerializeField]
    private float start_wait_time;
    private Transform last_rotation;

    // Start is called before the first frame update
    void Start()
    {
        //gets the target or the player gameobject
        follow_player = false;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //this is for random movement when not following the player
        idle = true;
        wait_time = start_wait_time;
        move_spots.position = new Vector2(Random.Range(minX.position.x, maxX.position.x), Random.Range(minY.position.y, maxY.position.y));
    }

    // Update is called once per frame
    void Update()
    {
        if (follow_player)
        {
            //zombie rotates towards player
            idle = false;

            //rotates to target position
            FaceTarget(target);
        }
        else if (idle)
        {
            //rotates to target position
            FaceTarget(move_spots);

            //waits(wait_time) until to move to another position
            if (Vector2.Distance(transform.position, move_spots.position) < 0.2f)
            {
                if (wait_time <= 0)
                {
                    move_spots.position = new Vector2(Random.Range(minX.position.x, maxX.position.x), Random.Range(minY.position.y, maxY.position.y));
                    wait_time = start_wait_time;
                }
                else
                {
                    wait_time -= Time.deltaTime;
                }
            }
            else
            {
                //zombie when not following player, goes into idle mode and roams certain area
                transform.position = Vector2.MoveTowards(transform.position, move_spots.position, speed * Time.deltaTime);
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        //follows player if in circle collider
        if (collision.gameObject.tag == "Player")
        {
            idle = false;

            if (Vector2.Distance(transform.position, target.position) > distance)
            {
                follow_player = true;
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }

        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        //when player leaves circle collider, zombie stops following
        follow_player = false;
        idle = true;
    }

    private void FaceTarget(Transform target)
    {
        Vector3 vectorToTarget = target.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
    }

}
