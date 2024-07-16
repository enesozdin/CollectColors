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
    public static CanvasController Instance { get; set; }
    private int counter;
    private int point;
    public Slider slider;

    bool bar = false;
    bool bar1 = false;
    bool bar2 = false;

    Color lastcolor;

    [SerializeField] Text text;
    [SerializeField] Image image;
    [SerializeField] Image image1;
    [SerializeField] Image image2;

    public GameObject barrel;
    public GameObject barrel1;
    public GameObject barrel2;

    private float totalTime = 10.0f;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;

    }
    void Start()
    {
        image.color = SetColor();
        image1.color = SetColor();
        image2.color = SetColor();

        image.transform.GetChild(0).gameObject.SetActive(false);
        image1.transform.GetChild(0).gameObject.SetActive(false);
        image2.transform.GetChild(0).gameObject.SetActive(false);

        barrel.GetComponent<SpriteRenderer>().material.color = image.color;
        barrel1.GetComponent<SpriteRenderer>().material.color = image1.color;
        barrel2.GetComponent<SpriteRenderer>().material.color = image2.color;
        //randomPosition();
        SelectPlatform();
        slider.maxValue = totalTime;
    }
    private void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        SameColor();

        if (bar && bar1 && bar2)
        {
            SceneManager.LoadScene(0);
        }
        UpdateSlider();
        if (totalTime > 0)
        {
            if (totalTime > 10.0f)
            {
                totalTime = 10.0f;
            }
            totalTime -= Time.deltaTime;
            UpdateSlider();
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }

    public void AddPoint()
    {
        counter++;
        point = counter / 2;
        text.text = point.ToString();
    }
    public Color SetColor()
    {
        Color[] colors = { Color.red, Color.green, Color.blue };
        int randomIndex = UnityEngine.Random.Range(0, colors.Length);
        Color randomColor = colors[randomIndex];
        return randomColor;
    }
    public void SameColor()
    {
        if (barrel.gameObject.IsDestroyed())
        {
            image.transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("destroyed");
            bar = true;
        }
        if (barrel1.gameObject.IsDestroyed())
        {
            image1.transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("destroyed");
            bar1 = true;
        }
        if (barrel2.gameObject.IsDestroyed())
        {
            image2.transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("destroyed");
            bar2 = true;
        }
    }
    void UpdateSlider()
    {
        slider.value = totalTime;
    }
    public void AddTime()
    {
        totalTime += 3.0f;
        UpdateSlider();
    }
    //public void randomPosition()
    //{
    //    //int randomIndex = Random.Range(0, myObjects.Length);
    //    Vector2 randomSpawnPosition = new Vector2(UnityEngine.Random.Range(-34, -20), -15);
    //    barrel.transform.SetPositionAndRotation(randomSpawnPosition, rotation: quaternion.identity);
    //    Vector2 randomSpawnPosition1 = new Vector2(UnityEngine.Random.Range(-34, -20), -15);
    //    barrel1.transform.SetPositionAndRotation(randomSpawnPosition1, rotation: quaternion.identity);
    //    Vector2 randomSpawnPosition2 = new Vector2(UnityEngine.Random.Range(-18, -3), -5);
    //    barrel2.transform.SetPositionAndRotation(randomSpawnPosition2, rotation: quaternion.identity);
    //}
    public void SelectPlatform()
    {

        Vector2 randomSpawnPosition = new Vector2(UnityEngine.Random.Range(-7, 2.5f), UnityEngine.Random.Range(1, 3.5f));
        Vector2 randomSpawnPosition1 = new Vector2(UnityEngine.Random.Range(9, 18), UnityEngine.Random.Range(9, 11.5f));
        Vector2 randomSpawnPosition2 = new Vector2(UnityEngine.Random.Range(3, 22), UnityEngine.Random.Range(17.5f, 20));
        Vector2 randomSpawnPosition3 = new Vector2(UnityEngine.Random.Range(-9, 6), UnityEngine.Random.Range(25.5f, 28));
        Vector2 randomSpawnPosition4 = new Vector2(UnityEngine.Random.Range(9, 23.5f), UnityEngine.Random.Range(25.5f, 28));
        Vector2 randomSpawnPosition5 = new Vector2(UnityEngine.Random.Range(25.85f, 39.5f), UnityEngine.Random.Range(17.5f, 20));
        Vector2 randomSpawnPosition6 = new Vector2(UnityEngine.Random.Range(41f, 56), UnityEngine.Random.Range(9.10f, 12.3f));
        Vector2 randomSpawnPosition7 = new Vector2(UnityEngine.Random.Range(38, 53), UnityEngine.Random.Range(25.1f, 28.1f));
        List<Vector2> spawnPositions = new List<Vector2>() { randomSpawnPosition, randomSpawnPosition1, randomSpawnPosition2, randomSpawnPosition3, randomSpawnPosition4, randomSpawnPosition5, randomSpawnPosition6, randomSpawnPosition7 };
        //Vector2[] spawnPositions = { randomSpawnPosition, randomSpawnPosition1, randomSpawnPosition2, randomSpawnPosition3, randomSpawnPosition4, randomSpawnPosition5, randomSpawnPosition6, randomSpawnPosition7 };
        Vector2 rand = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Count)];
        barrel.transform.SetPositionAndRotation(rand, Quaternion.identity);
        Vector2 rand1 = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Count)];
        barrel1.transform.SetPositionAndRotation(rand1, Quaternion.identity);
        Vector2 rand2 = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Count)];
        barrel2.transform.SetPositionAndRotation(rand2, Quaternion.identity);
        //foreach (Vector2 ran in spawnPositions)
        //{
        //    //barrel.transform.SetPositionAndRotation(randVector2, Quaternion.identity);
        //    barrel.transform.SetPositionAndRotation(ran, Quaternion.identity);
        //    barrel1.transform.SetPositionAndRotation(ran, Quaternion.identity);
        //    barrel2.transform.SetPositionAndRotation(ran, Quaternion.identity);
        //}
        //for (int i = 0; i < 2; i++)
        //{
        //    Vector2 bar = randVector2[1];
        //    barrel.transform.SetPositionAndRotation(bar, Quaternion.identity);
        //    //Vector2 bar1 = spawnPositions[2];
        //    //barrel.transform.SetPositionAndRotation(bar, Quaternion.identity);
        //    //Vector2 bar2 = spawnPositions[3];
        //    //barrel.transform.SetPositionAndRotation(bar, Quaternion.identity);

        //}

        //for (int i = 0; i < spawnPositions.Count; i++)
        //{
        //    //barrel.transform.SetPositionAndRotation(randVector2, Quaternion.identity);
        //    barrel.transform.SetPositionAndRotation([i], Quaternion.identity);
        //    barrel1.transform.SetPositionAndRotation(i, Quaternion.identity);
        //    barrel2.transform.SetPositionAndRotation(i, Quaternion.identity);
        //}
    }
}
