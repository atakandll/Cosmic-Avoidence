using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    [SerializeField] private float damage;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = Vector2.down * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().PlayerTakeDamage(damage);
            Destroy(gameObject);    
        }
    }
    private void OnBecameVisible()
    {
        Destroy(gameObject);
    }
}
