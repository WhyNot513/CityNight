using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGroundDetector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float detectionRadius = 0.1f;//检查半径
    [SerializeField] LayerMask groundLayer;//层级
    Collider2D[] colliders = new Collider2D[1];
    public bool IsGrounded => Physics2D.OverlapCircleNonAlloc(transform.position, detectionRadius, colliders, groundLayer) != 0;//通关投射虚拟球体来判断碰撞体有没有接触来检查


    private void OnDrawGizmosSelected() //将虚拟小球显示出来
    {

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, detectionRadius);
    }

}
