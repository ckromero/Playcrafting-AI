using UnityEngine;
using System.Collections;

public class Attack : AIBehavior
{
	public float minimalDistance = 2f;
	public float minimalAngle = 180f;

	private Transform playerTransform;
	private float distanceBetweenTarget;

	private void OnEnable ()
	{
		playerTransform = GameObject.FindWithTag ("Player").transform;
	}

	protected override void OnBehaviorStart ()
	{
		SetDistance ();
	}

	protected override BehaviorState OnBehaviorUpdate ()
	{
		SetDistance ();

		if (distanceBetweenTarget > minimalDistance) {
			animator.SetTrigger ("Move");
			return BehaviorState.Done;
		}
		return BehaviorState.Running;
	}

	protected override void OnBehaviorEnd ()
	{
		aiBrain.transform.LookAt (playerTransform);
	}

	private void SetDistance ()
	{
		distanceBetweenTarget = Vector3.Distance (playerTransform.position, aiBrain.transform.position);
	}
}
