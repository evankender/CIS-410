using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class startGame : MonoBehaviour
{
  public void LoadScene()
  {
    int scene = Random.Range(1, 4);
    SceneManager.LoadScene(scene);
  }
}
