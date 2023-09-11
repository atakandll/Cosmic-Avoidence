using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
   [SerializeField] private int healthAmount;
   [SerializeField] private AudioClip clip;

   private void OnTriggerEnter2D(Collider2D other)
   {
      PlayerStats playerStats = other.GetComponent<PlayerStats>();
      AudioSource.PlayClipAtPoint(clip,transform.position,1f);
      playerStats.AddHealth(healthAmount);
      Destroy(gameObject);
   }

   private void OnBecameInvisible()
   {
      Destroy(gameObject);
   }
}
