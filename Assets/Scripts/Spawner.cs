using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;

    [SerializeField] GameObject prefabPoint;
    public GameObject point;
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject Player;
    int spawnPointCount = 20;

    private void Awake()
    {
        Instance = this;
        //barrel.GetComponent<SpriteRenderer>().color = Color.white;
        //barrel1.GetComponent<SpriteRenderer>().color = Color.white;
        //barrel2.GetComponent<SpriteRenderer>().color = Color.white;

    }
    void Start()
    {

        SelectPlatform();
        for (int i = 0; i < spawnPointCount; i++)
        {
            Instantiate(point, randSpawn() + new Vector2(2, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SelectPlatform()
    {
        Vector2 randomSpawnPosition = new Vector2(UnityEngine.Random.Range(-7, 2.5f), UnityEngine.Random.Range(1, 3.5f));
        Vector2 randomSpawnPosition1 = new Vector2(UnityEngine.Random.Range(9, 20), UnityEngine.Random.Range(9, 11.5f));
        Vector2 randomSpawnPosition2 = new Vector2(UnityEngine.Random.Range(9, 22), UnityEngine.Random.Range(17.5f, 20));
        Vector2 randomSpawnPosition3 = new Vector2(UnityEngine.Random.Range(-9, 5), UnityEngine.Random.Range(25.5f, 28));
        Vector2 randomSpawnPosition4 = new Vector2(UnityEngine.Random.Range(10, 24), UnityEngine.Random.Range(25.5f, 28));
        Vector2 randomSpawnPosition5 = new Vector2(UnityEngine.Random.Range(26f, 40f), UnityEngine.Random.Range(17.5f, 20));
        Vector2 randomSpawnPosition6 = new Vector2(UnityEngine.Random.Range(38, 53), UnityEngine.Random.Range(25f, 27f));
        Vector2 randomSpawnPosition7 = new Vector2(UnityEngine.Random.Range(44.5f, 53), UnityEngine.Random.Range(9f, 11f));
        Vector2 randomSpawnPosition8 = new Vector2(UnityEngine.Random.Range(27.5f, 38), UnityEngine.Random.Range(1, 3));
        List<Vector2> spawnPositions = new List<Vector2>() { randomSpawnPosition, randomSpawnPosition1, randomSpawnPosition2, randomSpawnPosition3, randomSpawnPosition4, randomSpawnPosition5, randomSpawnPosition6, randomSpawnPosition7,randomSpawnPosition8 };

        Vector2 rand = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Count)];
        point.transform.SetPositionAndRotation(rand, Quaternion.identity);
        Vector2 rand1 = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Count)];
        point1.transform.SetPositionAndRotation(rand1+new Vector2(1,0), Quaternion.identity);
        Vector2 rand2 = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Count)];
        point2.transform.SetPositionAndRotation(rand2+new Vector2(2,0), Quaternion.identity);
        Vector2 rand3 = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Count)];
        point3.transform.SetPositionAndRotation(rand3, Quaternion.identity);
        Vector2 rand4 = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Count)];
        Player.transform.SetPositionAndRotation(rand4, Quaternion.identity);

        if (point3.transform == Player.transform)
        {
            Vector2 rand5 = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Count)];
            point3.transform.SetPositionAndRotation(rand5, Quaternion.identity);
        }

    }
    public Vector2 randSpawn()
    {
        Vector2 randomSpawnPosition = new Vector2(UnityEngine.Random.Range(-7, 2.5f), UnityEngine.Random.Range(1, 3.5f));
        Vector2 randomSpawnPosition1 = new Vector2(UnityEngine.Random.Range(9, 20), UnityEngine.Random.Range(9, 11.5f));
        Vector2 randomSpawnPosition2 = new Vector2(UnityEngine.Random.Range(9, 22), UnityEngine.Random.Range(17.5f, 20));
        Vector2 randomSpawnPosition3 = new Vector2(UnityEngine.Random.Range(-9, 5), UnityEngine.Random.Range(25.5f, 28));
        Vector2 randomSpawnPosition4 = new Vector2(UnityEngine.Random.Range(10, 24), UnityEngine.Random.Range(25.5f, 28));
        Vector2 randomSpawnPosition5 = new Vector2(UnityEngine.Random.Range(26f, 40f), UnityEngine.Random.Range(17.5f, 20));
        Vector2 randomSpawnPosition6 = new Vector2(UnityEngine.Random.Range(38, 53), UnityEngine.Random.Range(25f, 27f));
        Vector2 randomSpawnPosition7 = new Vector2(UnityEngine.Random.Range(44.5f, 53), UnityEngine.Random.Range(9f, 11f));
        Vector2 randomSpawnPosition8 = new Vector2(UnityEngine.Random.Range(27.5f, 38), UnityEngine.Random.Range(1, 3));
        List<Vector2> spawnPositions = new List<Vector2>() { randomSpawnPosition, randomSpawnPosition1, randomSpawnPosition2, randomSpawnPosition3, randomSpawnPosition4, randomSpawnPosition5, randomSpawnPosition6, randomSpawnPosition7,randomSpawnPosition8 };
        Vector2 rand = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Count)];
        //Vector2[] spawnPositions = { randomSpawnPosition, randomSpawnPosition1, randomSpawnPosition2, randomSpawnPosition3, randomSpawnPosition4, randomSpawnPosition5, randomSpawnPosition6, randomSpawnPosition7 };
        return rand;
    }
    public void setBarrelColor()
    {
        point.GetComponent<SpriteRenderer>().material.color = CanvasController.Instance.image.color;
        point1.GetComponent<SpriteRenderer>().material.color = CanvasController.Instance.image1.color;
        point2.GetComponent<SpriteRenderer>().material.color = CanvasController.Instance.image2.color;
    }
}
