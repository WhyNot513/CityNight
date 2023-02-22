using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<playerController>(out playerController player))
        {
            player.CanLadder = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<playerController>(out playerController player))
        {
            player.CanLadder = false;

        }
    }


}
