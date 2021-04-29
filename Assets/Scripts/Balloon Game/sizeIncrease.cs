using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sizeIncrease : MonoBehaviour
{
  public GameObject balloon;
  public GameObject instrText;
  private float pop = 0;

    void OnSceneLoaded()
    {
        balloon = GetComponent<GameObject>();
        instrText = GetComponent<GameObject>();
    }

    void Update(){
        if(Input.GetKeyDown("f")){ //if f is pressed
          instrText.SetActive(false); //hide instructions
          float scale = Random.value/5f; //random scale value from 0 to .2
          pop += scale; //track total scale
          balloon.transform.localScale += new Vector3(scale, scale, scale);//scale balloon by random scale
          if(pop > 4.8f){ //if total scale > 4.8
            balloon.SetActive(false); //hide balloon aka pop
            startGame.won = 1; //set won to 1
          }
        }
        if(pop < 4.8f){ //hacky code to fix bug: need better solution
          startGame.won = 0;
        }
    }

}
