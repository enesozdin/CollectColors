using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    CanvasController ccontroller;
    // Start is called before the first frame update
    void Start()
    {
        //        int randomIndex = Random.Range(0, myObjects.Length);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void SpawnBarell()
    {
        //Vector2 randomSpawnPosition = new Vector2(Random.Range(-25, -10), 2);
        //Instantiate(myObjects[0], randomSpawnPosition, Quaternion.identity);
        //Instantiate(myObjects[1], randomSpawnPosition, Quaternion.identity);
        //Instantiate(myObjects[2], randomSpawnPosition, Quaternion.identity);
    }
    public void SelectPlatform()
    {
        
        Vector2 randomSpawnPosition = new Vector2(UnityEngine.Random.Range(-7, 2.5f), UnityEngine.Random.Range(1,3.5f));
        Vector2 randomSpawnPosition1 = new Vector2(UnityEngine.Random.Range(9, 18), UnityEngine.Random.Range(9,11.5f));
        Vector2 randomSpawnPosition2 = new Vector2(UnityEngine.Random.Range(3, 22), UnityEngine.Random.Range(17.5f, 20));
        Vector2 randomSpawnPosition3 = new Vector2(UnityEngine.Random.Range(-9, 6), UnityEngine.Random.Range(25.5f, 28));
        Vector2 randomSpawnPosition4 = new Vector2(UnityEngine.Random.Range(9, 23.5f), UnityEngine.Random.Range(25.5f, 28));
        Vector2 randomSpawnPosition5 = new Vector2(UnityEngine.Random.Range(25.85f, 39.5f), UnityEngine.Random.Range(17.5f, 20));
        Vector2 randomSpawnPosition6 = new Vector2(UnityEngine.Random.Range(41f, 56), UnityEngine.Random.Range(9.10f, 12.3f));
        Vector2 randomSpawnPosition7 = new Vector2(UnityEngine.Random.Range(38, 53), UnityEngine.Random.Range(25.1f, 28.1f));
        List<Vector2> spawnPositions = new List<Vector2>() { randomSpawnPosition , randomSpawnPosition1 };
        Vector2 randVector2 = spawnPositions[Random.Range(0, spawnPositions.Count)];
        for (int i = 0; i < spawnPositions.Count; i++)
        {
            ccontroller.barrel.transform.SetPositionAndRotation(randVector2, Quaternion.identity);
        }
    }
    public void randomPosition()
    {
        ////int randomIndex = Random.Range(0, myObjects.Length);
        //Vector2 randomSpawnPosition = new Vector2(UnityEngine.Random.Range(-34, -20), -15);
        //ccontroller.barrel.transform.SetPositionAndRotation(randomSpawnPosition, Quaternion.identity);
        //Vector2 randomSpawnPosition1 = new Vector2(UnityEngine.Random.Range(-34, -20), -15);
        //ccontroller.barrel1.transform.SetPositionAndRotation(randomSpawnPosition1, Quaternion.identity);
        //Vector2 randomSpawnPosition2 = new Vector2(UnityEngine.Random.Range(-18, -3), -5);
        //ccontroller.barrel2.transform.SetPositionAndRotation(randomSpawnPosition2, Quaternion.identity);
    }
}
