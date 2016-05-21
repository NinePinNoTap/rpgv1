using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
    [Header("Movement")]
	public float moveSpeed = 10;
	public float rotateSpeed = 10;
	public float fallSpeed = 10;

    [Header("Keys")]
    public KeyCode bagKey = KeyCode.B;

    [Header("Flags")]
    public bool showBag = false;

	private CharacterController characterController;

	void Start ()
	{
		characterController = GetComponent<CharacterController>();

        UIManager.Instance.HideInventory();
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

        if(Input.GetKeyDown(bagKey))
        {
            showBag = !showBag;
            if(showBag)
                UIManager.Instance.ShowInventory();
            else
                UIManager.Instance.HideInventory();
        }
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