using UnityEngine;
using System.Collections;
using System;

public class WinCheck : AIBehavior {

    private Health playerHealth;

    private bool isDead;
    private bool isInvoked;


    private void OnEnable() {
        isDead = false;
        isInvoked = false;
    }

    protected override void OnBehaviorStart() {
        if(playerHealth == null) {
            playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
        }
    }

    protected override BehaviorState OnBehaviorUpdate() {
        if(playerHealth.CurrentHealth <= 0) {
            isDead = true;
            return BehaviorState.Done;
        }

        return BehaviorState.Running;
    }

    protected override void OnBehaviorEnd() {
        if(isDead && !isInvoked) {
            animator.SetTrigger("Win");
            isInvoked = true;
        }
    }
}
