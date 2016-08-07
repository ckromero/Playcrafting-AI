using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
	public Transform shotPosition;
	public string fireInputName = "Fire1";
	public float damagePerShot = 20f;
	public float timeBetweenShot = 0.15f;
	public float bulletRange = 100f;

	private float timer;

	// Use this for initialization
	private void Start ()
	{
	
	}
	
	// Update is called once per frame
	private void Update ()
	{
		timer += Time.deltaTime;

		if (Input.GetButton (fireInputName) && timer >= timeBetweenShot) {
			Shoot ();
		}
	}

	private void Shoot ()
	{
		timer = 0f;

		var cameraRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit hitInfo;

		Debug.DrawRay (shotPosition.position, shotPosition.forward, Color.blue);

		if (Physics.Raycast (shotPosition.position, shotPosition.forward, out hitInfo, bulletRange)) {
		}
	}
}
