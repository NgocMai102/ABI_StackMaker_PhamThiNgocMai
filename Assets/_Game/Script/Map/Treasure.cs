using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    [SerializeField] private GameObject openingChest;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().PlayerAction.AtWinZone();
            Invoke(nameof(OpenChest), 1f);
            Invoke(nameof(nextLevel), 1f);
        }
    }
    

    void OpenChest()
    {
        Instantiate(openingChest, transform.position, ChestUtils.ROTATION);
        SoundManager.Instance.Play(SoundType.OpenChest);
        this.gameObject.SetActive(false);
    }

    void nextLevel()
    {
        GameManager.Instance.EmitCompleteLevelEvent();
    }
}
