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

        [SerializeField] private BossEnterState _bossEnterState;
        [SerializeField] private BossFireState _bossFireState;
        [SerializeField] private BossSpecialAttackState _bossSpecialAttackState;
        [SerializeField] private BossDeathState _bossDeathState;

        #endregion
        
        
       

        private void Start()
        {
            ChangeState(BossState.enter);
            
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
