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
        private void Start()
        {
            throw new NotImplementedException();
        }

        public void ChangeState(BossState state)
        {
            switch (state)
            {
                case BossState.enter:
                    Debug.LogWarning("Do something");
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
