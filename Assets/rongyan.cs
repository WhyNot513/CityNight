using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rongyan : MonoBehaviour
{
    public playerController player;
    public Coroutine coroutine;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        if (coroutine == null)
            coroutine = StartCoroutine(nameof(Hurt));
        else
        {
            StopCoroutine(coroutine);
            coroutine = StartCoroutine(nameof(Hurt));
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            if (coroutine != null)
                StopCoroutine(coroutine);
    }
    IEnumerator Hurt()
    {
        while (player.CurrentHealth > 0)
        {
            player.CurrentHealth -= 5;
            Debug.Log(player.CurrentHealth);
            player.statebar.UpdateStats(player.CurrentHealth, player.MaxHealth);
            yield return new WaitForSeconds(2f);
        }

    }
}

