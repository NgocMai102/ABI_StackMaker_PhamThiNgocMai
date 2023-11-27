using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerAnim
{ 
    Idle = 0, 
    Jump = 1,
    Cheer = 2,
}
    
public enum Direction
{
    None = 0,
    Forward = 1,
    Back = 2,
    Right = 3,
    Left = 4,
}

public enum EventID
{
    OnCompleteLevel = 0,
    OnNextLevel = 1,
    OnResetLevel = 2,
}

public enum DataType
{
    Coin = 0,
    Level = 1,
}

public enum SoundType {
    GetBrick = 0,
    Move = 1,
    OpenChest = 2,
    OpenUI = 3,
}


