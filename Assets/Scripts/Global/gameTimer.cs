using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameTimer : MonoBehaviour
{
  private float timer;
  public int countGames = 3;

  void OnSceneLoaded()
  {
    timer = 0.0f;
  }

  void Update()
  {
    timer += Time.deltaTime;
    int seconds = (int)(timer % 60);
    if(seconds > 10)
    {
      if(startGame.won == 0){ //if game not won
        startGame.lives--; //lives - 1
        if(startGame.lives == 0){ //if lives = 0 end game
          EndGame();
          return;
        }
      }
      LoadRandomScene();
      return;
    }
  }

  public void LoadRandomScene()
  {

    if(startGame.gamesPlayed == countGames || startGame.lives == 0){ //if all games are played end game
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
