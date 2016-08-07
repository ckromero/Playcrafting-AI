using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{

	public float maxHealth = 100f;

	private float currentHealth;

	private void Awake ()
	{
		currentHealth = maxHealth;
	}

	public void Damage (float amount)
	{
		if (amount <= 0f) {
			return;
		}

		currentHealth -= amount;

		if (currentHealth <= 0f) {
			Die ();	
		}
	}

	public virtual void Die ()
	{
		Destroy (gameObject);
	}
}
