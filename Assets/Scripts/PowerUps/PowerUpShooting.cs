using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShooting : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        
        if (other.CompareTag("Player"))
        {
            PlayerShooting playerShooting = other.GetComponent<PlayerShooting>(); //eger other nesnesi "Player" etiketini tasiyorsa, bu nesnenin üzerinde bulunan PlayerShooting bilesenini alıyoruz
            AudioSource.PlayClipAtPoint(clip,transform.position,1f);
            playerShooting.IncreaseUpgrade(1);
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
