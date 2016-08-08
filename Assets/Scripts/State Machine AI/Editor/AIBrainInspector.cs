using UnityEngine;
using UnityEditor;
using System.Linq;

/// <summary>
/// The custom brain editor.  Allows users to see the current brain information in the editor.
/// </summary>
[CustomEditor(typeof(AIBrain))]
public class AIBrainInspector : Editor {

    private AIBrain brain;
    private Animator animator;

    private bool allowActiveBehaviors = true;
    private bool allowInactiveBehaviors = true;


    private void OnEnable() {
        brain = (AIBrain)target;
        animator = brain.GetComponent<Animator>();
    }

    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        if(brain != null) {
            InspectBrainInfo();
        }
    }


    private void InspectBrainInfo() {
        var behaviors = animator.GetBehaviours<AIBehavior>();

        EditorGUILayout.LabelField(string.Format("Number of Behaviors: {0}", behaviors.Length), 
            EditorStyles.boldLabel);

        DisplayActiveBehaviors(behaviors);
        DisplayInactiveBehaviors(behaviors);
    }

    private void DisplayActiveBehaviors(AIBehavior[] behaviors) {
        allowActiveBehaviors = EditorGUILayout.Foldout(allowActiveBehaviors, "Active Behaviors");
        if(allowActiveBehaviors) {

            var activeBehaviors = ( from b in behaviors
                                    where brain.IsBehaviorActive(b)
                                    select b ).ToArray();

            if(activeBehaviors != null && activeBehaviors.Length > 0) {
                EditorGUI.indentLevel++;

                foreach(var behavior in activeBehaviors) {
                    EditorGUILayout.LabelField(behavior.name);
                }

                EditorGUI.indentLevel--;
            }
            else {
                EditorGUILayout.LabelField("None");
            }
        }
    }

    private void DisplayInactiveBehaviors(AIBehavior[] behaviors) {
        allowInactiveBehaviors = EditorGUILayout.Foldout(allowInactiveBehaviors, "Inactive Behaviors");
        if(allowInactiveBehaviors) {
            var inactiveBehaviors = ( from b in behaviors
                                      where !brain.IsBehaviorActive(b)
                                      select b ).ToArray();

            if(inactiveBehaviors != null && inactiveBehaviors.Length > 0) {
                EditorGUI.indentLevel++;

                foreach(var behavior in inactiveBehaviors) {
                    EditorGUILayout.LabelField(behavior.name);
                }

                EditorGUI.indentLevel--;
            }
            else {
                EditorGUILayout.LabelField("None");
            }
        }
    }

}
