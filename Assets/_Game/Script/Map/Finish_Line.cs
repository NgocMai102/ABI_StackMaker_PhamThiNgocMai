using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish_Line : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().PlayerAction.ColliderFinishLine();
            
        }
    }
}
