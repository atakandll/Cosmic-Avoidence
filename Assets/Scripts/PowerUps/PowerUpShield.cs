using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShield : MonoBehaviour
{
    [SerializeField] private AudioClip clipToPlay;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShieldActivator playerShieldActivator = other.GetComponent<PlayerShieldActivator>();
            playerShieldActivator.ActiveShield();
            AudioSource.PlayClipAtPoint(clipToPlay,transform.position,1f);
            Destroy(gameObject);
        }
        
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
