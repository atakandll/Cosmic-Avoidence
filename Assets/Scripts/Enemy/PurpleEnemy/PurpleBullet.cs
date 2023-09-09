using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBullet : MonoBehaviour
{
     [SerializeField] private float speed;

     [SerializeField] private  Rigidbody2D rb;

    [SerializeField] private float damage;

   

    private void Start()
    {
        rb.velocity = Vector2.down * speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().PlayerTakeDamage(damage);
            Destroy(gameObject);    
        }
    }
    
}
