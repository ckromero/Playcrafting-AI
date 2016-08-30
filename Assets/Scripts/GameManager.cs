using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;

	private List<string> livingEnemies = new List<string>();

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}


	public void AddLivingEnemies (string objName) {
		livingEnemies.Add (objName);
		Debug.Log ("livingEnemies just added " + objName);
	}
	public void removeEnemies (string objName){
		livingEnemies.Remove (objName);
		Debug.Log ("livingEnemies just removed " + objName);
	}

	// Update is called once per frame
	void Update () {
		if (livingEnemies.Count == 0) {
			Debug.Log ("YOU WIN!!!");
		} else {
			for (int i = 0; i < livingEnemies.Count; i++) {
				Debug.Log ("Living Enemy " + livingEnemies [i] + " is still alive");
			}
		}
	}
}
