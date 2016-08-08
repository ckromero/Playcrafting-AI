using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	[Range (0f, 100f)]
	public float damage = 34f;

	private Collider weaponCollider;

	// Use this for initialization
	private void Start ()
	{
		weaponCollider = GetComponent<Collider> ();
		weaponCollider.isTrigger = true;
	}

	private void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Player")) {
			var health = other.GetComponent<Health> ();

			if (health != null) {
				health.Damage (damage);
			}
		}
	}
}
