using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PlayerControls : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 offset;

    private float maxLeft;
    private float maxRight;
    private float maxUp;
    private float maxDown;
    void Start()
    {
        mainCam = Camera.main;

        StartCoroutine(SetBoundaries());


    }

    // Update is called once per frame
    void Update()
    {
        if (Touch.activeTouches.Count > 0) // fixing samsung devices bug
        {
            if (Touch.activeTouches[0].finger.index == 0) // first touch, tek parmakla
            {
                Touch myTouch = Touch.activeTouches[0];

                Vector3 touchPos = myTouch.screenPosition;
#if UNITY_EDITOR

                  if(touchPos.x == Mathf.Infinity) // fixing unity editor bug
                    return;


#endif

                touchPos = mainCam.ScreenToWorldPoint(touchPos);

                if (Touch.activeTouches[0].phase == TouchPhase.Began) // first touch
                {
                    offset = touchPos - transform.position; // nesnenin dokunulan nokta ile player aras�ndaki mesafeyi temsil eder
                }
                if (Touch.activeTouches[0].phase == TouchPhase.Moved) // moved the finger on screen
                {
                    //offset ��karmak nesnenin s�r�klendi�i yere daha do�ru bir �ekilde reaksiyon vermesini sa�lar.
                    transform.position = new Vector3(touchPos.x - offset.x, touchPos.y - offset.y, 0);

                }
                if (Touch.activeTouches[0].phase == TouchPhase.Stationary) // touch finger but not moved(hareketsiz)
                {
                    transform.position = new Vector3(touchPos.x - offset.x, touchPos.y - offset.y, 0);

                }
            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, maxLeft, maxRight), Mathf.Clamp(transform.position.y, maxDown, maxUp), 0);




        }

    }
    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();

    }
    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }
    private IEnumerator SetBoundaries()
    {
        yield return new WaitForSeconds(.4f);

        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;

        maxDown = mainCam.ViewportToWorldPoint(new Vector2(0, 0.05f)).y;
        maxUp = mainCam.ViewportToWorldPoint(new Vector2(0, 0.9f)).y;

    }
}
