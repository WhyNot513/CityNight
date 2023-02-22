using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Animator animator;
    [SerializeField, Header("子弹发射生存时间")] float bulletTime = 2f;
    WaitForSeconds WaitForSecondsBulletTime;
    Rigidbody2D rigidbody2D;
    public GameObject door;
    public int damage;
    private void Awake()
    {

        animator = GetComponent<Animator>();
        if (GetComponent<Rigidbody2D>())
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        WaitForSecondsBulletTime = new WaitForSeconds(bulletTime);
    }
    public void OnEnable()
    {
        //  animator.Play("");
        Recyclebullet();
    }

    void Recyclebullet()
    {
        StopCoroutine(nameof(RecycleBullets_Coroutine));
        StartCoroutine(nameof(RecycleBullets_Coroutine));
    }


    IEnumerator RecycleBullets_Coroutine()
    {
        yield return WaitForSecondsBulletTime;
        if (rigidbody2D)
            rigidbody2D.velocity = Vector2.zero;
        this.gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        if (door != null)
            door.SetActive(true);
    }
}
