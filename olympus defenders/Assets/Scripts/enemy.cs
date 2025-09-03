using UnityEngine;
using UnityEngine.UI; 

public class Enemy : MonoBehaviour
{
    public float startspeed = 10f; // starting speed of enemy

    [HideInInspector]
    public float speed;//   current speed of enemy
    public float startHealth = 100; // starting health of enemy
    private float health; // current health of enemy
    public int value = 50; // amount of money player gets from killing this enemy

    private Transform target;
    private int wavepointIndex = 0;

[Header("unity stuff")]
public Image healthBar;

    void Start()
    {
        target = Waypoint.points[0]; // sets target to the first waypoint
        health = startHealth; // sets current health to starting health
    }

    public void TakeDamage(float damage) // function to handle enemy taking damage
    {
        
        Debug.Log($"Enemy takes {damage} amount. Health before: {health}");
        health -= damage; // subtracts damage from current health

        healthBar.fillAmount = health / startHealth;
        
        Debug.Log($"Enemy health now: {health}");
        if (health <= 0) // if health is less than or equal to 0 enemy dies
        {
            Die();
        }
    }

    void Die() // function to handle enemy death
    {
        PlayerStats.Money += value;
        Destroy(gameObject);
    }

    void Update() // Unity automatically calls Update every frame
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint() // function to set the next waypoint as the target
    {
        if (wavepointIndex >= Waypoint.points.Length - 1)
        {
            EndPath();
            return; // Important: prevent errors by stopping further execution
        }

        wavepointIndex++;
        target = Waypoint.points[wavepointIndex];
    }

    void EndPath() // function to handle what happens when enemy reaches the end of the path
    {
        PlayerStats.Lives--; // decreases player lives by 1
        Destroy(gameObject);
    }

}