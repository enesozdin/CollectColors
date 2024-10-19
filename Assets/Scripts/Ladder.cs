using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] Transform Player;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.name == "PlayerVisual")
        {
            collision.GetComponent<Rigidbody2D>().gravityScale = 0f;
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.name == "PlayerVisual")
        {
            collision.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "PlayerVisual")
        {
            //collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
