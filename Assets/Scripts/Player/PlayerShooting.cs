using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private LaserBullets bullets;
    [SerializeField] private float shootingInterval; // ateþ etme aralýðý
    
    [Header("Basic Attacks")]
    [SerializeField] private Transform shootingPoint;

    [Header("Upgrade Points")] [SerializeField]
    private Transform leftCanon;

    [SerializeField] private Transform rightCanon;
    [SerializeField] private Transform secondLeftCanon;
    [SerializeField] private Transform secondRightCanon;

    [Header("Upgrade Rotation Points")] [SerializeField]
    private Transform leftRotationCanon;

    [SerializeField] private Transform rightRotationCanon;
    [SerializeField] private AudioSource source;

    private int upgradeLevel = 0;

    private ObjectPool<LaserBullets> pool;


    private float intervalReset;

    private void Awake()
    {
        pool = new ObjectPool<LaserBullets>(CreatePoolObj, OnTakeBulletFromPool, OnReturnBulletsFromPool,
            OnDestroyPoolObj, true,10,30);
    }

    private void OnDestroyPoolObj(LaserBullets bullets)
    {
        Destroy(bullets.gameObject);
    }

    private LaserBullets CreatePoolObj()
    {
        LaserBullets bullets = Instantiate(this.bullets, transform.position, Quaternion.identity);
        bullets.SetPool(pool);
        return bullets;
    }

    private void OnTakeBulletFromPool(LaserBullets bullets)
    {
        bullets.gameObject.SetActive(true);
    }

    private void OnReturnBulletsFromPool(LaserBullets bullets)
    {
        bullets.gameObject.SetActive(false);        
    }


    private void Start()
    {
        intervalReset = shootingInterval;
        
    }
    private void Update()
    {
        shootingInterval -= Time.deltaTime;

        if(shootingInterval < 0)
        {
            Shoot();
            shootingInterval = intervalReset;
        }
    }

    public void IncreaseUpgrade(int increaseAmount)
    {
        upgradeLevel += 1;
        
        if (upgradeLevel > 4)
            upgradeLevel = 4;
    }

    public void DecraseUpgrade()
    {
        upgradeLevel -= 1;
        if (upgradeLevel < 0)
            upgradeLevel = 0;
    }
    private void Shoot()
    {
        float randomPitch = Random.Range(.1f, 1f);
        source.pitch = randomPitch;
        source.Play();
        switch (upgradeLevel)
        {
            case 0:
                pool.Get().transform.position = shootingPoint.position;
                //Instantiate(bullets, shootingPoint.position,Quaternion.identity);
                break;
            case 1:
                pool.Get().transform.position = leftCanon.position;
                pool.Get().transform.position = rightCanon.position;
                break;
            case 2:
                pool.Get().transform.position = shootingPoint.position;
                pool.Get().transform.position = leftCanon.position;
                pool.Get().transform.position = rightCanon.position;
                break;
            case 3:
                pool.Get().transform.position = shootingPoint.position;
                pool.Get().transform.position = leftCanon.position;
                pool.Get().transform.position = rightCanon.position;
                pool.Get().transform.position = secondLeftCanon.position;
                pool.Get().transform.position = secondRightCanon.position;
                break;
            case 4:
                pool.Get().transform.position = shootingPoint.position;
                pool.Get().transform.position = leftCanon.position;
                pool.Get().transform.position = rightCanon.position;
                pool.Get().transform.position = secondLeftCanon.position;
                pool.Get().transform.position = secondRightCanon.position;

                LaserBullets bullets1 = pool.Get();
                bullets1.transform.position = leftRotationCanon.position;
                bullets1.transform.rotation = leftRotationCanon.rotation;
                bullets1.SetDirectionAndSpeed();

                LaserBullets bullets2 = pool.Get();
                bullets2.transform.position = rightRotationCanon.position;
                bullets2.transform.rotation = rightRotationCanon.rotation;
                bullets2.SetDirectionAndSpeed();
                
                break;
            default:
                break;

                




            
        }
    }
}
