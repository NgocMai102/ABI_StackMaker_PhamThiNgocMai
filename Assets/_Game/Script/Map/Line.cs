using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private GameObject lineYellowPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SoundManager.Instance.Play(SoundType.GetBrick);
            other.GetComponent<Player>().PlayerAction.Throw();
            GameObject yellowBrick = Instantiate(lineYellowPrefab, transform.position, LineUtils.ROTATION);
            yellowBrick.transform.SetParent(transform.parent);
            this.gameObject.SetActive(false);
        }
    }
}
