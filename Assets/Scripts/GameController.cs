using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Color SetColor()
    {
        Color[] colors = { Color.red, Color.green, Color.blue };
        int randomIndex = UnityEngine.Random.Range(0, colors.Length);
        Color randomColor = colors[randomIndex];
        return randomColor;
    }
}
