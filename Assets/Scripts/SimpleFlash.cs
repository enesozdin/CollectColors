using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFlash : MonoBehaviour
{
    [SerializeField] Material flashMaterial;
    [SerializeField] float duration;

    [SerializeField] Color colorr;

    SpriteRenderer spriteRenderer;
    [SerializeField] Material originalMaterial;
    Coroutine flashRoutine;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Flash();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(spriteRenderer.color);
        spriteRenderer.material.color = Color.Lerp(colorr, Color.white, Mathf.PingPong(Time.time, 1));
    }
    public void Flash()
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }
        flashRoutine = StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        //spriteRenderer.material = flashMaterial;
        //spriteRenderer.material.color = Color.Lerp(Color.blue, Color.green, Mathf.PingPong(Time.time, 1));

        yield return new WaitForSeconds(duration);
        spriteRenderer.material = originalMaterial;
        //flashRoutine = null;
    }

}
