using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class Motor : MonoBehaviour
{
	public string horizontalInput = "Horizontal";
	public string verticalInput = "Vertical";
	public float speed = 6f;

    public bool useTankControls = false;

	private CharacterController characterController;
	private LayerMask groundMask;
	private float rayLength = 100f;

	private void Start ()
	{
		characterController = GetComponent<CharacterController> ();
		groundMask = LayerMask.GetMask ("Ground");
	}

	private void Update ()
	{
		Move ();

		Turn ();
	}

	private void Move ()
	{
		var motion = new Vector3 (Input.GetAxis (horizontalInput), 0, Input.GetAxis (verticalInput));
        if(useTankControls) {
            motion = transform.TransformDirection (motion);
        }
		motion *= (speed * Time.deltaTime);

		characterController.Move (motion);
	}

	private void Turn ()
	{
		var cameraRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit hitInfo;

		if (Physics.Raycast (cameraRay, out hitInfo, rayLength, groundMask)) {
			var direction = hitInfo.point - transform.position;

			direction.y = 0f;

			var quaternionRotation = Quaternion.LookRotation (direction);

			transform.rotation = quaternionRotation;
		}
	}
}
