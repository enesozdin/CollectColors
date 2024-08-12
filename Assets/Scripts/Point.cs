using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class Point : MonoBehaviour
{
    public static Point Instance;
    SpriteRenderer spriteRenderer;
    CanvasController canvasController;
    private void Awake()
    {
        Instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {

        //spriteRenderer = GetComponent<SpriteRenderer>();
        // spriteRenderer.color = CanvasController.Instance.sameColor();
        if (GetComponent<SpriteRenderer>().color == Color.white)
        {
            spriteRenderer.color = GameController.Instance.SetColor();
            Spawner.Instance.point.GetComponent<SpriteRenderer>().color = Color.white;
            Spawner.Instance.point1.GetComponent<SpriteRenderer>().color = Color.white;
            Spawner.Instance.point2.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {

        }

        //spriteRenderer.color=Color.red;
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "PlayerVisual")
        {
            Destroy(gameObject);
            if (GetComponent<SpriteRenderer>().material.color != Color.white)
            {
                CanvasController.Instance.AddTime();
            }

        }

    }
}
