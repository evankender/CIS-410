using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class startGame : MonoBehaviour
{
  public static int gamesPlayed = 0;
  public static int[] gameStates = new int[10]; //if gameStates[Scene index] = 0 game not played if 1 game has been played
  public static int lives = 3;
  public static int won = 0;

  public void LoadScene()
  {
    int scene = Random.Range(1, 5); //random game index
    startGame.gameStates[scene] = 1; //set game to played in gameStates
    SceneManager.LoadScene(scene); //load random game
  }
}
