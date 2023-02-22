using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePanel : MonoBehaviour
{

    public GameObject go;
    public int count;
    public bool dir;
    void Start()
    {
        StartCoroutine(nameof(Move));
    }
    IEnumerator Move()
    {

        while (true)

        {
            if (count >= 15)
            {
                dir = true;
                count = 15;
            }
            if (count <= 0)
            {
                dir = false;
                count = 0;
            }
            if (dir)
            {
                transform.Translate(0.1f * Vector2.left);

            }
            else
            {
                transform.Translate(0.1f * Vector2.right);

            }
            count = dir ? count - 1 : count + 1;
            int d = 1;
            d = dir ? -1 : 1;
            if (go != null)
                go.transform.Translate(0.1f * Vector2.right * d);
            yield return new WaitForSeconds(0.1f);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            go = collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            go = null
                ;
        }
    }
}
