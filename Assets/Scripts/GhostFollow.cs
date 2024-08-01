using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostFollow : MonoBehaviour
{
    public float followSpeed;
    private Vector3 targetPosition;

    private void Update()
    {
        if (targetPosition != Vector3.zero)
        {
            MoveTowardsTarget();
        }
    }

    public void SetTargetPosition(Vector3 position)
    {
        targetPosition = position;
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Capsule")
        {
            SceneManager.LoadScene(2);
        }
    }
}
