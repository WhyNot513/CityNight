using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    protected Rigidbody2D Enemyrigidbody2D;
    protected Animator animator;
    protected bool Onfire;
    protected bool IsAnimationFinshed = false;
    [SerializeField] protected GameObject BranchPos;
    [SerializeField] protected float MaxVelocity;
    [SerializeField] protected float MinVelocity;
    public float health;
    public float current;
    protected int Dir => (int)this.gameObject.GetComponent<Transform>().localScale.x;//怪物移动方向
    public Statebar_Hub statebar_Hub;
    private void OnEnable()
    {
        current = health;
        statebar_Hub.Initalize(current, health);

    }
    private void Update()
    {
        Move();

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "PlayerBullet")
        {

            Died(collision);


        }
        if (collision.tag == "Player")
        {
            //  Shoot();
        }
    }

    public virtual void Move()
    {

    }
    public virtual void Shoot()
    {
        if (Onfire == true)
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            animator.Play($"{this.gameObject.name}_shoot");
            EnemiesManager.inter_.BranchBullet(0, BranchPos.transform.position, 2 * -Dir);

            //Onfire = false;
            //IsAnimationFinshed = false;
        }
    }
    public virtual void Died(Collider2D collision)
    {
        if (collision.gameObject.activeInHierarchy == true)
        {

            if (collision.gameObject.GetComponent<bullet>() != null)
            {
                current -= collision.gameObject.GetComponent<bullet>().damage;
                collision.gameObject.SetActive(false);
                statebar_Hub.UpdateStats(current, health);
                if (current <= 0)
                {
                    this.gameObject.SetActive(false);

                    PoolManager.Release(EnemiesManager.inter_.EnemyDieVfx[0], this.gameObject.transform.localPosition);
                }
            }



        }

        //播放爆炸特效
    }
    public virtual void JudeAnimationEDN()
    {
        IsAnimationFinshed = true;
    }
}
