using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] meteors;
    [SerializeField] private float spawnnTime;
    private float timer = 0f;
    private int i;

    private Camera mainCam;
    private float maxLeft;
    private float maxRight;
    private float yPos;

    private void Start()
    {
        mainCam = Camera.main;

        StartCoroutine(SetBoundaries());
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnnTime)
        {
            i = Random.Range(0, meteors.Length);

            GameObject newGameObject = Instantiate(meteors[i], new Vector3(Random.Range(maxLeft, maxRight), yPos, -5), Quaternion.Euler(0, 0, Random.Range(0, 360)));

            float size = Random.Range(0.9f, 1.1f);

            newGameObject.transform.localScale = new Vector3(size, size, 1);

            timer = 0;
        }

    }

    private IEnumerator SetBoundaries()
    {
        yield return new WaitForSeconds(.4f);

        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;

        yPos = mainCam.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;



    }
}
