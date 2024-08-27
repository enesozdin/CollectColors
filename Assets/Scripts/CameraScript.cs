using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //public float shakeDuration = 0f; // The duration of the shake effect
    public float shakeMagnitude = 0.01f; // The magnitude of the shake effect
    private CanvasController canvasController;
    private Vector3 originalPosition; // Original position of the camera

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
        else
        {

        }
    }
}
