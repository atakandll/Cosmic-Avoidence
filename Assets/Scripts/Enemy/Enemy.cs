using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected Rigidbody2D rb;

    [SerializeField] protected float damage;
    [SerializeField] protected GameObject explosionPrefab;

    [SerializeField] protected Animator anim;
    [SerializeField] protected int scoreValue;


    private void Awake()
    {
        
    }

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
        EndGameManager.instance.UpdateScore(scoreValue);

    }
}
