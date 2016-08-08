using UnityEngine;
using System.Collections;

public class Attack : AIBehavior
{
	public float minimalDistance = 2f;
	public float minimalAngle = 180f;

	private Transform playerTransform;
	private float distanceBetweenTarget;
	private float angleBetweenTarget;

	private void OnEnable ()
	{
		playerTransform = GameObject.FindWithTag ("Player").transform;
	}

	protected override void OnBehaviorStart ()
	{
		SetPlayerInfo ();
	}

	protected override BehaviorState OnBehaviorUpdate ()
	{
		SetPlayerInfo ();

		// Debug.LogFormat ("Distance: {0}, Min Distance: {1}", distanceBetweenTarget, minimalDistance);

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

	private void SetPlayerInfo ()
	{
		distanceBetweenTarget = Vector3.Distance (playerTransform.position, aiBrain.transform.position);

		var direction = playerTransform.position - aiBrain.transform.position;
		angleBetweenTarget = Vector3.Angle (direction, aiBrain.transform.forward);
	}
}
