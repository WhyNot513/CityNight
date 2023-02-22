using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winCore : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (player != null)
            {
                GameManager.Instance.gameState = GameState.Win;
            }

            this.gameObject.SetActive(false);
        }
    }
    private void OnDisable()
    {
        Debug.Log("赢了");
        //playerController.CanJume();
        if (boss != null)
            boss.SetActive(false);

    }

}
