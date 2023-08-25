using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullets : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float damage;

    private void Start()
    {
        rb.velocity = transform.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);

        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
