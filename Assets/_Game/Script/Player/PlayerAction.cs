using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Rigidbody rb;
    
    private Vector3 startPosition;
    public bool IsCheering => player.PlayerAnimation.CurrentAnim == PlayerAnim.Cheer;
    void Update()
    {
        
    }

    public void Awake()
    {
        startPosition = transform.position;
        GameManager.Instance.OnEventEmitted += OnEventEmitted;
    }

    public void Start()
    {
        
    }
    
    private void OnEventEmitted(EventID eventID)
    {
        switch (eventID)
        {
            case EventID.OnNextLevel:
                StartCoroutine(ResetPlayer());
                break;
            case EventID.OnCompleteLevel:
                LockAtChest();
                ClearBrick();
                break;
            case EventID.OnResetLevel:
                ClearBrick();
                StartCoroutine(ResetPlayer());
                break;
        }
    }

    public void Idle()
    {
        if (player.PlayerAnimation.CurrentAnim == PlayerAnim.Cheer)
        {
            return;
        }
        player.PlayerAnimation.ChangeAnim(PlayerAnim.Idle);
    }

    public void Cheer()
    {
        player.PlayerAnimation.ChangeAnim(PlayerAnim.Cheer);
    }

    public void Jump()
    {
        if (player.PlayerAnimation.CurrentAnim == PlayerAnim.Jump)
        {
            return;
        }
        player.PlayerAnimation.ChangeAnim(PlayerAnim.Jump);
        Invoke(nameof(Idle), GameAnim.Duration.JUMP);
    }

    public void Take()
    {
        Jump();
        player.PlayerTaker.AddBrick();
    }
    
    public void Throw()
    {
        player.PlayerTaker.RemoveBrick();
    }
    
    public void MoveInDirection(Direction direction)
    {
        player.PlayerMovement.RaycastInDirection(direction);
    }

    public void StopMovingAt(Vector3 stopPosition)
    {
        SoundManager.Instance.Mute(SoundType.GetBrick);
        player.PlayerMovement.TargetDirection = Direction.None;
        player.PlayerMovement.TargetPosition = stopPosition;
        player.transform.position = stopPosition;
    }

    public void AtWinZone()
    {
        StopMovingAt(transform.position - ChestUtils.OFFSET);
        transform.rotation = Quaternion.Euler(0f, -150f, 0f);
    }

    public void ClearBrick()
    {
        player.PlayerTaker.RemoveAllBrick();
    }

    public void ColliderFinishLine()
    {
        Cheer();
        player.PlayerTaker.Win();
    }

    public void StopMoving()
    {
        SoundManager.Instance.Mute(SoundType.GetBrick);
    }

    private void LockAtChest()
    {
        transform.rotation = Quaternion.Euler(0f, -150f, 0f);
    }

    private IEnumerator ResetPlayer()
    {
        StopMoving();
        
        player.transform.position = startPosition;
        player.PlayerAnimation.ChangeAnim(PlayerAnim.Idle);
        player.PlayerTaker.ResetTransform();
        
        yield return new WaitForSeconds(0.5f);
    }
}
