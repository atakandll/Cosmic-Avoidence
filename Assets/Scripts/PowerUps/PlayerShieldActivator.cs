using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldActivator : MonoBehaviour
{
    [SerializeField] private Shield _shield;

    public void ActiveShield()
    {
        if (_shield.gameObject.activeSelf == false)
        {
            _shield.gameObject.SetActive(true);
        }
        else // zaten aktifse canını yeniledik
        {
            _shield.RepairShield();
        }
    }
}
