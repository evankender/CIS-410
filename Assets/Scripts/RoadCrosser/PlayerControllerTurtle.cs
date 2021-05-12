using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerTurtle : MonoBehaviour
{
    public float speed;
    public InputAction wasd;
    public CharacterController controller;
    public int countGames = 4;

    void Start()
    {
      controller = GetComponent<CharacterController>();
    }

    void OnEnable()
    {
      wasd.Enable();
    }

    void OnDisable()
    {
      wasd.Disable();
    }

    // Update is called once per frame
    void Update()
    {
      Vector2 inputVector = wasd.ReadValue<Vector2>();
      Vector3 moveVector = new Vector3();

      moveVector.x = inputVector.x;
      moveVector.y = inputVector.y;

      controller.Move(moveVector * Time.deltaTime * speed);

      if(transform.position.y > 21){
        LoadRandomScene();
      }

    }

    public void LoadRandomScene()
    {

      if(startGame.gamesPlayed == countGames){ //if all games are played end game
        EndGame();
        return;
      }

      int scene = Random.Range(1, 5); //random scene index 0 is start 5 is endscreen
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
        SceneManager.LoadScene(5); //load end screen
    }
}
