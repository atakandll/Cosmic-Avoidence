
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class BossEnterState : BossBaseState
    {
        private Vector2 enterPoint;
        [SerializeField] private float speed;


        protected override void Start()
        {
            base.Start();
            enterPoint = mainCam.ViewportToWorldPoint(new Vector2(0.5f, 0.7f));
        }
        public override void RunState()
        {
            StartCoroutine(RunEnterState());
        }
        public override void StopState() // this will stop the coroutine
        {
            base.StopState();
        }

        IEnumerator RunEnterState()
        {
            while (Vector2.Distance(transform.position, enterPoint) > 0.01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, enterPoint, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            // change the state
            _bossController.ChangeState(BossState.fire);
        }

        

       
    }
