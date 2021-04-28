using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeIncrease : MonoBehaviour
{
  public GameObject balloon;
  public float pop;

    void OnSceneLoaded()
    {
        balloon = GetComponent<GameObject>();
    }

    void Update(){
        if(Input.GetKeyDown("f")){
          float scale = Random.value/5f;
          pop += scale;
          balloon.transform.localScale += new Vector3(scale, scale, scale);
          if(pop > 4.8f){
            balloon.SetActive(false);
          }
        }
    }
}
