using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameTimer : MonoBehaviour
{
  private float timer;
  public int countGames = 4;
  public static int gamesPlayed = 0;
  public static int[] gameStates = new int[10];


  void OnSceneLoaded()
  {
    timer = 0.0f;
    startGame.won = 0;
  }

  void Update()
  {
    timer += Time.deltaTime;
    int seconds = (int)(timer % 60);
    if(seconds > 10)
    {
      if(startGame.won == 0){
        startGame.lives--;
        if(startGame.lives == 0){
          EndGame();
          return;
        }
      }
      LoadRandomScene();
      return;
    }
  }

  private void LoadRandomScene()
  {

    if(startGame.gamesPlayed == countGames){ //if all games are played
      EndGame();
      return;
    }

    int scene = Random.Range(1, 5);
    //Debug.Log(gameTimer.gameStates[scene]);

    if(startGame.gameStates[scene] == 0){ //if game played
      startGame.gameStates[scene] = 1; //append played game
      SceneManager.LoadScene(scene); //load game
      startGame.gamesPlayed++;
      return;
    }
    else{
      LoadRandomScene(); //retry to get an unplayed game
      return;
    }
  }

  private void EndGame()
  {
      SceneManager.LoadScene(5); //load end screen
  }
}
