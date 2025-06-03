using System.Collections.Generic;
using UnityEngine;

public class SnakeModel
{
    public List<Transform> BodyParts { get; private set; } = new();
    public float MoveSpeed = 5f;
    public float RotationSpeed = 200f;
    public float BodySpacing = 0.5f;

    public SnakeModel(Transform head)
    {
        BodyParts.Add(head);
    }

    public void AddBodyPart(Transform part)
    {
        BodyParts.Add(part);
    }
}