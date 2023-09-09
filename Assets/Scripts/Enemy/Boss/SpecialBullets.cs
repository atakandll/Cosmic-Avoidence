
    using System;
    using System.Collections;
    using UnityEngine;
    using Random = UnityEngine.Random;

    public class SpecialBullets : MonoBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private float speed;
        [SerializeField] private float rotateSpeed;
        private Rigidbody2D rb;

        [SerializeField] private GameObject miniBullet;
        [SerializeField] private Transform[] spawnPoint;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.down * speed;
            StartCoroutine(Expolode());
        }

        private void Update()
        {
            transform.Rotate(0,0,rotateSpeed*Time.deltaTime);
        }

        IEnumerator Expolode()
        {
            float randomExplodeTime = Random.Range(1.5f, 2.5f);
            yield return new WaitForSeconds(randomExplodeTime);

            for (int i = 0; i < spawnPoint.Length; i++)
            {
                Instantiate(miniBullet, spawnPoint[i].position, spawnPoint[i].rotation);

            }
            Destroy(gameObject);
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
