using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerAction playerAction;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerAnimation playerAnimation;
    [SerializeField] private PlayerHandle playerHandle;
    [SerializeField] private PlayerTaker playerTaker;
    
    public PlayerAction PlayerAction { get => playerAction; }
    public PlayerMovement PlayerMovement { get => playerMovement; }
    public PlayerAnimation PlayerAnimation { get => playerAnimation; }
    public PlayerHandle PlayerHandle { get => playerHandle; }
    public PlayerTaker PlayerTaker { get => playerTaker; }

    
}
