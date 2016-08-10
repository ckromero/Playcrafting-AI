using UnityEngine;
using System.Collections;

public class CameraHealthEffect : MonoBehaviour {

    public Health playerHealth;
    public float shakeDuration = 0.5f;
    public float shakeIntensity = 0.25f;

    private Coroutine routine;
    private Vector3 startPosition;

    
    private void Start() {
        if(playerHealth != null) {
            playerHealth.OnDamageHealth += HandleDamageHealth;
        }
    }

    private void OnDisable() {
        if(playerHealth != null) {
            playerHealth.OnDamageHealth -= HandleDamageHealth;
        }
    }


    private void HandleDamageHealth(float damage) {
        if(routine != null) {
            StopCoroutine(routine);
        }
        routine = StartCoroutine(ShakeCamera());
    }

    private IEnumerator ShakeCamera() {
        var timer = 0f;

        while(timer < shakeDuration) {
            transform.localPosition = transform.localPosition + new 
                Vector3(Random.Range(-shakeIntensity, shakeIntensity), 0f, Random.Range(-shakeIntensity, shakeIntensity));
            yield return null;
            timer += Time.deltaTime;
        }
    }

}
