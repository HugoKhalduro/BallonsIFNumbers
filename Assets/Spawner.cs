 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{   

    public GameObject Balloons;
    public Transform[] spawnPoints;

    public float minSpawnDelay = 0.5f;
    public float maxSpawnDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn(){

        while(true){

        float Timer = Random.Range(minSpawnDelay, maxSpawnDelay);
        yield return new WaitForSeconds(1f);

        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        GameObject spawnedBalloon = Instantiate(Balloons, spawnPoint.position, spawnPoint.rotation);
        Destroy(spawnedBalloon, 5f);

        }

    }

}
