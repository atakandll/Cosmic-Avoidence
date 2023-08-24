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
        if (Touch.fingers[0].isActive) // we need to check if the first finger is active, which means that it touches the screen 
        {
            Touch myTouch = Touch.activeTouches[0];

            Vector3 touchPos = myTouch.screenPosition;

            touchPos = mainCam.ScreenToWorldPoint(touchPos);

            if (Touch.activeTouches[0].phase == TouchPhase.Began) // first touch
            {
                offset = touchPos - transform.position; // nesnenin dokunulan nokta ile player arasýndaki mesafeyi temsil eder
            }
            if (Touch.activeTouches[0].phase == TouchPhase.Moved) // moved the finger on screen
            {
                //offset çýkarmak nesnenin sürüklendiði yere daha doðru bir þekilde reaksiyon vermesini saðlar.
                transform.position = new Vector3(touchPos.x - offset.x, touchPos.y - offset.y, 0);

            }
            if (Touch.activeTouches[0].phase == TouchPhase.Stationary) // touch finger but not moved(hareketsiz)
            {
                transform.position = new Vector3(touchPos.x - offset.x, touchPos.y - offset.y, 0);

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
