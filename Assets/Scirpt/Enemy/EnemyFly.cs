using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : Enemy
{

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
            //Debug.LogWarning(this.gameObject.name);

            animator.Play($"{this.gameObject.name}_shoot");
            if (IsAnimationFinshed)
            {
                if (Onfire == true)
                {
                    EnemiesManager.inter_.BranchBullet(0, BranchPos.transform.position, 2 * -Dir);
                    Onfire = false;
                }

                Enemyrigidbody2D.velocity = new Vector2(Random.Range(MinVelocity, MaxVelocity) * Dir, 0);
                transform.localScale = new Vector3(-Dir, 1f, 1f);//镜像反转当人物移动的时候

                Onfire = true;
            }



        }

        Enemyrigidbody2D.velocity = new Vector2(Mathf.MoveTowards(Enemyrigidbody2D.velocity.x, 0, acceleration * Time.deltaTime), 0); //逐帧修改当前速度直到最大值
    }


}
