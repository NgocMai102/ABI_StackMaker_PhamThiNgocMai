using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public PlayerAnim CurrentAnim { get; private set; }
    
    
    // Start is called before the first frame update
    void Awake()
    {
        
        CurrentAnim = PlayerAnim.Idle;
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ChangeAnim(PlayerAnim anim)
    {
        if (CurrentAnim != anim)
        {
            CurrentAnim = anim;
            animator.SetInteger("anim", (int)CurrentAnim);
        }
    }
}