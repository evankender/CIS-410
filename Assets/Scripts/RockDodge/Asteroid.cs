using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 25.0f;
    private Rigidbody rb;

    void Start()
    {
      rb = this.GetComponent<Rigidbody>();
      rb.velocity = new Vector3(0f,  Random.Range(-25f, -45f), 0f);

      rb.transform.Rotate(new Vector3(0f, 0f, Random.Range(-360f, 360f)));
      rb.transform.localScale *= Random.Range(.7f, 1f);

    }

    // Update is called once per frame
    void Update()
    {
      if(transform.position.y < -10){
        Destroy(this.gameObject);
    }

    }
}
