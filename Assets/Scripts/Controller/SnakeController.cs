using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private SnakeModel model;
    public SnakeView view;
    private List<Vector3> positions = new();

    [Range(1f, 10f)]
    public float followSpeedMultiplier = 4f;
    public float rotationSpeed = 180f;

    private Quaternion targetRotation;
    private bool isRotating = false;

    void Start()
    {
        model = new SnakeModel(transform);
        positions.Add(transform.position);
        GameEvents.OnAppleEaten += Grow;

        targetRotation = transform.rotation;

        Transform body = Instantiate(view.bodyPrefab);
        body.Rotate(-90f, 0f, 0f);
        body.position = transform.position - transform.forward * model.BodySpacing;
        model.AddBodyPart(body);

        Transform tail = Instantiate(view.tailPrefab);
        tail.Rotate(-90f, 0f, 0f);
        tail.position = body.position - transform.forward * model.BodySpacing;
        model.AddBodyPart(tail);
    }

    void Update()
    {
        HandleRotation();
        SmoothRotate();
        MoveForward();
        UpdateBodyParts();
    }

    void HandleRotation()
    {
        if (isRotating) return;

        if (Input.GetKeyDown(KeyCode.A))
        {
            targetRotation *= Quaternion.Euler(0, -90, 0);
            isRotating = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            targetRotation *= Quaternion.Euler(0, 90, 0);
            isRotating = true;
        }
    }

    void SmoothRotate()
    {
        if (!isRotating) return;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
        {
            transform.rotation = targetRotation;
            isRotating = false;
        }
    }

    void MoveForward()
    {
        float moveStep = model.MoveSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * moveStep);

        if (positions.Count == 0 || Vector3.Distance(positions[0], transform.position) > model.BodySpacing * 0.05f)
        {
            positions.Insert(0, transform.position);

            if (positions.Count > model.BodyParts.Count * 5)
                positions.RemoveAt(positions.Count - 1);
        }
    }

    void UpdateBodyParts()
    {
        for (int i = 1; i < model.BodyParts.Count; i++)
        {
            int pointIndex = Mathf.Min(i * Mathf.RoundToInt(model.BodySpacing / 0.1f), positions.Count - 1);
            Vector3 targetPos = positions[pointIndex];

            model.BodyParts[i].position = Vector3.Lerp(
                model.BodyParts[i].position,
                targetPos,
                Time.deltaTime * model.MoveSpeed * followSpeedMultiplier
            );

            Vector3 direction = targetPos - model.BodyParts[i].position;
            if (direction != Vector3.zero)
            {
                Quaternion targetRot = Quaternion.LookRotation(direction);
                model.BodyParts[i].rotation = Quaternion.Slerp(
                    model.BodyParts[i].rotation,
                    targetRot,
                    Time.deltaTime * model.RotationSpeed
                );
            }
        }
    }

    void Grow()
    {
        Transform newBody = Instantiate(view.bodyPrefab);
        newBody.Rotate(-90f, 0f, 0f);

        Transform tail = model.BodyParts[^1];          
        Transform beforeTail = model.BodyParts[^2];    

        newBody.position = tail.position;
        newBody.rotation = tail.rotation;

        model.BodyParts.Insert(model.BodyParts.Count - 1, newBody);
    }
}
