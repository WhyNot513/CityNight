using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float acceleration = 1f;//怪物加速度
    [SerializeField] float ChangeVeloctiyTime = 2f;
    [SerializeField] float maxVelocity;
    [SerializeField] float MinVelocity;
    public GameObject BranchPos;

    protected bool IsAnimationFinshed;

    bool Onfire = true;
    Animator animator;
    int Dir => (int)this.gameObject.GetComponent<Transform>().localScale.x;//怪物移动方向
    Rigidbody2D Enemyrigidbody2D;
    WaitForSeconds ChangeVeloctiy;
    private void Awake()
    {

        Enemyrigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {

        ChangeVeloctiy = new WaitForSeconds(ChangeVeloctiyTime);
        Enemyrigidbody2D.velocity = new Vector2(Random.Range(MinVelocity, maxVelocity) * Dir, 0);
        //  StartCoroutine(nameof(ChangeVeloctiy_Coroutine));
    }


    private void Update()
    {

        if (Mathf.Abs(Enemyrigidbody2D.velocity.x) <= 0)
        {
            Debug.LogWarning(this.gameObject.name);
            animator.Play($"{this.gameObject.name}_shoot");

            if (IsAnimationFinshed)
            {
                if (Onfire == true)
                {
                    EnemiesManager.inter_.BranchBullet(0, BranchPos.transform.position, 2 * -Dir);
                    Onfire = false;
                }
                animator.Play($"{this.gameObject.name}_run");
                Enemyrigidbody2D.velocity = new Vector2(Random.Range(MinVelocity, maxVelocity) * Dir, 0);
                transform.localScale = new Vector3(-Dir, 1f, 1f);//镜像反转当人物移动的时候
                IsAnimationFinshed = false;
                Onfire = true;
            }



        }

        //   Enemyrigidbody2D.velocity = new Vector2(Mathf.MoveTowards(Enemyrigidbody2D.velocity.x, 0, acceleration * Time.deltaTime), 0); //逐帧修改当前速度直到最大值
    }
    public void JudeAnimationEDN()
    {
        IsAnimationFinshed = true;
    }
}
