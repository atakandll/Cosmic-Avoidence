using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LaserBullets : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float damage;
    private ObjectPool<LaserBullets> referencePool;

    private void OnEnable()
    {
        rb.velocity = transform.up * speed;
    }

    public void SetPool(ObjectPool<LaserBullets> pool)
    {
        referencePool = pool;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            
            if(gameObject.activeSelf)
                referencePool.Release(this); //Returns the instance back to the pool.

        }
    }

    public void SetDirectionAndSpeed()
    {
        rb.velocity = transform.up * speed;

    }

    private void OnDisable()
    {
        transform.rotation = Quaternion.Euler(0,0,0 );
    }

    private void OnBecameInvisible()
    {
        if (gameObject == null) return;
        if(gameObject.activeSelf)
            referencePool.Release(this);

    }
}
