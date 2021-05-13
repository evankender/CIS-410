using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;
using gameLogic;

namespace gameLogic{
  public class PlayerCollisionTurtle : MonoBehaviour

  {
    public GameObject instrText;
    private int flag = 0; //collides twice on start
    private int oneFlag = 1;
    randomSceneLoader randomSceneLoader;

    void Awake()
    {
      startGame.lifeFlag = 1; //if time runs out lose a life
      randomSceneLoader = gameObject.AddComponent<randomSceneLoader>();
    }

    void Update()
    {
      if(Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.aKey.wasPressedThisFrame){ //if w or a pressed
        instrText.SetActive(false); //hide instructions
      }
    }

    private void OnTriggerEnter(Collider other)
    {
      if (flag > 1){ //collides twice on start
        if(oneFlag == 1){
        startGame.lifeFlag = 1;
        randomSceneLoader.LoadRandomScene();
        oneFlag = 0;
        }
      }
      flag++; //collides twice on start
    }
  }
}
