using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FakePoint : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.material.color = Color.Lerp(Color.black, Color.white, Mathf.PingPong(Time.timeSinceLevelLoad * speed, 1));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "PlayerVisual")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(2);
        }
    }
}
