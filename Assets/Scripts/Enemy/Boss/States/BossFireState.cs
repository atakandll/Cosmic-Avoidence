
    using System.Collections;
    using UnityEngine;

    public class BossFireState : BossBaseState
    {
        [SerializeField] private float speed;
        [SerializeField] private float shootRate;
        [SerializeField] private GameObject bulletPrefab;

        [Header("Shooting Points"), SerializeField]
        private Transform[] shootPoints;


        public override void RunState()
        {
            StartCoroutine(RunFireState());
        }

        public override void StopState()
        {
            base.StopState();
        }

        IEnumerator RunFireState()
        {
            float shootTimer = 0f;
            float fireStateTimer = 0f;
            float fireStateExitTime = Random.Range(5f, 10f);
            Vector2 targetPosition = new Vector2(Random.Range(maxLeft, maxRight), Random.Range(maxDown, maxUp));

            while (fireStateTimer <= fireStateExitTime)
            {
                if (Vector2.Distance(transform.position, targetPosition) > 0.01f)
                {
                    transform.position =
                        Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                }
                else
                {
                    targetPosition = new Vector2(Random.Range(maxLeft, maxRight), Random.Range(maxDown, maxUp));
                }

                shootTimer += Time.deltaTime;
                
                if (shootTimer >= shootRate)
                {
                    for (int i = 0; i < shootPoints.Length; i++)
                    {
                        Instantiate(bulletPrefab, shootPoints[i].position, Quaternion.identity);

                    }

                    shootTimer = 0;
                }

                yield return new WaitForEndOfFrame();
                fireStateTimer += Time.deltaTime;

            }

            int randomState = Random.Range(0, 3);

            if (randomState == 0)
                _bossController.ChangeState((BossState.fire));
            else
                _bossController.ChangeState(BossState.special);

        }
    }
