using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShield : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShieldActivator playerShieldActivator = other.GetComponent<PlayerShieldActivator>();
            playerShieldActivator.ActiveShield();
            Destroy(gameObject);
        }
        
    }
}
