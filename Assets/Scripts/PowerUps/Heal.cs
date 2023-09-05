using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
   [SerializeField] private int healthAmount;

   private void OnTriggerEnter2D(Collider2D other)
   {
      PlayerStats playerStats = other.GetComponent<PlayerStats>();
      playerStats.AddHealth(healthAmount);
      Destroy(gameObject);
   }

   private void OnBecameInvisible()
   {
      Destroy(gameObject);
   }
}
