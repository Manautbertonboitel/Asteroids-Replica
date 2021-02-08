using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidInstantiationManager : MonoBehaviour
{
    public GameObject asteroidPrefab;

    public int asteroidOnScreenLimit = 3;
    public int asteroidOnScreen;

    public Transform[] spawnPoints;

    void Start()
    {
        asteroidOnScreen = 0;
    }

    void Update()
    {
        if (asteroidOnScreen < asteroidOnScreenLimit)
        {
            StartCoroutine("WaitBeforeSpawn");
        }
    }

    IEnumerator WaitBeforeSpawn()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("1 seconde");
        SpawnAsteroid();
    }

    void SpawnAsteroid()
    {
        StopCoroutine("WaitBeforeSpawn");

        int numberPicker;
        numberPicker = Random.Range(1, spawnPoints.Length);

        for (int i = 1; i <= spawnPoints.Length; i++)
        {
            if (i == numberPicker)
            {
                Vector3 asteroidSpawnPosition = spawnPoints[i].transform.position;
                Instantiate(asteroidPrefab, asteroidSpawnPosition, transform.rotation);
                asteroidOnScreen += 1;
            }
        }
    }
}
