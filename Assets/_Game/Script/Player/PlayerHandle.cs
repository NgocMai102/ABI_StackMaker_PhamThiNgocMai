using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class PlayerHandle : MonoBehaviour
{
    [SerializeField] private Player player;
    // Start is called before the first frame update
    private Vector3 directionMovement;
    private Vector3 mouseDownPosition;
    // Update is called once per frame
    public void Update()
    {
        if (player.PlayerMovement.IsMoving)
        {
            return;
        }
        PutHandle();
    }

    private void PutHandle()
    {
       
        if (Input.GetMouseButtonDown(0))
            mouseDownPosition = Input.mousePosition;
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 currentMousePosition = Input.mousePosition; 
            Vector3 moveDirection = currentMousePosition - mouseDownPosition;
            if (moveDirection.magnitude >= 10f)
            { mouseDownPosition = currentMousePosition;
                PlayerMoveNavigate(moveDirection);
            }
        }
        
    }

    private void PlayerMoveNavigate(Vector3 directionVector)
    {
        Direction moveDirection;
        if (Mathf.Abs(directionVector.x) > Mathf.Abs(directionVector.y))
        {
            if (directionVector.x < 0)
            {
                moveDirection = Direction.Left;
            }
            else
            {
                moveDirection = Direction.Right;
            }
        }
        else
        {
            if (directionVector.y > 0)
            {
                moveDirection = Direction.Forward;
            }
            else
            {
                moveDirection = Direction.Back;
            }
        }
        player.PlayerAction.MoveInDirection(moveDirection);
    }
}
