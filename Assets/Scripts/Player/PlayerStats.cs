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

    private bool canPlayAnim = true;


    private void Start()
    {
        currentHealth = maxHealth;
        healthFill.fillAmount = currentHealth / maxHealth;
        EndGameManager.instance.gameOver = false; // bug fixing, every time we load variables is set to false
    }
    public void PlayerTakeDamage(float _damage)
    {
        currentHealth -= _damage;
        healthFill.fillAmount = currentHealth /maxHealth;

        if(canPlayAnim)
        {
            anim.SetTrigger("Damage");

            StartCoroutine(AntiSpamAnimation());

        }


        if (currentHealth <= 0)
        {
            EndGameManager.instance.gameOver = true;
            EndGameManager.instance.StartResolveSequence();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
    private IEnumerator AntiSpamAnimation()
    {
        canPlayAnim = false;
        yield return new WaitForSeconds(0.15f);
        canPlayAnim = true;
    }
}
