using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public Vector3 TargetPosition { get; set; }
    public Direction TargetDirection;
    public Vector3 startPos;
    
    public bool IsMoving => TargetDirection != Direction.None;
    
    private void Awake()
    {
        OnInit();
    }
    
    private void FixedUpdate()
    {
        if (TargetDirection == Direction.None)
        {
            return;
        }
        MoveToTarget();
       
    }

    void OnInit()
    {
        TargetPosition = transform.position;
        startPos = transform.position;
    }

    void MoveToTarget()
    {
        Vector3 originPosition = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, Time.deltaTime * moveSpeed);
        if (VectorUtils.CheckAproximate(transform.position, TargetPosition))
        {
            TargetDirection = Direction.None;
        }
    }

    public void RaycastInDirection(Direction direction)
    {
        RaycastHit hit;
        Vector3 directionVector = VectorUtils.DirectionVectorOf(direction);
        Physics.Raycast(transform.position, directionVector, out hit, 1000f);
        TargetDirection = direction;
        // TargetPosition = hit.transform.position + Vector3.up * 2.46f - directionVector;
        TargetPosition = hit.transform.position - directionVector;
        if (VectorUtils.CheckAproximate(TargetPosition, transform.position))
        {
            TargetPosition = transform.position;
        }
    }
    
    public void ResetTransform()
    {
        // transform.position = startPos;
        // transform.parent.position = transform.position;
        // transform.rotation = Quaternion.identity;
    }
}

