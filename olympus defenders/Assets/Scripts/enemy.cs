using UnityEngine;
using UnityEngine.UI; 

public class Enemy : MonoBehaviour
{
    public float startspeed = 10f;

    [HideInInspector]
    public float speed;
    public float startHealth = 100;
    private float health; 
    public int value = 50; // amount of money player gets from killing this enemy

    private Transform target;
    private int wavepointIndex = 0;

[Header("unity stuff")]
public Image healthBar;

    void Start()
    {
        target = Waypoint.points[0];
        health = startHealth;
    }

    public void TakeDamage(float damage)
    {
        
        Debug.Log($"Enemy takes {damage} amount. Health before: {health}");
        health -= damage;
        
        healthBar.fillAmount = health / startHealth;
        
        Debug.Log($"Enemy health now: {health}");
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value;
        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoint.points.Length - 1)
        {
            EndPath();
            return; // Important: prevent errors by stopping further execution
        }

        wavepointIndex++;
        target = Waypoint.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--; // decreases player lives by 1
        Destroy(gameObject);
    }

}