using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTaker : MonoBehaviour
{
    [SerializeField] private GameObject brickPrefab;
    [SerializeField] private GameObject playerImg;
    [SerializeField] private GameObject firstBrick;
    private Stack<GameObject> brickStack;
    public int CollectedBrick => brickStack.Count;
    public Vector3 firstBrickPos;
    public Vector3 startPos;

    void Awake()
    {
        OnInit();
    }

    private void OnInit()
    {
        brickStack = new Stack<GameObject>();
        brickStack.Push(firstBrick);
        firstBrickPos = firstBrick.transform.position;
        startPos = playerImg.transform.position;
    }
    

    public void AddBrick()
    {
        GameObject brick;
        
        if (brickStack.Count != 0)
        {
            Vector3 topBrickPos = brickStack.Peek().transform.position;
            Vector3 newBrickPos = new Vector3(topBrickPos.x, topBrickPos.y + BrickUtils.THICKNESS, topBrickPos.z);
            brick = Instantiate(brickPrefab, newBrickPos, BrickUtils.ROTATION);
            brick.transform.parent = this.transform;
            //firstBrickPos = new Vector3(this.transform.position.x, this.transform.position.y + BrickUtils.THICKNESS, this.transform.position.z);
            MovePlayer(playerImg, BrickUtils.THICKNESS);
            brickStack.Push(brick);
            
            return;
        }

    }

    public void MovePlayer(GameObject image, float offset)
    {
        Vector3 imagePos = image.transform.position;
        image.transform.position = new Vector3(imagePos.x, imagePos.y + offset, imagePos.z);
    }
    
    
    public void RemoveBrick()
    {
        // if (brickStack.Count == 0)
        // {
        //     return;
        // }
        Destroy(brickStack.Pop());
        MovePlayer(playerImg, -BrickUtils.THICKNESS);
        
    }

    public void RemoveAllBrick()
    {
        while (brickStack.Count > 0)
        {
            RemoveBrick();
        }
    }

    public void Win()
    {
        RemoveAllBrick();
        MovePlayer(playerImg, -BrickUtils.THICKNESS);
    }

    public void ResetTransform()
    {
        //playerImg.transform.position = startPos;
        //MovePlayer(playerImg, BrickUtils.THICKNESS);
        firstBrick = Instantiate(brickPrefab, firstBrickPos, BrickUtils.ROTATION);
        firstBrick.transform.parent = this.transform;
        brickStack.Push(firstBrick);
    }
}
