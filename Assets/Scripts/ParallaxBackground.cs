using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed;

    private float spriteHeight;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }
    private void Update()
    {
        transform.Translate(Vector3.down * parallaxSpeed * Time.deltaTime);

        if (transform.position.y < startPos.y - spriteHeight) // detect when the background has scrolled by more than its own height and then reset its position
        {
            transform.position = startPos;
        }
    }
}
