using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class startGame : MonoBehaviour
{
  public static int gamesPlayed = 0;
  public static int[] gameStates = new int[10];
  public static int lives = 3;
  public static int won = 0;

  public void LoadScene()
  {
    int scene = Random.Range(1, 4);
    startGame.gameStates[scene] = 1;
    SceneManager.LoadScene(scene);
  }
}
