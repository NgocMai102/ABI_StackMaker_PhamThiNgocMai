using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SoundManager.Instance.Play(SoundType.GetBrick);
            other.GetComponent<Player>().PlayerAction.Take();
            this.gameObject.SetActive(false);
        }
    }
}
