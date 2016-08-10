using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
	public Transform shotPosition;
	public string fireInputName = "Fire1";
	public float weaponDamage = 20f;
	public float timeBetweenShot = 0.15f;
	public float bulletRange = 100f;

	private Ray shotRay;
	private RaycastHit hitInfo;
	private LayerMask mask;
	private LineRenderer line;
	private Light gunLight;
	private float timer;
	private float effectsDisplayTime = 0.2f;

	// Use this for initialization
	private void Start ()
	{
		gunLight = shotPosition.GetComponent<Light> ();
		line = shotPosition.GetComponent<LineRenderer> ();
		mask = LayerMask.GetMask ("Shootable");
	}
	
	// Update is called once per frame
	private void Update ()
	{
		timer += Time.deltaTime;

		if (Input.GetButton (fireInputName) && timer >= timeBetweenShot) {
			Shoot ();
		}

		if (timer >= timeBetweenShot * effectsDisplayTime) {
			DisableEffects ();
		}
	}

	private void EnableEffects ()
	{
		gunLight.enabled = true;
		line.enabled = true;
	}

	private void DisableEffects ()
	{
		gunLight.enabled = false;
		line.enabled = false;
	}


	private void Shoot ()
	{
		// Reset our timer
		timer = 0f;

		// Enable certain effects like the lineRenderer and light
		EnableEffects ();

		// Assign certain values and properties to our Ray
		shotRay.origin = shotPosition.position;
		shotRay.direction = shotPosition.forward;

		// Set the position of the lineRenderer's starting point
		line.SetPosition (0, shotRay.origin);

		if (Physics.Raycast (shotRay, out hitInfo, bulletRange, mask)) {
			var enemyHealth = hitInfo.transform.root.GetComponent<Health> ();

			if (enemyHealth != null) {
				enemyHealth.Damage (weaponDamage);
			}

			// If we hit something, then our line renderer should be drawn to that point we hit
			line.SetPosition (1, hitInfo.point);
		} else {
			// Otherwise
			line.SetPosition (1, shotRay.origin + shotRay.direction * bulletRange);
		}
	}
}
