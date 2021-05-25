using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace gameLogic
{
  public class MarioController : MonoBehaviour
  {
      public float speed;
      public int jumpPower;
      public float rotateSpeed;
      public InputAction wasd;
      private Vector3 playerVelocity;
      public CharacterController controller;
      public GameObject player;
      public int countGames = 4;
      public Animator animator;
      private bool rotateFlag = true;
      private Rigidbody rb;
      randomSceneLoader randomSceneLoader;
      private float jumpHeight = 2.6f;
      private float gravityValue = -30.81f;
      private int jumpCount = 0;
      bool groundedPlayer = true;

      void Start()
      {
        controller = GetComponent<CharacterController>();
        randomSceneLoader = gameObject.AddComponent<randomSceneLoader>();
        rb = this.GetComponent<Rigidbody>();
      }

      // Update is called once per frame
      void Update()
      {
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
            animator.SetBool("isJumping", false);
            jumpCount = 0;
        }

        Vector2 move = wasd.ReadValue<Vector2>();
        animator.SetFloat("Speed", Mathf.Abs(move.x));

        if(Keyboard.current.spaceKey.wasPressedThisFrame && jumpCount < 2){ //if d is pressed and facing left
  	      animator.SetBool("isJumping", true);
          playerVelocity.y = 0f;
          groundedPlayer = false;
          jumpCount++;
          playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
  	    }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if(Keyboard.current.aKey.wasPressedThisFrame && rotateFlag){ //if d is pressed and facing left
  	      rb.transform.Rotate(new Vector3(0f, 180f, 0f)); //face right
  				rotateFlag = false; //if false player facing right
  	    }
  			if(Keyboard.current.dKey.wasPressedThisFrame && !rotateFlag){ //if d is pressed and facing right
  	      rb.transform.Rotate(new Vector3(0f, 180f, 0f)); //face left
  				rotateFlag = true; //if false player facing left
  	    }
        controller.Move(move * Time.deltaTime * speed);
      }

      private void OnTriggerEnter(Collider other)
      {
        if (other.gameObject.name == "Ground Trigger")
        {
          groundedPlayer = true;
          Debug.Log("ground");
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
