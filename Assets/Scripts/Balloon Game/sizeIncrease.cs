using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sizeIncrease : MonoBehaviour
{
  public GameObject balloon;
  public GameObject instrText;
  private float pop;


    void OnSceneLoaded()
    {
        balloon = GetComponent<GameObject>();
        instrText = GetComponent<GameObject>();
    }

    void Update(){
        if(Input.GetKeyDown("f")){
          instrText.SetActive(false);
          float scale = Random.value/5f;
          pop += scale;
          balloon.transform.localScale += new Vector3(scale, scale, scale);
          if(pop > 4.8f){
            balloon.SetActive(false);
            startGame.won = 1;
          }
        }
    }
}
