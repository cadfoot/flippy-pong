using FlippyPong.Gameplay;
using UnityEditor;
using UnityEngine;

namespace FlippyPong
{
    [CustomEditor(typeof(RandomForce))]
    public class RandomForceEditor : Editor
    {
        private SerializedProperty _forceMin;
        private SerializedProperty _forceMax;

        private void OnEnable()
        {
            _forceMin = serializedObject.FindProperty(nameof(_forceMin));
            _forceMax = serializedObject.FindProperty(nameof(_forceMax));
        }

        public override void OnInspectorGUI()
        {
            var minValue = _forceMin.floatValue;
            var maxValue = _forceMax.floatValue;


            GUI.enabled = false;
            EditorGUILayout.FloatField("Min", minValue);
            EditorGUILayout.FloatField("Max", maxValue);
            GUI.enabled = true;
            
            EditorGUILayout.MinMaxSlider("Force Range", ref minValue, ref maxValue, 0, 10);

            Undo.RegisterCompleteObjectUndo(target, "Force Range change");
            
            _forceMin.floatValue = minValue;
            _forceMax.floatValue = maxValue;

            serializedObject.ApplyModifiedProperties();
        }
    }
}