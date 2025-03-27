using UnityEngine;
using System;

[AttributeUsage(AttributeTargets.Method)]
public class EditorButtonAttribute : Attribute
{
    public string ButtonLabel { get; }

    public EditorButtonAttribute(string label = "Execute")
    {
        ButtonLabel = label;
    }
}
