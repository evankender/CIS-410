using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployCars : MonoBehaviour {
    public GameObject CarRight;
    public GameObject CarLeft;
    int lastLeft = -1;
    int lastRight = -1;
    public float[] posRight = {3.4f, 8.5f, 13.4f, 18.5f, -1.5f, -6.5f, -11.5f, -16.6f};
    public float[] posLeft = {-18.8f, -13.8f, -8.8f, -3.8f, 1.2f, 6.2f, 11.2f, 16.2f};


    // Use this for initialization
    void Start ()
    {
        StartCoroutine(carWave());
    }

    private void spawnCar()
    {
        GameObject right = Instantiate(CarRight) as GameObject;
        GameObject left = Instantiate(CarLeft) as GameObject;
        var randomIndexRight = Random.Range(0, posRight.Length);
        var randomIndexLeft = Random.Range(0, posLeft.Length);
        if(randomIndexRight == lastRight || randomIndexLeft == lastLeft){
          spawnCar();
        }
        lastLeft = randomIndexLeft;
        lastRight = randomIndexRight;
        right.transform.position = new Vector2(39f, posRight[randomIndexRight]);
        left.transform.position = new Vector2(-39f, posLeft[randomIndexLeft]);
    }
    IEnumerator carWave()
    {
        while(true){
            yield return new WaitForSeconds(1f);
            spawnCar();
        }
    }
}
