using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public static Barrel Instance;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        // spriteRenderer.color = CanvasController.Instance.sameColor();
        //spriteRenderer.color = canvasController.setColor();
        //spriteRenderer.color=Color.red;
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Capsule")
        {

            Destroy(gameObject);
            CanvasController.Instance.AddPoint();
            if (GetComponent<SpriteRenderer>().material.color != Color.white)
            {
                CanvasController.Instance.AddTime();
            }
        }
    }
}
