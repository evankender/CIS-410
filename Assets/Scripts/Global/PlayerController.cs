using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour {

	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
  public InputAction wasd;
	private bool aFlag = true;
	private bool dFlag = false;

  public CharacterController controller;
	private Rigidbody rb;

  void Start()
  {
      controller = GetComponent<CharacterController>();
			rb = this.GetComponent<Rigidbody>();
  }

  void OnEnable()
  {
    wasd.Enable();
  }

  void OnDisable()
  {
    wasd.Disable();
  }

  void Update()
  {
    Vector2 inputVector = wasd.ReadValue<Vector2>();
    Vector3 moveVector = new Vector3();

    moveVector.x = inputVector.x;
    moveVector.z = 0;
    moveVector.y = 0;
		if(Keyboard.current.dKey.wasPressedThisFrame && !dFlag){
      rb.transform.Rotate(new Vector3(0f, 180f, 0f));
			aFlag = false;
			dFlag = true;
    }
		if(Keyboard.current.aKey.wasPressedThisFrame && !aFlag){
      rb.transform.Rotate(new Vector3(0f, 180f, 0f));
			aFlag = true;
			dFlag = false;
    }
    controller.Move(moveVector * Time.deltaTime * speed);
  }

}
