using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public static CanvasController Instance;
    private int counter;
    private int point;
    public Slider slider;

    public bool bar = false;
    public bool bar1 = false;
    public bool bar2 = false;

    Color lastcolor;

    [SerializeField] Text text;
    public Image image;
    public Image image1;
    public Image image2;

    public CameraScript cameraShake;

    private float totalTime = 10.0f;
    public float time;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;


    }
    void Start()
    {
        image.color = GameController.Instance.SetColor();
        image1.color = GameController.Instance.SetColor();
        image2.color = GameController.Instance.SetColor();
        Spawner.Instance.setBarrelColor();
        image.transform.GetChild(0).gameObject.SetActive(false);
        image1.transform.GetChild(0).gameObject.SetActive(false);
        image2.transform.GetChild(0).gameObject.SetActive(false);

        time = totalTime;
        slider.maxValue = totalTime;
    }
    private void FixedUpdate()
    {
        if (bar && bar1 && bar2)
        {
            SceneManager.LoadScene(0);
        }

    }
    // Update is called once per frame
    void Update()
    {

        SameColor();
        UpdateSlider();
        if (time > 0)
        {
            if (time < 3)
            {
                //cameraShake.TriggerShake(+0.1f);
                cameraShake.IsAllowShake(true);
            }

            if (time > 10.0f)
            {
                time = 10.0f;
            }
            time -= Time.deltaTime;
            UpdateSlider();
        }
        if (time <= 0)
        {
            SceneManager.LoadScene(2);
        }

    }
    public void SameColor()
    {
        if (Spawner.Instance.barrel.gameObject.IsDestroyed())
        {
            image.transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("destroyed");
            bar = true;
        }
        if (Spawner.Instance.barrel1.gameObject.IsDestroyed())
        {
            image1.transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("destroyed");
            bar1 = true;
        }
        if (Spawner.Instance.barrel2.gameObject.IsDestroyed())
        {
            image2.transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("destroyed");
            bar2 = true;

        }
    }
    void UpdateSlider()
    {
        slider.value = time;
    }
    public void AddTime()
    {
        time += 3.0f;
        UpdateSlider();
    }
}
