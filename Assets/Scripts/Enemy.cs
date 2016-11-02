using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    public int health = 100;
    public int worth = 50;

    public GameObject deathEffect;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
        target = Waypoints.waypoints[waypointIndex];
        waypointIndex++;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.Money += worth;

        GameObject effectGO = (GameObject)Instantiate(deathEffect, gameObject.transform.position, Quaternion.identity);        
        
        Destroy(effectGO, 5f);
        Destroy(gameObject);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);

        if (transform.position == target.position)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex > Waypoints.waypoints.Length - 1)
        {
            HitPlayer();
            return;
        }

        target = Waypoints.waypoints[waypointIndex];
        waypointIndex++;
    }

    void HitPlayer()
    {
        PlayerStats.TakeDamage();
        Destroy(gameObject);
    }
}
