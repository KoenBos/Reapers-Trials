using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target; 
    public float speed = 400;
    public float nextWaypointDistance = 2f;

    public int damage = 30;

    Path path;
    int currentWaypoint = 0;

    Seeker seeker;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>(); 
        
        InvokeRepeating("UpdatePath", 0f, .5f);

        target = GameObject.Find("Player").transform;
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete); 
        }
        
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            //move a little bit backwards when colliding with player
            rb.AddForce(-transform.up * 300f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null) 
            return;
        
        if (currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }
        else 
        {
            //do nothing
        }
        
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++; 
        }

        // Get the current velocity of the enemy
        //Vector2 currentVelocity = rb.velocity;

        // Calculate the angle between the velocity and the horizontal axis
       // float angle = Mathf.Atan2(currentVelocity.y, currentVelocity.x) * Mathf.Rad2Deg - 90f;

        // Rotate the enemy towards the calculated angle
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
