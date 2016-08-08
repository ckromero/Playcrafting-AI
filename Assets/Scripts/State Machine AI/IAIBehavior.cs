using UnityEngine;
using System.Collections;

/// <summary>
/// Simple interface to describe an AI Behavior
/// </summary>
public interface IAIBehavior {

    string name { get; }

    void Stop();
}
