using UnityEngine;
using System.Collections;

/// <summary>
/// Simple interface to describe an AI Behavior
/// </summary>
public interface IAIBehavior {

    /// <summary>
    /// The name of the behavior
    /// </summary>
    string name { get; }

    /// <summary>
    /// Stops the behavior and performs internal sanity tasks.
    /// </summary>
    void Stop();
}
