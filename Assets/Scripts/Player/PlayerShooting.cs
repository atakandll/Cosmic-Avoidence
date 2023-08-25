using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bullets;
    [SerializeField] private Transform shootingPoint;

    [SerializeField] private float shootingInterval; // ateþ etme aralýðý

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
    private void Shoot()
    {
        Instantiate(bullets, shootingPoint.position,Quaternion.identity);
    }
}
