using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLeft : MonoBehaviour
{
  public float speed = 25.0f;
  private Rigidbody rb;

  void Start()
  {
    rb = this.GetComponent<Rigidbody>();
    rb.velocity = new Vector3(Random.Range(10f, 15f),  0f, 0f);
  }

  // Update is called once per frame
  void Update()
  {
    if(transform.position.x > 40 ){
      Destroy(this.gameObject);
    }
  }
}
