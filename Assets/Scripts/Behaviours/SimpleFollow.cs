using UnityEngine;
using System.Collections;

public class SimpleFollow : AIBehavior
{
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
		navAgent.SetDestination (playerTransform.position);

		Debug.LogFormat ("Remaining: {0}, Stopping: {1}", navAgent.remainingDistance, navAgent.stoppingDistance);

		if (navAgent.remainingDistance < navAgent.stoppingDistance) {
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
