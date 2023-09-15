using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : Enemy
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private PlayerData _playerData;

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
        base.DeathSequence();
        Instantiate(explosionPrefab, transform.position, transform.rotation); 
        
        if (_playerData != null)
        {
            _playerData.SpawnPowerUp(transform.position); // spaceShip oldukten sonra herhangi ekleyecegimiz gameObject spawnlıyor
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();

            playerStats.PlayerTakeDamage(damage);

            Instantiate(explosionPrefab, transform.position, Quaternion.identity); // player a �arp�nca da patlama animasyonu


            Destroy(gameObject);

        }
            
    }
    private void OnBecameInvisible() // kamera kadraj�ndan ��kt���nda gameobjeleri siliyor
    {
        Destroy(gameObject);  
        
    }
}

