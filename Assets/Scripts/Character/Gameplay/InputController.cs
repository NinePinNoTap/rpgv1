using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
	public float moveSpeed = 10;
	public float rotateSpeed = 10;
	public float fallSpeed = 10;

	private CharacterController characterController;

	void Start ()
	{
		characterController = GetComponent<CharacterController>();
	}
	
	void Update ()
	{
		Vector3 moveVelocity = new Vector3(0,0,0);

		// Forward / Backward
		HandleMoveKey(ref moveVelocity, transform.forward, KeyCode.W);
		HandleMoveKey(ref moveVelocity, -transform.forward, KeyCode.S);

		// Turn Left / Right
		HandleRotateKey(KeyCode.A, -rotateSpeed);
		HandleRotateKey(KeyCode.D, rotateSpeed);

		// Gravity
		moveVelocity.y -= fallSpeed;

		moveVelocity *= Time.deltaTime;

		characterController.Move(moveVelocity);
	}

	void HandleMoveKey(ref Vector3 moveVelocity, Vector3 moveDirection, KeyCode key)
	{
		if(Input.GetKey(key))
		{
			moveVelocity += moveDirection * moveSpeed;
		}
	}

	void HandleRotateKey(KeyCode key, float amount)
	{
		if(Input.GetKey(key))
		{
			transform.Rotate(new Vector3(0, amount, 0));
		}
	}
}