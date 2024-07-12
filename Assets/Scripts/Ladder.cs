using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] Transform Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.name == "Capsule")
        {
            collision.GetComponent<Rigidbody2D>().gravityScale = 0;
            //collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.name == "Capsule")
        {
            collision.GetComponent<Rigidbody2D>().gravityScale = 1;
            Debug.Log("exit");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Capsule")
        {
            //collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
