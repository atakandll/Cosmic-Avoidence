using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSpaceShipEnemy : Enemy
{
   
    [SerializeField] private float speed;
    private float shootTimer = 0;
    [SerializeField] private float shootInterval;

    [SerializeField] private Transform leftCanon;
    [SerializeField] private Transform rightCanon;
    [SerializeField] private Transform middleCanon;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private PlayerData _playerData;


    private void Start()
    {
        rb.velocity = Vector2.down * speed;
    }
    private void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            Instantiate(bulletPrefab, leftCanon.position, Quaternion.identity);
            Instantiate(bulletPrefab, rightCanon.position, Quaternion.identity);
            Instantiate(bulletPrefab, middleCanon.position, Quaternion.identity);
            
            shootTimer = 0;
        }
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
        base.DeathSequence();
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        
        if (_playerData != null)
        {
            _playerData.SpawnPowerUp(transform.position); // space oldukten sonra herhangi ekleyecegimiz gameObject spawnlıyor
        }
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
