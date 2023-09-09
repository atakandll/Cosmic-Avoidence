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
        private BossDeathState _bossDeathState;

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
            _bossDeathState = GetComponent<BossDeathState>();
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
                    _bossEnterState.StopState();
                    _bossFireState.StopState();
                    _bossSpecialAttackState.StopState();
                    _bossDeathState.RunState();
                    break;
            }
        }
    }
