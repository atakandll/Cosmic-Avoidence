using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private Camera mainCam;
    private float maxLeft;

    private float maxRight;
    private float yPos;

    [Header("Enemy Prefabs")]
    [SerializeField] private GameObject[] enemies;

    private float enemyTimer;
    [Space(15)]
    [SerializeField] private float enemySpawnTime;

    [Header("Boss")] [SerializeField] private GameObject bossPrefab;
    [SerializeField] private WinCondition winCon;

    void Start()
    {
        mainCam = Camera.main;
        StartCoroutine(SetBoundaries());

    }
    private void Update()
    {
        EnemySpawn();
    }
    private void EnemySpawn()
    {
        enemyTimer += Time.deltaTime;

        if (enemyTimer >= enemySpawnTime)
        {
            int randomPick = Random.Range(0, enemies.Length);

            Instantiate(enemies[randomPick], new Vector3(Random.Range(maxLeft, maxRight), yPos, 0), Quaternion.identity);
            enemyTimer = 0;
        }
    }
    private IEnumerator SetBoundaries()
    {
        yield return new WaitForSeconds(.4f);

        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;

        yPos = mainCam.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;
    }

    private void OnDisable() // enemySpawners disable olduğu zaman boss gelicek.
    {
        if (winCon == null) return;
        
        if (winCon.canSpawnBoss == false)
            return;
        
        if (bossPrefab != null)
        {
            if (mainCam == null) return;
            
            Vector2 spawnPos = mainCam.ViewportToWorldPoint(new Vector2(0.5f, 1.2f));
            Instantiate(bossPrefab, spawnPos, Quaternion.identity);
        }
    }
}
