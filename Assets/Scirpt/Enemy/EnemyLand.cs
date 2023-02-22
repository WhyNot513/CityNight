using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLand : Enemy
{
    // Start is called before the first frame update
    int Dir => (int)this.gameObject.GetComponent<Transform>().localScale.x;//怪物移动方向
    [SerializeField] float acceleration = 1;
    // Start is called before the first frame update
    private void Awake()
    {
        Enemyrigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    public override void Move()
    {
        if (Mathf.Abs(Enemyrigidbody2D.velocity.x) <= 0)
        {
            //   Debug.LogWarning(this.gameObject.name);
            animator.Play($"{this.gameObject.name}_shoot");

            if (IsAnimationFinshed)
            {
                if (Onfire == true)
                {
                    EnemiesManager.inter_.BranchBullet(0, BranchPos.transform.position, 2 * -Dir);
                    Onfire = false;
                }
                animator.Play($"{this.gameObject.name}_run");
                Enemyrigidbody2D.velocity = new Vector2(Random.Range(MinVelocity, MaxVelocity) * Dir, 0);
                transform.localScale = new Vector3(-Dir, 1f, 1f);//镜像反转当人物移动的时候
                IsAnimationFinshed = false;
                Onfire = true;
            }



        }

    }
}
