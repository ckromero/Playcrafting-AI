using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour
{
	[Range (0f, 5f)]
	public float timeToDestroy = 3f;

	// Use this for initialization
	private void Start ()
	{
		Invoke ("DestroySelf", timeToDestroy);
	}

	private void DestroySelf ()
	{
		Destroy (gameObject);
	}
}
