using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Pig : MonoBehaviour
{
    public Transform target; 
    public float speed = 400;
    public float nextWaypointDistance = 2f;

    private int damage = 35;

    [SerializeField] private GameObject projectilePrefab;



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
            seeker.StartPath(rb.position, target.position + Random.insideUnitSphere * 50f , OnPathComplete); 
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
    void OnTriggerEnter2D(Collider2D collision)
    {

        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            //move a little bit backwards when colliding with player
            rb.AddForce(-transform.up * -500f);
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

        //occasionally shoot a projectile at the player
        if (Random.Range(0, 100) < 1)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = (target.position - transform.position).normalized * 15f;
        }
    }
}
