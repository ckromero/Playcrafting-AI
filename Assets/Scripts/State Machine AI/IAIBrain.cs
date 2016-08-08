using UnityEngine;
using System.Collections;

public interface IAIBrain
{

	/// <summary>
	/// Attempts to set the behavior as an active behavior.  Check fails if the behavior is 
	/// already active.
	/// </summary>
	/// <param name="behavior">The behavior to set as active</param>
	/// <returns>False if it is already active</returns>
	bool SetBehaviorAsActive (IAIBehavior behavior);

	/// <summary>
	/// Checks to see if the current behavior is in the active set.
	/// </summary>
	bool IsBehaviorActive (IAIBehavior behavior);

	#region Monobehavior Calls

	/// <summary>
	/// Gets the transform.
	/// </summary>
	/// <value>The transform.</value>
	Transform transform { get; }

	/// <summary>
	/// Gets the game object.
	/// </summary>
	/// <value>The game object.</value>
	GameObject gameObject { get; }

	/// <summary>
	/// Gets the component.
	/// </summary>
	/// <returns>The component.</returns>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	T GetComponent<T> ();

	/// <summary>
	/// Gets the first component in children.
	/// </summary>
	/// <returns>The component in children.</returns>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	T GetComponentInChildren<T> ();

	/// <summary>
	/// Gets the components in children.
	/// </summary>
	/// <returns>The components in children.</returns>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	T[] GetComponentsInChildren<T> ();

	#endregion
}
