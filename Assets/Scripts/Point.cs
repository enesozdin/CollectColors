
using UnityEngine;

public class Point : MonoBehaviour
{
    public static Point Instance;
    SpriteRenderer spriteRenderer;
    GameController canvasController;
    private void Awake()
    {
        Instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        if (GetComponent<SpriteRenderer>().color == Color.white)
        {
            spriteRenderer.color = GameController.Instance.SetColor();
            Spawner.Instance.point.GetComponent<SpriteRenderer>().color = Color.white;
            Spawner.Instance.point1.GetComponent<SpriteRenderer>().color = Color.white;
            Spawner.Instance.point2.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "PlayerVisual")
        {
            Destroy(gameObject);
            if (GetComponent<SpriteRenderer>().material.color != Color.white)
            {
                GameController.Instance.AddTime();
            }

        }

    }
}
