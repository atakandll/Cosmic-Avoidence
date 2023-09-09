using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUoShooting : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShooting playerShooting = other.GetComponent<PlayerShooting>(); //eger other nesnesi "Player" etiketini tasiyorsa, bu nesnenin üzerinde bulunan PlayerShooting bilesenini alıyoruz
            playerShooting.IncreaseUpgrade(1);
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
