using System;
using Unity.VisualScripting;
using UnityEngine;
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
    [SerializeField] Image fillImage;
    public Image image;
    public Image image1;
    public Image image2;

    public CameraScript cameraShake;

    private float totalTime = 15.0f;
    private float updateTime = 3f;
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
            SceneManager.LoadScene(3);
        }

    }
    // Update is called once per frame
    void Update()
    {

        SameColor();
        UpdateSlider();
        if (time > 0)
        {
            fillImage.color = Color.green;
            if (time < 3)
            {
                cameraShake.IsAllowShake(true);
                fillImage.color=Color.red;
                //slider.transform.GetChild(1).GetChild(0).GetComponent<Image>().color;
            }

            if (time > totalTime)
            {
                time = totalTime;
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
        if (Spawner.Instance.point.gameObject.IsDestroyed())
        {
            image.transform.GetChild(0).gameObject.SetActive(true);
            bar = true;
        }
        if (Spawner.Instance.point1.gameObject.IsDestroyed())
        {
            image1.transform.GetChild(0).gameObject.SetActive(true);
            bar1 = true;
        }
        if (Spawner.Instance.point2.gameObject.IsDestroyed())
        {
            image2.transform.GetChild(0).gameObject.SetActive(true);
            bar2 = true;

        }
    }
    void UpdateSlider()
    {
        slider.value = time;
    }
    public void AddTime()
    {
        time += updateTime;
        UpdateSlider();
    }
}
