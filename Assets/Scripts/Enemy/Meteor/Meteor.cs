using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Enemy
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    private float speed;
    [SerializeField] private float rotateSpeed;

    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rb.velocity = Vector3.down * speed;
    }
    private void Update()
    {
        transform.Rotate(0,0,rotateSpeed*Time.deltaTime);
    }
    public override void HurtsSequence()
    {
        
    }
    public override void DeathSequence()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();

            playerStats.PlayerTakeDamage(damage);

            Instantiate(explosionPrefab, transform.position, Quaternion.identity); // player a çarpýnca da patlama animasyonu


            Destroy(gameObject);

        }
            
    }
    private void OnBecameInvisible() // kamera kadrajýndan çýktýðýnda gameobjeleri siliyor
    {
        Destroy(gameObject);  
        
    }
}
