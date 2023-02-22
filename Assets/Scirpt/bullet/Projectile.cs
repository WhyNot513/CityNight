using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector2 moveDirection;
    [SerializeField] protected float DestoryTime = 1f;//子弹销毁的时间
    public float DefaultDamage;
    public float damage;//伤害 
    protected WaitForSeconds WaitDestoryTime;
    public GameObject target;
    public GameObject PorjectVfx;
    protected Coroutine Destory;
    Coroutine Move;
    void Awake()
    {

    }



    protected void OnEnable()
    {
        target = (GameObject.FindGameObjectWithTag("Player"));
        WaitDestoryTime = new WaitForSeconds(DestoryTime);

        Move = StartCoroutine(nameof(MoveProjectile));

        Destory = StartCoroutine(nameof(DestoryBullet));
        gameObject.transform.position = Vector3.zero;
        if (target == null)
        {
            // moveDirection = new Vector2(0, -1);
        }
        StartCoroutine(nameof(MoveDirectionCoroutine));

    }
    protected void OnDisable()
    {

        StopCoroutine(Move);
        StopCoroutine(Destory);
        damage = DefaultDamage;

    }
    protected IEnumerator MoveProjectile()
    {

        while (gameObject.activeSelf)
        {
            OnMove();

            yield return null;
        }

    }
    public virtual void OnMove() => transform.Translate(moveSpeed * moveDirection * Time.deltaTime);

    IEnumerator MoveDirectionCoroutine()
    {


        //while (target != null)
        //{
        //if (target.activeSelf)
        //{

        //    moveDirection = ((target.transform.position - transform.position).normalized);
        yield return null;
        //}

        //}


    }

    protected virtual IEnumerator DestoryBullet()
    {
        yield return WaitDestoryTime;

        gameObject.SetActive(false);

        gameObject.transform.position = Vector3.zero;


    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.TryGetComponent<playerController>(out playerController character))
        {

            if (this.gameObject.activeSelf)
            {

                this.gameObject.SetActive(false);


            }


            //播放命中特效预制体
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


    }
    protected void SetTartget(GameObject target) => this.target = target;

    protected void SetTartget(List<GameObject> targetList, Transform startPos)
    {
        float distance = 1000;
        int index = -1;
        for (int i = 0; i < targetList.Count; i++)
        {

            if (distance > (targetList[i].transform.localPosition - startPos.position).magnitude)
            {
                index = i;

                distance = (targetList[i].transform.localPosition - startPos.position).magnitude;
            }

        }
        this.target = index != -1 ? targetList[index] : null;
    }


}
