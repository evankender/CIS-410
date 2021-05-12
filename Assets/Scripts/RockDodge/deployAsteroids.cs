using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployAsteroids : MonoBehaviour {
    public GameObject asteroidPrefab;
    public float respawnTime = .1f;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(asteroidWave());
    }

    private void spawnAsteroid()
    {
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-94, 94), 87f);
    }
    IEnumerator asteroidWave()
    {
        while(true){
            yield return new WaitForSeconds(.2f);
            spawnAsteroid();
        }
    }
}
