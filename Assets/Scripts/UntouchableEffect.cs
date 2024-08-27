using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UntouchableEffect : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] Color baseColor;

    CapsuleCollider2D capsuleCollider;
    float speed = 5;
    // Start is called before the first frame update
    private void Awake()
    {

        // t = Time.time;
    }
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.timeSinceLevelLoad);
        if (Time.timeSinceLevelLoad < 1f)
        {
            spriteRenderer.material.color = Color.Lerp(baseColor, Color.white, Mathf.PingPong(Time.timeSinceLevelLoad * speed, 1));
        }
        else
        {
            spriteRenderer.material.color = Color.white;
        }
        //if (Time.timeSinceLevelLoad > 2f)
        //{
        //    spriteRenderer.material.color = Color.white;
        //}

    }
}
