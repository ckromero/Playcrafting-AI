using UnityEngine;
using System.Collections;

public interface IAIBrain {

    /// <summary>
    /// Attempts to set the behavior as an active behavior.  Check fails if the behavior is 
    /// already active.
    /// </summary>
    /// <param name="behavior">The behavior to set as active</param>
    /// <returns>False if it is already active</returns>
    bool SetBehaviorAsActive(IAIBehavior behavior);

    /// <summary>
    /// Checks to see if the current behavior is in the active set.
    /// </summary>
    bool IsBehaviorActive(IAIBehavior behavior);
}
