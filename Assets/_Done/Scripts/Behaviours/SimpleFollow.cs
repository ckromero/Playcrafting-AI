using UnityEngine;
using System.Collections;

public class SimpleFollow : AIBehavior
{
    [Tooltip("How close is the AI to be considered 'close enough' to the player")]
    public float nearDistance = 1.25f;

	private Transform playerTransform;
	private NavMeshAgent navAgent;

	private void OnEnable ()
	{
		playerTransform = GameObject.FindWithTag ("Player").transform;
	}

	protected override void OnBehaviorStart ()
	{
		if (navAgent == null) {
			navAgent = animator.GetComponent<NavMeshAgent> ();
		}

		navAgent.SetDestination (playerTransform.position);
		navAgent.Resume ();
	}

	protected override BehaviorState OnBehaviorUpdate ()
	{
		if (navAgent != null) {
			navAgent.SetDestination (playerTransform.position);
		}

		if (Vector3.Distance(navAgent.transform.position, playerTransform.position) < navAgent.stoppingDistance) {
			navAgent.Stop ();
			animator.SetTrigger ("Attack");
			return BehaviorState.Done;
		}
		return BehaviorState.Running;
	}

	protected override void OnBehaviorEnd ()
	{
		navAgent.ResetPath ();
		navAgent.SetDestination (playerTransform.position);
	}
}
