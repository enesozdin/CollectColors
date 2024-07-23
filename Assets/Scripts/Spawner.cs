using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;

    [SerializeField] GameObject prefabBarrel;
    public GameObject barrel;
    public GameObject barrel1;
    public GameObject barrel2;
    int spawnBarrelCount = 10;

    private void Awake()
    {
        Instance = this;
        //barrel.GetComponent<SpriteRenderer>().color = Color.white;
        //barrel1.GetComponent<SpriteRenderer>().color = Color.white;
        //barrel2.GetComponent<SpriteRenderer>().color = Color.white;
    }
    void Start()
    {
        barrel.GetComponent<SpriteRenderer>().material.color = CanvasController.Instance.image.color;
        barrel1.GetComponent<SpriteRenderer>().material.color = CanvasController.Instance.image1.color;
        barrel2.GetComponent<SpriteRenderer>().material.color = CanvasController.Instance.image2.color;



        SelectPlatform();
        for (int i = 0; i < spawnBarrelCount; i++)
        {
            Instantiate(barrel, randSpawn() + new Vector2(2, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
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

        Vector2 rand = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Count)];
        barrel.transform.SetPositionAndRotation(rand, Quaternion.identity);
        Vector2 rand1 = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Count)];
        barrel1.transform.SetPositionAndRotation(rand1+new Vector2(1,0), Quaternion.identity);
        Vector2 rand2 = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Count)];
        barrel2.transform.SetPositionAndRotation(rand2+new Vector2(2,0), Quaternion.identity);

    }
    public Vector2 randSpawn()
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
        Vector2 rand = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Count)];
        //Vector2[] spawnPositions = { randomSpawnPosition, randomSpawnPosition1, randomSpawnPosition2, randomSpawnPosition3, randomSpawnPosition4, randomSpawnPosition5, randomSpawnPosition6, randomSpawnPosition7 };
        return rand;
    }
}
