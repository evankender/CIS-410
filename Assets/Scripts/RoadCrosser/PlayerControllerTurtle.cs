using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace gameLogic
{
  public class PlayerControllerTurtle : MonoBehaviour
  {
      public float speed;
      public float rotateSpeed;
      public InputAction wasd;
      public CharacterController controller;
      public GameObject player;
      public int countGames = 4;
      randomSceneLoader randomSceneLoader;

      void Awake()
      {
        Debug.Log("Turtle");
        controller = GetComponent<CharacterController>();
        randomSceneLoader = gameObject.AddComponent<randomSceneLoader>();
      }

      void Update()
      {
        Vector2 move = wasd.ReadValue<Vector2>();

        controller.Move(move * Time.deltaTime * speed); //move player

        if(move != Vector2.zero) //if player not moving
        {
            transform.rotation = Quaternion.LookRotation(Vector3.back,move); //rotate player in direction of movement
        }

        if(transform.position.y > 21) //if player crossed road
        {
          startGame.lifeFlag = 0;
          randomSceneLoader.LoadRandomScene(); //load random scene
        }

      }

      void OnEnable()
      {
        wasd.Enable();
      }

      void OnDisable()
      {
        wasd.Disable();
      }
  }
}
