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
        private BossEnterState _bossEnterState;

        private void Awake()
        {
            _bossEnterState = GetComponent<BossEnterState>();
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
                    Debug.LogWarning("Do something");
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
