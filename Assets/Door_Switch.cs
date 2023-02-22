using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Switch : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite off;
    public Sprite On;
    public GameObject plane;
    public GameObject shandian;
    public GameObject boss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.name == "ball")
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = off;
            if (shandian == null) return;
            plane.transform.localRotation = Quaternion.Euler(0, 0, 10);
            shandian.SetActive(false);
            if (boss != null)
                boss.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.name == "ball")
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = On;
            if (shandian == null) return;
            //shandian.SetActive(true);
        }
    }
}
