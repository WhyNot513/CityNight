using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jianchi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<playerController>().statebar.UpdateStats(0, collision.gameObject.GetComponent<playerController>().MaxHealth);
            collision.gameObject.GetComponent<playerController>().CurrentHealth = 100;
            GameManager.Instance.gameState = GameState.GameOver;
        }
    }
}
