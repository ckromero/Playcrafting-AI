using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class Motor : MonoBehaviour
{
	public string horizontalInput = "Horizontal";
	public string verticalInput = "Vertical";
	public float speed = 6f;

	private CharacterController characterController;

	private void Start ()
	{
		characterController = GetComponent<CharacterController> ();
	}

	void Update ()
	{
		Move ();
	}

	private void Move ()
	{
		var motion = new Vector3 (Input.GetAxis (horizontalInput), 0, Input.GetAxis (verticalInput));
		motion = transform.TransformDirection (motion);
		motion *= (speed * Time.deltaTime);

		characterController.Move (motion);
	}

	private void Turn ()
	{
	}
}
