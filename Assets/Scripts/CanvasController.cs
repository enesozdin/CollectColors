using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public static CanvasController Instance { get; set; }
    private int counter;
    private int point;

    //Barrel barrel;
    Color lastcolor;

    [SerializeField] Text text;
    [SerializeField] Image image;
    [SerializeField] Image image1;
    [SerializeField] Image image2;

    [SerializeField] GameObject barrel;
    [SerializeField] GameObject barrel1;
    [SerializeField] GameObject barrel2;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        image.color = setColor();
        image1.color = setColor();
        image2.color = setColor();

        image.transform.GetChild(0).gameObject.SetActive(false);
        image1.transform.GetChild(0).gameObject.SetActive(false);
        image2.transform.GetChild(0).gameObject.SetActive(false);

        barrel.GetComponent<SpriteRenderer>().material.color = image.color;
        barrel1.GetComponent<SpriteRenderer>().material.color = image1.color;
        barrel2.GetComponent<SpriteRenderer>().material.color = image2.color;
    }
    private void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        sameColor();
    }

    public void addPoint()
    {
        counter++;
        point = counter / 2;
        text.text = point.ToString();
    }
    public Color setColor()
    {
        Color[] colors = { Color.red, Color.green, Color.blue };
        int randomIndex = UnityEngine.Random.Range(0, colors.Length);
        Color randomColor = colors[randomIndex];
        return randomColor;
    }
    public void sameColor()
    {
        if (barrel.gameObject.IsDestroyed())
        {
            image.transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("destroyed");
        }
        if (barrel1.gameObject.IsDestroyed())
        {
            image1.transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("destroyed");
        }
        if (barrel2.gameObject.IsDestroyed())
        {
            image2.transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("destroyed");
        }
    }
}
