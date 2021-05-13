using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployAsteroids : MonoBehaviour {
    public GameObject asteroidPrefab;
    public float respawnTime;

    // Use this for initialization
    void Start ()
    {
        respawnTime = .2f;
        StartCoroutine(asteroidWave()); //start spawn asteroids
    }

    private void spawnAsteroid()
    {
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-94, 94), 87f); //random asteroid position
    }

    IEnumerator asteroidWave()
    {
        while(true){
            yield return new WaitForSeconds(respawnTime);
            spawnAsteroid();
        }
    }
}
