using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bullets;
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

    private int upgradeLevel = 0;


    private float intervalReset;



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
        switch (upgradeLevel)
        {
            case 0:
                Instantiate(bullets, shootingPoint.position,Quaternion.identity);
                break;
            case 1:
                Instantiate(bullets, leftCanon.position,Quaternion.identity);
                Instantiate(bullets,rightCanon.position,Quaternion.identity);
                break;
            case 2:
                Instantiate(bullets, shootingPoint.position,Quaternion.identity);
                Instantiate(bullets, leftCanon.position,Quaternion.identity);
                Instantiate(bullets, rightCanon.position,Quaternion.identity);
                break;
            case 3:
                Instantiate(bullets, shootingPoint.position,Quaternion.identity);
                Instantiate(bullets, leftCanon.position,Quaternion.identity);
                Instantiate(bullets, rightCanon.position,Quaternion.identity);
                Instantiate(bullets, secondLeftCanon.position,Quaternion.identity);
                Instantiate(bullets, secondRightCanon.position,Quaternion.identity);
                break;
            
            case 4:
                Instantiate(bullets, shootingPoint.position,Quaternion.identity);
                Instantiate(bullets, leftCanon.position,Quaternion.identity);
                Instantiate(bullets, rightCanon.position,Quaternion.identity);
                Instantiate(bullets, secondLeftCanon.position,Quaternion.identity);
                Instantiate(bullets, secondRightCanon.position,Quaternion.identity);
                Instantiate(bullets, leftRotationCanon.position,leftRotationCanon.rotation);
                Instantiate(bullets, rightRotationCanon.position,rightRotationCanon.rotation);
                break;

            default:
                break;

                




            
        }
    }
}
