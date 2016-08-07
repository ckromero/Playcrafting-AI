using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	public Transform target;
	[Range (0f, 10f)]
	public float cameraDampening = 5f;

	private Vector3 cameraOffset;

	// Use this for initialization
	private void Start ()
	{
		if (target == null) {
			target = GameObject.FindGameObjectWithTag ("Player").transform;
		}
		cameraOffset = transform.position - target.position;
	}
	
	// Update is called once per frame
	private void Update ()
	{
		var cameraPosition = target.position + cameraOffset;

		transform.position = Vector3.Lerp (transform.position, cameraPosition, cameraDampening * Time.deltaTime);
	}
}
