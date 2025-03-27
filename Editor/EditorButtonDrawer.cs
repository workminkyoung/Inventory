using UnityEditor;
using UnityEngine;
using System.Reflection;

[CustomEditor(typeof(MonoBehaviour), true)]
public class EditorButtonDrawer : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var type = target.GetType();
        var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        foreach (var method in methods)
        {
            var attribute = method.GetCustomAttribute<EditorButtonAttribute>();
            if (attribute != null)
            {
                if (GUILayout.Button(attribute.ButtonLabel))
                {
                    method.Invoke(target, null);
                }
            }
        }
    }
}
