using System;
using UnityEngine;


public enum BossState
{
    enter,
    fire,
    special,
    death
}

    public class BossController : MonoBehaviour
    {
        #region States

        private BossEnterState _bossEnterState;
        private BossFireState _bossFireState;
        private BossSpecialAttackState _bossSpecialAttackState;

        #endregion
        

        private void Awake()
        {
            GetReference();
        }

        private void GetReference()
        {
            _bossEnterState = GetComponent<BossEnterState>();
            _bossFireState = GetComponent<BossFireState>();
            _bossSpecialAttackState = GetComponent<BossSpecialAttackState>();
        }

        private void Start()
        {
            
        }

        public void ChangeState(BossState state)
        {
            switch (state)
            {
                case BossState.enter:
                    _bossEnterState.RunState();
                    break;
                case BossState.fire:
                    _bossFireState.RunState();
                    break;
                case BossState.special:
                    _bossSpecialAttackState.RunState();
                    break;
                case BossState.death:
                    Debug.LogWarning("Do something");
                    break;
            }
        }
    }
