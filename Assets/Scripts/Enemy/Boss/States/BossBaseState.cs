using System;
using UnityEngine;



    public class BossBaseState : MonoBehaviour
    {
        protected Camera mainCam;

        protected  float maxLeft;
        protected  float maxRight;
        protected  float maxDown;
        protected  float maxUp;
        protected BossController _bossController;

        private void Awake()
        {
            _bossController = GetComponent<BossController>();
            mainCam = Camera.main;
        }

        protected virtual void Start()
        {
            if (mainCam == null) return;
            maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.3f, 0)).x;
            maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.7f, 0)).x;

            maxDown = mainCam.ViewportToWorldPoint(new Vector2(0, 0.6f)).y;
            maxUp = mainCam.ViewportToWorldPoint(new Vector2(0, 0.9f)).y;

        }

        public virtual void RunState()
        {
            
        }

        public virtual void StopState()
        {
            StopAllCoroutines();
        }
    }
