using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;

    [SerializeField] private Animator anim;
    [SerializeField] private Image healthFill;
    [SerializeField] protected GameObject explosionPrefab;
    [SerializeField] private Shield _shield;

    private bool canPlayAnim = true;

    private PlayerShooting _playerShooting;

    public bool canTakeDamage = true;

    private void Awake()
    {
        _playerShooting = GetComponent<PlayerShooting>();
        EndGameManager.instance.RegisterPlayerStats(this);
        EndGameManager.instance.possibleWin = false;
    }

    private void OnEnable() // reklamlarda playerı true ve false olarak yaptık oyüzden böyle olması daha iyi oldu
    {
        currentHealth = maxHealth;
        healthFill.fillAmount = currentHealth / maxHealth;
        EndGameManager.instance.gameOver = false; //bug fixing, every time we load variables is set to false
        StartCoroutine(DamageProtection());
    }

    IEnumerator DamageProtection()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(1.5f);
        canTakeDamage = true;

    }
    public void PlayerTakeDamage(float _damage)
    {
        if (canTakeDamage == false)
            return;
        
        if (_shield._protection)
            return;
        
        currentHealth -= _damage;
        healthFill.fillAmount = currentHealth /maxHealth;

        if(canPlayAnim)
        {
            anim.SetTrigger("Damage");

            StartCoroutine(AntiSpamAnimation());

        }
        _playerShooting.DecraseUpgrade();


        if (currentHealth <= 0)
        {
            EndGameManager.instance.gameOver = true;
            EndGameManager.instance.StartResolveSequence(); // show lose UI
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    public void AddHealth(int healtAmount)
    {
        currentHealth += healtAmount;
        
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        
        healthFill.fillAmount = currentHealth /maxHealth; // güncelledik.

    }
    private IEnumerator AntiSpamAnimation()
    {
        canPlayAnim = false;
        yield return new WaitForSeconds(0.15f);
        canPlayAnim = true;
    }
}
