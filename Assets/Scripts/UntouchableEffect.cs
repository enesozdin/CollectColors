using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UntouchableEffect : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] Color baseColor;
    float speed = 5;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Time.timeSinceLevelLoad < 1f)
        {
            spriteRenderer.material.color = Color.Lerp(baseColor, Color.white, Mathf.PingPong(Time.timeSinceLevelLoad * speed, 1));
        }
        else
        {
            spriteRenderer.material.color = Color.white;
        }

    }
}
