using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{
	public float moveSpeed = 10;
	public float rotateSpeed = 10;

	private Rigidbody rigidBody;

	void Start ()
	{
		rigidBody = GetComponent<Rigidbody>();
	}
	
	void Update ()
	{
		Vector3 moveVelocity = new Vector3(0,0,0);

		HandleMoveKey(ref moveVelocity, transform.forward, KeyCode.W);
		HandleMoveKey(ref moveVelocity, -transform.forward, KeyCode.S);

		HandleRotateKey(KeyCode.A, -rotateSpeed);
		HandleRotateKey(KeyCode.D, rotateSpeed);

		rigidBody.velocity = moveVelocity;
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

