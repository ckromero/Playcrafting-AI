using UnityEngine;
using System.Collections.Generic;


/// <summary>
/// The "brain" of the AI.  Handles what behavior is running and what isn't.
/// </summary>
public class AIBrain : MonoBehaviour, IAIBrain
{

	/// <summary>
	/// The set of all active behaviors.  A behavior must be active to be able to run.
	/// </summary>
	private HashSet<IAIBehavior> activeBehaviors;


	private void Awake ()
	{
		
		activeBehaviors = new HashSet<IAIBehavior> ();

		GameManager.instance.AddLivingEnemies (this.name);

	}

	/// <summary>
	/// Attempts to set the behavior as an active behavior.  Check fails if the behavior is 
	/// already active.
	/// </summary>
	/// <param name="behavior">The behavior to set as active</param>
	/// <returns>False if it is already active</returns>
	public bool SetBehaviorAsActive (IAIBehavior behavior)
	{
		return activeBehaviors.Add (behavior);
	}

	/// <summary>
	/// Checks to see if the current behavior is in the active set.
	/// </summary>
	public bool IsBehaviorActive (IAIBehavior behavior)
	{
		return activeBehaviors.Contains (behavior);
	}

	/// <summary>
	/// Attempts to stop the behavior from running
	/// </summary>
	/// <param name="behavior">The behavior to stop</param>
	public void StopBehavior (IAIBehavior behavior)
	{
		if (activeBehaviors.Contains (behavior)) {
//			behavior.Stop ();
			activeBehaviors.Remove (behavior);
		}
	}


}
