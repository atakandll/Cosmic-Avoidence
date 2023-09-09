using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private int _hitsToDestroy = 3;
    public bool _protection = false;

    [SerializeField] private GameObject[] shieldBase;

    private void OnEnable()
    {
        _hitsToDestroy = 3;

        for (int i = 0; i < shieldBase.Length; i++)
        {
            shieldBase[i].SetActive(true);
        }
        _protection = true;
    }

    private void UpdateUI()
    {
        switch (_hitsToDestroy)
        {
            case 0:
                for (int i = 0; i<shieldBase.Length; i++)
                {
                    shieldBase[i].SetActive(false);
                    
                }

                break;
            case 1:
                shieldBase[0].SetActive(true);
                shieldBase[1].SetActive(false);
                shieldBase[2].SetActive(false);
                break;
            case 2:
                shieldBase[0].SetActive(true);
                shieldBase[1].SetActive(true);
                shieldBase[2].SetActive(false);
                break;
            case 3: 
                shieldBase[0].SetActive(true);
                shieldBase[1].SetActive(true);
                shieldBase[2].SetActive(true);
                break;
                

        }
    }
    

    private void DamageShield()
    {
        _hitsToDestroy -= 1;
        if (_hitsToDestroy <= 0)
        {
            _hitsToDestroy = 0;
            _protection = false;
            gameObject.SetActive((false));
        }
        UpdateUI();
    }

    public void RepairShield()
    {
        _hitsToDestroy = 3;
        UpdateUI();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy)) // enemyye ulaştık
        {
            if (other.CompareTag("Boss"))
            {
                _hitsToDestroy = 0;
                DamageShield();
                return;
            }
            enemy.TakeDamage(1000);
            DamageShield();

        }
        else // for enemy projectTile
        {
            Destroy(other.gameObject);
            DamageShield();
        }
    }
}
