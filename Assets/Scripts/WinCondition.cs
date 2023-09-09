using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private float timer;
    [SerializeField] private float possibleWinTime;
    [SerializeField] GameObject[] spawner;
    [SerializeField] private bool hasBoss;
    public bool canSpawnBoss = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (EndGameManager.instance.gameOver == true) return;

        timer += Time.deltaTime;

        if (timer >= possibleWinTime)
        {
            if (hasBoss == false)
            {
                EndGameManager.instance.StartResolveSequence();

            }
            else
            {
                canSpawnBoss = true;
            }
            
            for (int i = 0; i < spawner.Length; i++)
            {
                spawner[i].SetActive(false);
            }

            
            gameObject.SetActive(false); // Sürekli çalýþacaðý için durduruyoruz bi kereden sonra
        }
    }
}
