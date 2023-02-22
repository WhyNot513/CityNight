using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    public GameObject vfx;
    public AudioData musici;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnDisable()
    {
        if (musici != null)
            AduioManager.instance.PlayerSFX(musici);
        GameManager.Instance.StartCoroutine(GameManager.Instance.star(this.gameObject));
        if (vfx != null)
        {
            PoolManager.Release(vfx, this.transform.position); ;
        }
        playerController.CanJume();
    }

}
