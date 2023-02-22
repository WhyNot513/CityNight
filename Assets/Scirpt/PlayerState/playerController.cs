using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playerController : MonoBehaviour
{

    playerGroundDetector groundDetector;
    Rigidbody2D rigidbody2d;
    PlayerInput input;
    public float MaxHealth = 100;
    public float CurrentHealth;
    public static UnityAction<float> AddBlond = delegate { };
    public static UnityAction CanJume = delegate { }; //开启二段跳

    public CapsuleCollider2D cirecolid;
    [SerializeField] public Statebar_Hub statebar;
    public bool CanAirJump { get; set; }
    public bool CanLadder { get; set; }

    public bool CanHurt { get; set; }
    public bool IsGrounded => groundDetector.IsGrounded; //判断玩家是否在地面上


    public bool IsFallling => rigidbody2d.velocity.y < 0 && !IsGrounded;//玩家什么时候掉落
    public float MoveSpeed => Mathf.Abs(rigidbody2d.velocity.x);//玩家当前移动速度因为有正负值所以要取绝对值

    public float MoveSpeedY => Mathf.Abs(rigidbody2d.velocity.y);//玩家当前移动速度因为有正负值所以要取绝对值

    public bool Isbranch;//是否开始发射
    public bool Fire = false;

    private void Awake()
    {
        groundDetector = GetComponentInChildren<playerGroundDetector>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        input = GetComponentInChildren<PlayerInput>();
        AddBlond += Addblone;
        CanJume += CanjumpTwo;
    }
    private void OnDisable()
    {
        AddBlond -= Addblone;
        CanJume -= CanjumpTwo;
    }
    private void Update()
    {
        if (input.addblen)
        {
            if (GameManager.Instance.AddBlonecount > 0)
            {
                GameManager.Instance.AddBlonecount--;
                GameManager.Instance.gameDate.addbloneCount--;
                Addblone(10);
            }
        }

    }
    private void OnEnable()
    {
        CurrentHealth = MaxHealth;
        statebar.Initalize(CurrentHealth, MaxHealth);
    }
    /// <summary>
    /// 设置刚体速度
    /// </summary>
    /// <param name="velocity"></param>
    public void SetVelocity(Vector3 velocity)
    {
        rigidbody2d.velocity = velocity;
    }

    /// <summary>
    /// 玩家左右移动时候调用此函苏
    /// </summary>
    /// <param name="velocityX"></param>
    public void SetVelocityX(float velocityX)
    {
        rigidbody2d.velocity = new Vector2(velocityX, rigidbody2d.velocity.y);
    }

    /// <summary>
    /// 玩家上下移动的时候 跳跃落下
    /// </summary>
    /// <param name="velocityY"></param>
    public void SetVelocityY(float velocityY)
    {

        rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, velocityY);


    }

    public void MoveX(float speed)
    {

        if (input.Move && input.AxisX != 0)
        {
            transform.localScale = new Vector3(input.AxisX, 1f, 1f);//镜像反转当人物移动的时候
        }
        SetVelocityX(speed * input.AxisX);
    }
    public void SetUseGravity(float value)
    {
        rigidbody2d.gravityScale = value;
    }

    public bool canLadder()
    {
        return !(input.AxisY == -1 && IsGrounded);
    }

    public void Addblone(float health) //加血
    {
        if (CurrentHealth + health > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        else
        {
            CurrentHealth += health;
        }


        statebar.UpdateStats(CurrentHealth, MaxHealth);
    }

    public void CanjumpTwo()
    {
        CanAirJump = true;
    }




}
