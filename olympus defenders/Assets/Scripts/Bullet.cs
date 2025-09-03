using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f; // speed of bullet

    public int damage = 50; // amount of damage bullet does to enemy

    public float explosionRadius = 0f;
    public GameObject impactEffect;

    public void Seek(Transform _target) // function to set the target of the bullet
    {
        target = _target;
    }

    // Unity automatically calls Update every frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget() // function to handle what happens when the bullet hits the target
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (explosionRadius > 0f)
            {
            Explode();
        } else
        {
            Damage(target);
        }
        
        Destroy(gameObject);
    }

    void Explode () // function to handle explosion damage to all enemies in radius
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage (Transform enemy) // function to apply damage to the enemy hit by the bullet
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected() // visualize explosion radius in editor
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
        Gizmos.color = Color.red;
    }
}
