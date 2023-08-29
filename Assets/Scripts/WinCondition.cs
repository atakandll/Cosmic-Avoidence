using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private float timer;
    [SerializeField] private float possibleWinTime;
    [SerializeField] GameObject[] spawner;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= possibleWinTime)
        {
            for (int i = 0; i < spawner.Length; i++)
            {
                spawner[i].SetActive(false);
            }

            EndGameManager.instance.StartResolveSequence();
            gameObject.SetActive(false); // Sürekli çalýþacaðý için durduruyoruz bi kereden sonra
        }
    }
}
