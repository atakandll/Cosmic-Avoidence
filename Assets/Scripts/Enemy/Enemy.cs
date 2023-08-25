using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected Rigidbody2D rb;


    public void TakeDamage(float damage)
    {
        health -= damage;

        HurtsSequence();
        
        if(health <= 0)
        {        
            DeathSequence();
        }
    }
    public virtual void HurtsSequence()
    {

    }
    public virtual void DeathSequence()
    {

    }
}
