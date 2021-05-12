using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
  private int flag = 0;
  public GameObject instrText;

  void Start()
  {
    startGame.lives += 2;
  }

  void Update(){
    if(Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.dKey.wasPressedThisFrame){
      instrText.SetActive(false);
    }
  }

  private void OnTriggerEnter(Collider other){
    Debug.Log("hit");
    Debug.Log(startGame.lives);
    startGame.lives--;
    if (flag > 1){
      LoadRandomScene();
    }
    flag++;
  }

  public void LoadRandomScene()
  {

    if(startGame.gamesPlayed == 3 || startGame.lives == 0){ //if all games are played end game
      EndGame();
      return;
    }

    int scene = Random.Range(1, 4); //random scene index 0 is start 5 is endscreen
    //Debug.Log(gameTimer.gameStates[scene]);

    if(startGame.gameStates[scene] == 0){ //if game not played
      startGame.gameStates[scene] = 1; //append played game
      SceneManager.LoadScene(scene); //load game
      startGame.gamesPlayed++; //increment number of games played
      return;
    }
    else{
      LoadRandomScene(); //retry to get an unplayed game
      return;
    }
  }

  private void EndGame()
  {
      SceneManager.LoadScene(4); //load end screen
  }
}
