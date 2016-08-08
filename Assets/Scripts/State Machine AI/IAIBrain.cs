using UnityEngine;
using System.Collections;

public interface IAIBrain {

    bool SetBehaviorAsActive(IAIBehavior behavior);
    bool IsBehaviorActive(IAIBehavior behavior);
}
