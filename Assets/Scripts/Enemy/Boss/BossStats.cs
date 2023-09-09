using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossStats : Enemy

{
    private BossController _bossController;

    private void Awake()
    {
        _bossController = GetComponent<BossController>();
    }


    public override void HurtsSequence()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Dmg")) 
            
            return;
        anim.SetTrigger("Damage");

    }
    public override void DeathSequence()
    {
        base.DeathSequence();
        _bossController.ChangeState(BossState.death);
        Instantiate(explosionPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().PlayerTakeDamage(damage);
        }
    }
}
