using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject block_done;
    public GameObject block_start;
    public GameObject Mushroom;
    int count = 0;
    void Start()
    {
      rb = this.GetComponent<Rigidbody>();
      block_done.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
      if(count == 1)
      {
        Debug.Log("block");

        StartCoroutine(Block_Move());
        //rb.transform.position = rb.transform.position + new Vector3 (0, -.5f, 0);
      }
      count++;
    }

    IEnumerator Block_Move()
    {
      rb.transform.position = rb.transform.position + new Vector3 (0, .3f, 0);
      yield return new WaitForSeconds(.1f);
      rb.transform.position = rb.transform.position + new Vector3 (0, .2f, 0);
      yield return new WaitForSeconds(.1f);
      rb.transform.position = rb.transform.position + new Vector3 (0, -.5f, 0);
      yield return new WaitForSeconds(.1f);
      GameObject Mush = Instantiate(Mushroom) as GameObject;


      block_start.SetActive(false);
      block_done.SetActive(true);
    }
}
