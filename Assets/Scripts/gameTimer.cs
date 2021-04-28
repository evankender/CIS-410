using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameTimer : MonoBehaviour
{
  public float timer;

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
      LoadScene();
    }
  }

  public void LoadScene()
  {
    int scene = Random.Range(1, 4);
    SceneManager.LoadScene(scene);
  }
}
