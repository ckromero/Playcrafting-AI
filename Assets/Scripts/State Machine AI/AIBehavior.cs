using UnityEngine;
using System.Collections;

/// <summary>
/// Represents a state in the ai.  This state is just one action that
/// an AI can do e.g. walk to a destination or attack the player.
/// </summary>
public abstract class AIBehavior : StateMachineBehaviour, IAIBehavior
{
	/// <summary>
	/// A reference to the animator.
	/// </summary>
	/// <value>The animator.</value>
	protected Animator animator { get; private set; }

	/// <summary>
	/// A reference to the AIBrain that handles and executes a behavior.
	/// </summary>
	/// <value>The ai brain.</value>
	protected IAIBrain aiBrain { get; private set; }

	/// <summary>
	/// State of the AI, determines whether or not the brain is initialized or not.
	/// </summary>
	/// <value>The state of the current init.</value>
	private InitState CurrentInitState { get; set; }

	/// <summary>
	/// State of our behavior. Is the behavior running or done?
	/// </summary>
	public enum BehaviorState
	{
		Running,
		Done
	}

	/// <summary>
	/// Private states that tells whether or not the brain is active.
	/// </summary>
	private enum InitState
	{
		Uninitialized,
		Initialized
	}


	#region Overridable Methods

	/// <summary>
	/// Called when the behavior successfully starts.  Use this to do any tasks that need to be
	/// run before the update loop.
	/// </summary>
	protected abstract void OnBehaviorStart ();

	/// <summary>
	/// Functions similar to the Update() method.  Return BehaviorState.Done to finish update tasks.  Otherwise,
	/// just return BehaviorState.Running
	/// </summary>
	/// <returns>Behavior.Running if the task is still running.  Otherwise returns BehaviorState.Done</returns>
	protected abstract BehaviorState OnBehaviorUpdate ();

	/// <summary>
	/// Called when the behavior is stopped or finished running its update loop.  Use this for any task that
	/// needs to be done after the update loop or for cleanup.
	/// </summary>
	protected abstract void OnBehaviorEnd ();

	#endregion

	/// <summary>
	/// Stops the behavior and calls OnBehaviorEnd()
	/// </summary>
	public void Stop ()
	{
		OnBehaviorEnd ();
		aiBrain.StopBehavior (this);
	}

	#region State Machine Calls

	public sealed override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateEnter (animator, stateInfo, layerIndex);

		switch (CurrentInitState) {
		case InitState.Uninitialized:
			this.animator = animator;
			aiBrain = animator.GetComponent<IAIBrain> ();
			CurrentInitState = InitState.Initialized;
			if (aiBrain.SetBehaviorAsActive (this)) {
				OnBehaviorStart ();
			}
			break;

		case InitState.Initialized:
			if (aiBrain.SetBehaviorAsActive (this)) {
				OnBehaviorStart ();
			}
			break;
		}
	}

	public sealed override void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateUpdate (animator, stateInfo, layerIndex);

		if (aiBrain.IsBehaviorActive (this)) {
			var state = OnBehaviorUpdate ();

			if (state == BehaviorState.Done) {
				Stop ();
			}
		}
	}

	public sealed override void OnStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateExit (animator, stateInfo, layerIndex);

		if (aiBrain.IsBehaviorActive (this)) {
			OnBehaviorEnd ();
		}
	}

	#endregion
}
