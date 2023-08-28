using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GreenEnemy : Enemy
{

    [SerializeField] private float speed;

    private void Start()
    {
        rb.velocity = Vector2.down * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().PlayerTakeDamage(damage);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    public override void DeathSequence()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    public override void HurtsSequence()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Dmg")) // means anim is running
            return;

        anim.SetTrigger("Damage");
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}



