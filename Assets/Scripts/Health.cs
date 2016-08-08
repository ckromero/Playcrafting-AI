using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{

	/// <summary>
	/// Amount of health we want to give to this character
	/// </summary>
	public float maxHealth = 100f;

	/// <summary>
	/// Internal value of the health
	/// </summary>
	public float CurrentHealth { get; private set; }

	protected virtual void Start ()
	{
		CurrentHealth = maxHealth;
	}

	/// <summary>
	/// Applies a damage value to the health.
	/// </summary>
	/// <param name="amount">Amount of damage done to the health</param>
	public void Damage (float amount)
	{
		if (amount <= 0f) {
			return;
		}

		CurrentHealth -= amount;

		if (CurrentHealth <= 0f) {
			Die ();	
		}
	}

	/// <summary>
	/// Action to execute when the health reaches below 0.
	/// </summary>
	public virtual void Die ()
	{
		Destroy (gameObject);
	}
}
