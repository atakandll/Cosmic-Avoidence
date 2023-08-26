using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void PlayerTakeDamage(float _damage)
    {
        currentHealth -= _damage;

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
