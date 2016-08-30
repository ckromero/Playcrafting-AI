using UnityEngine;
using System.Collections;

public class EnemyHealth : Health
{

	public GameObject deathParticles;

	public override void Die ()
	{
		var brain = GetComponent<AIBrain> ();
		var anim = GetComponent<Animator> ();
		var navAgent = GetComponent<NavMeshAgent> ();

		// Disable the NavMeshAgent
		navAgent.enabled = false;

		//Disable the brain, animator
		brain.enabled = false;
		anim.enabled = false;

		Destroy (gameObject, deathParticles.GetComponent<ParticleController> ().timeToDestroy);
		Instantiate (deathParticles, transform.position, Quaternion.identity);

		GameManager.instance.removeEnemies (this.name);
	}
}
