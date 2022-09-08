using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MagnetField))]
public class SphereEditor : Editor {
	public override void OnInspectorGUI()
	{
		MagnetField field = (MagnetField) target;

		EditorGUILayout.Space();
		GUILayout.Label("Magnet field size.");
        EditorGUILayout.Space();

        field.fieldWidth = EditorGUILayout.Slider("Width", field.fieldWidth, .1f, 2f);
		field.fieldHeight = EditorGUILayout.Slider("Height", field.fieldHeight, .1f, 2f);

		EditorGUILayout.Space();
		EditorGUILayout.Space();
		GUILayout.Label("Magnet attractor variables.");
		EditorGUILayout.Space();

		field.direction = (Direction) EditorGUILayout.EnumPopup("Direction", field.direction); 
		field.acceleration = EditorGUILayout.Slider("Acceleration", field.acceleration, 1f, 10f);
		field.strength = EditorGUILayout.Slider("Strength", field.strength, 1f, 30f);
		field.maxSpeed = EditorGUILayout.Slider("Max speed", field.maxSpeed, 1f, 30f);
		field.powerOn = EditorGUILayout.Toggle("Power on", field.powerOn);

  		SerializedObject obj = new UnityEditor.SerializedObject(field);
		EditorGUILayout.PropertyField(obj.FindProperty("collider"));
		obj.ApplyModifiedProperties();
	
	}

} 