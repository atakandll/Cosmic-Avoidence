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

        #endregion
        

        private void Awake()
        {
            GetReference();
        }

        private void GetReference()
        {
            _bossEnterState = GetComponent<BossEnterState>();
            _bossFireState = GetComponent<BossFireState>();
        }

        private void Start()
        {
            throw new NotImplementedException();
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
                    Debug.LogWarning("Do something");
                    break;
                case BossState.death:
                    Debug.LogWarning("Do something");
                    break;
            }
        }
    }
