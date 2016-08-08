using UnityEngine;
using System.Collections;

public class EnemyHealth : Health
{

	public GameObject deathParticles;

	public override void Die ()
	{
		base.Die ();
		Instantiate (deathParticles, transform.position, Quaternion.identity);
	}
}
