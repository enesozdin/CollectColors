using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float shakeMagnitude = 0.01f;
    private GameController canvasController;
    private Vector3 originalPosition;

    private bool allow;
    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        IsAllowShake(allow);
    }
    public void IsAllowShake(bool allow)
    {
        if (allow == true)
        {
            transform.localPosition = originalPosition + (Random.insideUnitSphere * 0.1f) * shakeMagnitude;
        }
    }
}
