using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public static Barrel Instance { get; set; }
    SpriteRenderer spriteRenderer;
    CanvasController canvasController;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            CanvasController.Instance.addPoint();
            Destroy(gameObject);
        }
    }
}
