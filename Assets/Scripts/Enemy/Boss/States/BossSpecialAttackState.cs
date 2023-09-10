
    using System.Collections;
    using UnityEngine;

    public class BossSpecialAttackState : BossBaseState
    {
        [SerializeField] private float speed;
        [SerializeField] private float waitTime;
        [SerializeField] private GameObject specialBullet;
        [SerializeField] private Transform shootingPoint;
        private Vector2 targetPoint;
        protected override void Start()
        {
            base.Start();
            targetPoint = mainCam.WorldToViewportPoint(new Vector3(.5f, .9f));
        }

        public override void RunState()
        {
            StartCoroutine(RunSpecialAttackState());
        }

        public override void StopState()
        {
            base.StopState();
        }

        IEnumerator RunSpecialAttackState()
        {
            while (Vector2.Distance(transform.position, targetPoint) > 0.01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }

            Instantiate(specialBullet, shootingPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
            _bossController.ChangeState(BossState.fire);

        }
    }
